using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        private static Socket incomingClient;
        /// <summary>
        /// Entry point for the executable.
        /// </summary>
        /// <param name="args">Command line arguments</param>
        static void Main(string[] args)
        {
            try
            {
                listenHandler = new Listener();
                listenHandler.StartListening();
                incomingClient = listenHandler.AcceptClient();
                RequestHandler reqHandler = new RequestHandler(incomingClient);
                ResponseHandler resHandler = new ResponseHandler(reqHandler.RequesMessage, incomingClient);
            }
            catch (Exception e)
            {
                listenHandler.StopListening();
                incomingClient.Close();
                throw e;
            }
            
            Console.ReadLine();
        }
    }
}
