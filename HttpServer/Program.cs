using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace HttpServer
{
    class Program
    {
        private static Listener listenHandler;
        /// <summary>
        /// Entry point for the executable.
        /// </summary>
        /// <param name="args">Command line arguments</param>
        static void Main(string[] args)
        {
            listenHandler = new Listener();
            listenHandler.StartListening();
            TcpClient incomingClient = listenHandler.AcceptClient();
            RequestHandler reqHandler = new RequestHandler(incomingClient);
            //reqHandler.RequestContent.Headers;
            Console.ReadLine();
        }
    }
}
