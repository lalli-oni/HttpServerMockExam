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
    public class Listener
    {
        private TcpListener listener;
        /// <summary>
        /// Constructor for the listener. Sets the address for the listener as local IP and port 80.
        /// </summary>
        public Listener()
        {
            IPAddress ipAdr = IPAddress.Parse("192.168.1.39");
            listener = new TcpListener(ipAdr, 80);
        }


        /// <summary>
        /// Starts listening for connections with a max backlog of 100 connections
        /// </summary>
        public void StartListening()
        {
            listener.Start(100);
            Trace.WriteLine("Listening...");
        }

        /// <summary>
        /// Manually stops listening.
        /// </summary>
        public void StopListening()
        {
            listener.Stop();
            Trace.WriteLine("Stopped listening...");
        }

        /// <summary>
        /// Accepts incoming connection requests.
        /// </summary>
        /// <returns>The Client object representing the connection</returns>
        public Socket AcceptClient()
        {
            Trace.WriteLine("Accepting clients...");
            Socket returnClient = listener.AcceptSocket();
            return returnClient;
        }
    }
}
