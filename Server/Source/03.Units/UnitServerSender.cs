using System;
using System.Text;
using System.Collections.Generic;
using System.Net;

using Ulee.Utils;
using Ulee.Threading;

namespace Hnc.Calorimeter.Server
{
    public enum ESenderLogging
    { None, Event, All }

    public enum ESenderLogItem
    { Send, Note, Exception }

    public enum EServerCommand : byte
    {
        Acknowledge = 100,
        DeviceValues,
        ClientList,
        NotifyTermination
    }

    public class ServerSender : UlThread
    {
        public ServerSender(CalorimeterServer server) : base(false)
        {
            this.server = server;
            packet = new ServerSendPacket(server.Devices.Bytes.Length + 17);

            logger = new UlLogger();
            logger.Active = true;
            logger.Path = server.Ini.GetString("Sender", "LogPath");
            logger.FName = server.Ini.GetString("Sender", "LogFileName");
            logger.AddHead("SERVER->CLIENT");
            logger.AddHead("NOTE");
            logger.AddHead("EXCEPTION");

            Logging = GetLogging();
        }

        private CalorimeterServer server;

        private ServerSendPacket packet;

        private UlLogger logger;

        // Log 파일기록여부
        public ESenderLogging Logging;

        // Log 파일경로
        public string LogPath
        { get { return logger.Path; } set { logger.Path = value; } }

        // Log 파일명
        public string LogFName
        { get { return logger.FName; } set { logger.FName = value; } }

        // Log 확장명
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

            switch (server.Ini.GetString("sender", "logging").ToLower())
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

        protected override void Execute()
        {
            while (Terminated == false)
            {
                lock (server.Clients)
                {
                    foreach (KeyValuePair<string, ClientRow> row in server.Clients)
                    {
                        ClientRow client = row.Value;
                        if (client.BeginTime == 0)
                        {
                            client.BeginTime = ElapsedMilliseconds;
                        }

                        if (client.State != EClientState.Observation)
                        {
                            if (IsTimeoutMilliseconds(client.BeginTime, client.ScanTime) == true)
                            {
                                // Timer 초기화
                                client.BeginTime += client.ScanTime;
                                Send(client);
                            }
                        }
                    }
                }

                Yield();
            }
        }

        private void Send(ClientRow client)
        {
            try
            {
                lock (server.Udp)
                {
                    server.Devices.Lock();
                    try
                    {
                        packet.Clear();
                        packet.Command = EServerCommand.DeviceValues;
                        packet.IArg1 = (server.Devices.PowerMeterConnected == true) ? 1 : 0;
                        packet.IArg2 = (server.Devices.RecorderConnected == true) ? 1 : 0;
                        packet.IArg3 = (server.Devices.ControllerConnected == true) ? 1 : 0;
                        packet.IArg4 = (server.Devices.PlcConnected == true) ? 1 : 0;

                        Buffer.BlockCopy(
                            server.Devices.Bytes, 0, packet.Bytes, 17, server.Devices.Bytes.Length);
                    }
                    finally
                    {
                        server.Devices.Unlock();
                    }

                    server.Udp.Send(packet.Bytes, packet.Length, client.IpPoint);
                }

                if (Logging == ESenderLogging.All)
                {
                    logger.Log((int)ESenderLogItem.Send,
                        "To {0} - Command : {1}, PowerMeter : {2}, Recorder : {3}, Controller : {4}, Plc : {5}",
                        client.IpPort, packet.Command.ToString(), packet.IArg1, packet.IArg2, packet.IArg3, packet.IArg4);
                }
            }
            catch (Exception e)
            {
                logger.Log((int)ESenderLogItem.Exception, e.ToString());
            }
        }

        public void Acknowledge(IPEndPoint ipPoint)
        {
            try
            {
                lock (server.Udp)
                {
                    packet.Clear();
                    packet.Command = EServerCommand.Acknowledge;

                    server.Udp.Send(packet.Bytes, 17, ipPoint);
                }

                if (Logging == ESenderLogging.All)
                {
                    logger.Log((int)ESenderLogItem.Send, 
                        "To {0} - Command : {1}", ipPoint.ToString(), packet.Command.ToString());
                }
            }
            catch (Exception e)
            {
                logger.Log((int)ESenderLogItem.Exception, e.ToString());
            }
        }

        public void NotifyTermination(IPEndPoint ipPoint)
        {
            try
            {
                lock (server.Udp)
                {
                    packet.Clear();
                    packet.Command = EServerCommand.NotifyTermination;

                    server.Udp.Send(packet.Bytes, 17, ipPoint);
                }

                if (Logging == ESenderLogging.All)
                {
                    logger.Log((int)ESenderLogItem.Send,
                        "To {0} - Command : {1}", ipPoint.ToString(), packet.Command.ToString());
                }
            }
            catch (Exception e)
            {
                logger.Log((int)ESenderLogItem.Exception, e.ToString());
            }
        }
    }

    public class ServerSendPacket
    {
        public ServerSendPacket(int length)
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
