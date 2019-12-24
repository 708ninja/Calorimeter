using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Ulee.Utils;
using Ulee.Device.Connection.Yokogawa;

namespace Hnc.Calorimeter.Client
{
    public enum EClientCommand : byte
    {
        ConnectClient = 200,
        DisconnectClient = 201,
        GetClientList = 202,
        SetClientState = 203,
        SetController = 204,
        SetPlc = 205,
        StartIntegrationPM = 206,
        StopIntegrationPM = 207,
        ResetIntegrationPM = 208,
        SetWiringPM = 209
    }

    public enum ESenderLogging
    { None, Event, All }

    public enum ESenderLogItem
    { Send, Note, Exception }

    public class ClientSender
    {
        public ClientSender(CalorimeterClient client)
        {
            this.client = client;
            packet = new ClientSendPacket();

            logger = new UlLogger();
            logger.Active = true;
            logger.Path = client.Ini.GetString("Sender", "LogPath");
            logger.FName = client.Ini.GetString("Sender", "LogFileName");
            logger.AddHead("CLIENT->SERVER");
            logger.AddHead("NOTE");
            logger.AddHead("EXCEPTION");

            Logging = GetLogging();
        }

        private CalorimeterClient client;

        private ClientSendPacket packet;

        private UlLogger logger;

        // Log 파일기록여부
        public ESenderLogging Logging { get; private set; }

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

        private ESenderLogging GetLogging()
        {
            ESenderLogging ret;

            switch (client.Ini.GetString("listener", "logging").ToLower())
            {
                case "none":
                    ret = ESenderLogging.None;
                    break;

                case "event":
                    ret = ESenderLogging.Event;
                    break;

                case "all":
                    ret = ESenderLogging.All;
                    break;

                default:
                    ret = ESenderLogging.Event;
                    break;
            }

            return ret;
        }

        public void Log(ESenderLogItem item, string str)
        {
            switch (Logging)
            {
                case ESenderLogging.None:
                    break;

                case ESenderLogging.Event:
                case ESenderLogging.All:
                    logger.Log((int)item, str);
                    break;
            }
        }

        public void Log(ESenderLogItem item, string fmt, params object[] args)
        {
            string str = string.Format(fmt, args);

            Log(item, str);
        }

        public void Connect()
        {
            lock (client.Udp)
            {
                packet.Clear();
                packet.Command = EClientCommand.ConnectClient;
                packet.IArg1 = 1000;

                client.Udp.Send(packet.Bytes, packet.Bytes.Length, client.IpPoint);
                Log(ESenderLogItem.Send, "Send a Command({0}) - IArg1 : {1}", packet.Command.ToString(), packet.IArg1);
            }

            client.Listener.WaitForAck();
        }

        public void Disconnect()
        {
            lock (client.Udp)
            {
                packet.Clear();
                packet.Command = EClientCommand.DisconnectClient;

                client.Udp.Send(packet.Bytes, packet.Bytes.Length, client.IpPoint);
                Log(ESenderLogItem.Send, "Send a Command({0})", packet.Command.ToString());
            }

            client.Listener.WaitForAck();
        }

        public void SetClientState(EClientState state)
        {
            lock (client.Udp)
            {
                packet.Clear();
                packet.Command = EClientCommand.SetClientState;
                packet.IArg1 = (int)state;

                client.Udp.Send(packet.Bytes, packet.Bytes.Length, client.IpPoint);
                Log(ESenderLogItem.Send, "Send a Command({0}) - IArg1 : {1}", packet.Command.ToString(), packet.IArg1);
            }

            client.Listener.WaitForAck();
        }

        public void SetController(int networkNo, int  controllerNo, int addr, float value)
        {
            lock (client.Udp)
            {
                packet.Clear();
                packet.Command = EClientCommand.SetController;
                packet.IArg1 = networkNo;
                packet.IArg2 = controllerNo;
                packet.IArg3 = addr;
                packet.FArg1 = value;

                client.Udp.Send(packet.Bytes, packet.Bytes.Length, client.IpPoint);
                Log(ESenderLogItem.Send, "Send a Command({0}) - IArg1 : {1}, IArg2 : {2}, IArg3 : {3}, FArg1 : {4:F2}", 
                    packet.Command.ToString(), packet.IArg1, packet.IArg2, packet.IArg3, packet.FArg1);
            }

            client.Listener.WaitForAck();
        }

        public void SetPlc()
        {
        }

        public void StartIntegrationPM(int index)
        {
            lock (client.Udp)
            {
                packet.Clear();
                packet.Command = EClientCommand.StartIntegrationPM;
                packet.IArg1 = index;

                client.Udp.Send(packet.Bytes, packet.Bytes.Length, client.IpPoint);
                Log(ESenderLogItem.Send, "Send a Command({0}) - IArg1 : {1}", packet.Command.ToString(), packet.IArg1);
            }

            client.Listener.WaitForAck();
        }

        private void StopIntegrationPM(int index)
        {
            lock (client.Udp)
            {
                packet.Clear();
                packet.Command = EClientCommand.StopIntegrationPM;
                packet.IArg1 = index;

                client.Udp.Send(packet.Bytes, packet.Bytes.Length, client.IpPoint);
                Log(ESenderLogItem.Send, "Send a Command({0}) - IArg1 : {1}", packet.Command.ToString(), packet.IArg1);
            }

            client.Listener.WaitForAck();
        }

        private void ResetIntegrationPM(int index)
        {
            lock (client.Udp)
            {
                packet.Clear();
                packet.Command = EClientCommand.ResetIntegrationPM;
                packet.IArg1 = index;

                client.Udp.Send(packet.Bytes, packet.Bytes.Length, client.IpPoint);
                Log(ESenderLogItem.Send, "Send a Command({0}) - IArg1 : {1}", packet.Command.ToString(), packet.IArg1);
            }

            client.Listener.WaitForAck();
        }

        private void SetWiringPM(int index, EWT330Phase phase)
        {
            lock (client.Udp)
            {
                packet.Clear();
                packet.Command = EClientCommand.ResetIntegrationPM;
                packet.IArg1 = index;
                packet.IArg2 = (int)phase;

                client.Udp.Send(packet.Bytes, packet.Bytes.Length, client.IpPoint);
                Log(ESenderLogItem.Send, "Send a Command({0}) - IArg1 : {1}, IArg2 : {2}", 
                    packet.Command.ToString(), packet.IArg1, packet.IArg2);
            }

            client.Listener.WaitForAck();
        }
    }

    public class ClientSendPacket
    {
        public ClientSendPacket()
        {
            packet = new UlBinSets(17);
        }

        public EClientCommand Command
        {
            get { return (EClientCommand)packet.Byte(0); }
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

        public float FArg1
        {
            get { return BitConverter.ToSingle(packet.Bytes, 13); }
            set
            {
                byte[] bytes = BitConverter.GetBytes(value);

                for (int i = 0; i < bytes.Length; i++)
                {
                    packet.Byte(i + 13, bytes[i]);
                }
            }
        }

        public void Clear()
        {
            packet.Clear();
        }

        private UlBinSets packet;

        public byte[] Bytes
        { get { return packet.Bytes; } }

        public int Length
        { get { return packet.Count; } }
    }
}
