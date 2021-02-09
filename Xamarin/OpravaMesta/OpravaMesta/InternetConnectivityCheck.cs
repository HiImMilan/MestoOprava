using System;
using System.Net;
using System.Net.NetworkInformation;

namespace OpravaMesta
{
    class InternetConnectivityCheck
    {
        private Ping pingSender;
        public InternetConnectivityCheck(Action<PingCompletedEventArgs> action, int timeout = 12000)
        {
            pingSender = new Ping();
            pingSender.PingCompleted += new PingCompletedEventHandler((object sender,PingCompletedEventArgs e) => action(e));

            pingSender.SendAsync(IPAddress.Parse("1.1.1.1"), timeout);
        }
    }
}