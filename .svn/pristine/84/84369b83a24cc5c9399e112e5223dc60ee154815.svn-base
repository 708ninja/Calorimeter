using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

using Ulee.Utils;

namespace Hnc.Calorimeter.Client
{
    public class CalorimeterClient
    {
        public CalorimeterClient(UlIniFile ini)
        {
            Ini = ini;

            string ip = Ini.GetString("Server", "ip");
            int port = Ini.GetInteger("Server", "port");

            IpPoint = new IPEndPoint(
                IPAddress.Parse(ip), port);

            Udp = new UdpClient();

            Listener = new ClientListener(this);

            Sender = new ClientSender(this);

            Devices = new ClientDevice(this);
        }

        public UlIniFile Ini;

        public UdpClient Udp { get; private set; }

        public IPEndPoint IpPoint { get; private set; }

        public ClientDevice Devices { get; private set; }

        public ClientListener Listener { get; private set; }

        public ClientSender Sender { get; private set;}

        public void Connect()
        {
            Sender.Connect();
        }

        public void Disconnect()
        {
            Sender.Disconnect();
        }

        public void Resume()
        {
            Listener.Resume();
        }

        public void Suspend()
        {
            Listener.Suspend();
        }

        public void Terminate()
        {
            Listener.Terminate();
        }
    }
}
