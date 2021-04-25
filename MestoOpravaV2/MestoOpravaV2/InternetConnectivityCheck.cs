using System;
using System.Net;
using System.Net.NetworkInformation;

namespace MestoOpravaV2
{
    class InternetConnectivityCheck
    {
        public static string ServerIP = "158.255.29.10/Server/";
        private Ping pingSender;
        public InternetConnectivityCheck(Action<PingCompletedEventArgs> action, int timeout = 12000)
        {
            pingSender = new Ping();
            pingSender.PingCompleted += new PingCompletedEventHandler((object sender,PingCompletedEventArgs e) => action(e));
            pingSender.SendAsync(IPAddress.Parse("1.1.1.1"), timeout);
        }
    }
}