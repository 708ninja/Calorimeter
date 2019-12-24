using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

using Ulee.Utils;
using Ulee.Threading;
using Ulee.DllImport.Win32;

namespace Hnc.Calorimeter.Client
{
    public enum EServerCommand : byte
    {
        Acknowledge = 100,
        DeviceValues = 101,
        ClientList = 102,
        NotifyTermination = 103
    }

    public enum EListenerLogging
    { None, Event, All }

    public enum EListenerLogItem
    { Send, Receive, Note, Exception }

    public class ClientReceiveArgs : EventArgs
    {
        public ClientReceiveArgs()
        {
            PowerMeter = false;
            Recorder = false;
            Controller = false;
            Plc = false;
        }

        public bool PowerMeter { get; set; }
        public bool Recorder { get; set; }
        public bool Controller { get; set; }
        public bool Plc { get; set; }
    }

    public class ClientListener : UlThread
    {
        public ClientListener(CalorimeterClient client) : base(false)
        {
            this.client = client;
            Acknowledge = false;
            NotifyTermination = null;
            NonAcknowledge = null;

            int fLength = client.Ini.GetInteger("Device", "FValueLength");
            int nLength = client.Ini.GetInteger("Device", "NValueLength");

            FValues = new float[fLength];
            NValues = new UInt16[nLength];

            packet = new ClientReceivePacket(fLength*4 + nLength*2 + 17);
            clientArgs = new ClientReceiveArgs();

            logger = new UlLogger();
            logger.Active = true;
            logger.Path = client.Ini.GetString("Listener", "LogPath");
            logger.FName = client.Ini.GetString("Listener", "LogFileName");
            logger.AddHead("CLIENT->SERVER");
            logger.AddHead("CLIENT<-SERVER");
            logger.AddHead("NOTE");
            logger.AddHead("EXCEPTION");

            Logging = GetLogging();
        }

        public const int csAckWaitTime = 500;

        private CalorimeterClient client;

        private ClientReceivePacket packet;

        private ClientReceiveArgs clientArgs;

        private UlLogger logger;

        // Log 파일기록여부
        public EListenerLogging Logging { get; private set; }

        // Log 파일경로
        public string LogPath
        { get { return logger.Path; } set { logger.Path = value; } }

        // Log 파일명
        public string LogFName
        { get { return logger.FName; } set { logger.FName = value; } }

        // Log 파일명
        public string LogExt
        { get { return logger.Ext; } set { logger.Ext = value; } }

        // Log 파일 Encoding 
        public Encoding LogFEncoding
        { get { return logger.FEncoding; } set { logger.FEncoding = value; } }

        // Log 파일 분리 기준 - Min, Hour, Day
        public EUlLogFileSeperation LogFSeperation
        { get { return logger.FSeperation; } set { logger.FSeperation = value; } }

        private EListenerLogging GetLogging()
        {
            EListenerLogging ret;

            switch (client.Ini.GetString("listener", "logging").ToLower())
            {
                case "none":
                    ret = EListenerLogging.None;
                    break;

                case "event":
                    ret = EListenerLogging.Event;
                    break;

                case "all":
                    ret = EListenerLogging.All;
                    break;

                default:
                    ret = EListenerLogging.Event;
                    break;
            }

            return ret;
        }

        public void Log(EListenerLogItem item, string str)
        {
            switch (Logging)
            {
                case EListenerLogging.None:
                    break;

                case EListenerLogging.Event:
                case EListenerLogging.All:
                    logger.Log((int)item, str);
                    break;
            }
        }

        public void Log(EListenerLogItem item, string fmt, params object[] args)
        {
            string str = string.Format(fmt, args);

            Log(item, str);
        }

        public event EventHandler RefreshConnectionState;
        private void OnRefreshConnectionState(object sender, EventArgs args)
        {
            RefreshConnectionState?.Invoke(sender, args);
        }

        public event EventHandler NotifyTermination;
        private void OnNotifyTermination(object sender, EventArgs args)
        {
            NotifyTermination?.Invoke(sender, args);
        }

        public event EventHandler NonAcknowledge;
        private void OnNonAcknowledge(object sender, EventArgs args)
        {
            string msg = "Can't receive acknowledgement from Server!";

            Log(EListenerLogItem.Exception, msg);
            if (NonAcknowledge == null)
            {
                throw new Exception(msg);
            }
            else
            {
                NonAcknowledge.Invoke(sender, args);
            }
        }

        public float[] FValues { get; private set; }

        public UInt16[] NValues { get; private set; }

        public volatile bool Acknowledge;

        public void Lock()
        {
            Monitor.Enter(FValues);
            Monitor.Enter(NValues);
        }

