using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace HttpServer
{
    class Listener
    {
        private TcpListener listener;
        /// <summary>
        /// Constructor for the listener. Starts listening immidiately.
        /// </summary>
        public Listener()
        {
            IPAddress ipAdr = IPAddress.Parse("192.168.1.39");
            listener = new TcpListener(ipAdr, 80);
        }

        public void StartListening()
        {
            listener.Start(100);
            Trace.WriteLine("Listening...");
        }

        public void StopListening()
        {
            listener.Stop();
            Trace.WriteLine("Stopped listening...");
        }

        public TcpClient AcceptClient()
        {
            Trace.WriteLine("Accepting clients...");
            TcpClient returnClient = listener.AcceptTcpClient();
            return returnClient;
        }
    }
}
