using System;
using System.Net;

namespace Hnc.Calorimeter.Server
{
    public class ClientRow : IEquatable<string>
    {
        public ClientRow(IPEndPoint ipPoint, long time, EClientState state = EClientState.Idle)
        {
            Index = 0;
            IpPoint = ipPoint;
            ScanTime = time;
            State = state;
            ConnectedTime = DateTime.Now;
            BeginTime = 0;
        }

        public int Index { get; set; }

        public IPEndPoint IpPoint { get; private set; }

        public string Ip { get { return IpPoint.Address.ToString(); } }

        public int Port { get { return IpPoint.Port; } }

        public string IpPort { get { return IpPoint.ToString(); } }

        public EClientState State { get; set; }

        public long ScanTime { get; set; }

        public long BeginTime { get; set; }

        public DateTime ConnectedTime { get; private set; }

        public bool Equals(string ipPort)
        {
            return (IpPort == ipPort) ? true : false;
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;

            ClientRow client = obj as ClientRow;

            if (client == null) return false;

            return Equals(client.IpPort);
        }

        public override int GetHashCode()
        {
            return Ip.GetHashCode();
        }
    }
}