        public void Unlock()
        {
            Monitor.Exit(FValues);
            Monitor.Exit(NValues);
        }


        public void WaitForAck(long time=csAckWaitTime)
        {
            long beginTime = ElapsedMilliseconds;

            while (Acknowledge == false)
            {
                if (IsTimeoutMilliseconds(beginTime, time) == true)
                {
                    OnNonAcknowledge(this, null);
                    break;
                }

                Yield();
            }

            Acknowledge = false;
        }

        private void DoDeviceValues()
        {
            Lock();

            try
            {
                for (int i = 0; i < FValues.Length; i++)
                {
                    FValues[i] = BitConverter.ToSingle(packet.Bytes, 17 + i * 4);
                }

                for (int i = 0; i < NValues.Length; i++)
                {
                    NValues[i] = BitConverter.ToUInt16(packet.Bytes, 17 + FValues.Length * 4 + i * 2);
                }

                client.Devices.RefreshValues();
            }
            finally
            {
                Unlock();
            }

            clientArgs.PowerMeter = (packet.IArg1 == 0) ? false : true;
            clientArgs.Recorder = (packet.IArg2 == 0) ? false : true;
            clientArgs.Controller = (packet.IArg3 == 0) ? false : true;
            clientArgs.Plc = (packet.IArg4 == 0) ? false : true;

            OnRefreshConnectionState(null, clientArgs);
        }

        protected override void Execute()
        {
            byte[] bytes;
            IPEndPoint ipPoint = new IPEndPoint(IPAddress.Any, 0);

            // Thread 종료 신호가 들어올때 까지 루프
            while (Terminated == false)
            {
                if ((client != null) && (client.Udp != null))
                {
                    lock (client.Udp)
                    {
                        if (client.Udp.Available > 0)
                        {
                            try
                            {
                                bytes = client.Udp.Receive(ref ipPoint);
                            }
                            catch (Exception e)
                            {
                                bytes = null;
                                Log(EListenerLogItem.Exception, e.ToString());
                                OnNonAcknowledge(this, null);
                            }
                        }
                        else
                        {
                            bytes = null;
                        }
                    }

                    if (bytes != null)
                    {
                        if (ipPoint.ToString() == client.IpPoint.ToString())
                        {
                            packet.Clear();
                            Array.Copy(bytes, 0, packet.Bytes, 0, bytes.Length);

                            CommandExecute();
                        }
                    }
                }

                // 제어권 양보
                Yield();
            }
        }

        private void CommandExecute()
        {
            switch (Logging)
            {
                case EListenerLogging.None:
                    break;

                case EListenerLogging.Event:
                    if (packet.Command != EServerCommand.DeviceValues)
                    {
                        Log(EListenerLogItem.Receive,
                            "Received a Command({0}) - IArg1 : {1}, IArg2 : {2}, IArg3 : {3}, IArg4 : {4}",
                            packet.Command.ToString(), packet.IArg1, packet.IArg2, packet.IArg3, packet.IArg4);
                    }
                    break;

                case EListenerLogging.All:
                    Log(EListenerLogItem.Receive,
                        "Received a Command({0}) - IArg1 : {1}, IArg2 : {2}, IArg3 : {3}, IArg4 : {4}",
                        packet.Command.ToString(), packet.IArg1, packet.IArg2, packet.IArg3, packet.IArg4);
                    break;
            }

            switch (packet.Command)
            {
                case EServerCommand.Acknowledge:
                    Acknowledge = true;
                    break;

                case EServerCommand.DeviceValues:
                    DoDeviceValues();
                    break;

                case EServerCommand.ClientList:
                    break;

                case EServerCommand.NotifyTermination:
                    OnNotifyTermination(this, null);
                    break;
            }
        }
    }

    public class ClientReceivePacket
    {
        public ClientReceivePacket(int length)
        {
            packet = new UlBinSets(length);
        }

        public EServerCommand Command
        {
            get { return (EServerCommand)packet.Byte(0); }
            set { packet.Byte(0, (byte)value); }
        }

        public int IArg1
        {
            get { return (int)packet.DWord(1); }
            set { packet.DWord(1, (UInt32)value); }
        }

        public int IArg2
        {
            get { return (int)packet.DWord(5); }
            set { packet.DWord(5, (UInt32)value); }
        }

        public int IArg3
        {
            get { return (int)packet.DWord(9); }
            set { packet.DWord(9, (UInt32)value); }
        }

        public int IArg4
        {
            get { return (int)packet.DWord(13); }
            set { packet.DWord(13, (UInt32)value); }
        }

        private UlBinSets packet;

        public void Clear()
        {
            packet.Clear();
        }

        public byte[] Bytes
        { get { return packet.Bytes; } }

        public int Length
        { get { return packet.Count; } }
    }
}
