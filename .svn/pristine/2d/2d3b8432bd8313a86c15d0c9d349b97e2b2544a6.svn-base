using System;
using System.Net.Sockets;
using System.Collections.Generic;
using System.Threading;

using Ulee.Utils;
using Ulee.Device.Connection;

namespace Hnc.Calorimeter.Server
{
    public class CalorimeterServer
    {
        public CalorimeterServer(UlIniFile ini)
        {
            Ini = ini;

            Clients = new Dictionary<string, ClientRow>();

            ClientList = new List<ClientRow>();

            Udp = new UdpClient(Ini.GetInteger("Server", "port"));

            Devices = new ServerDevice(this);

            Listener = new ServerListener(this);

            Sender = new ServerSender(this);
        }

        public void Connect()
        {
            Devices.Connect();
        }

        public void Close()
        {
            Devices.Close();
        }

        public void Resume()
        {
            Devices.Resume();
            Listener.Resume();
            Sender.Resume();
        }

        public void Suspend()
        {
            Devices.Suspend();
            Listener.Suspend();
            Sender.Suspend();
        }

        public void Terminate()
        {
            Devices.Terminate();
            Listener.Terminate();
            Sender.Terminate();
        }

        public void NotifyTermination()
        {
            lock (Clients)
            {
                foreach (ClientRow client in ClientList)
                {
                    Sender.NotifyTermination(client.IpPoint);
                }
            }

            Thread.Sleep(500);
        }

        public UlIniFile Ini;

        public UdpClient Udp { get; private set; }

        public List<ClientRow> ClientList { get; private set; }

        public Dictionary<string, ClientRow> Clients { get; private set; }

        public ServerDevice Devices { get; private set; }

        public ServerListener Listener { get; private set; }

        public ServerSender Sender { get; private set; }
    }
}
