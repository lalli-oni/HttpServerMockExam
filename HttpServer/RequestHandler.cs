using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace HttpServer
{
    public class RequestHandler
    {
        private String _requestMessage;

        public String RequesMessage
        {
            get { return _requestMessage; }
            set { _requestMessage = value; }
        }

        /// <summary>
        /// Contstructor, forces a TcpClient as a parameter.
        /// </summary>
        /// <param name="requestingClient"></param>
        public RequestHandler(Socket requestingClient)
        {
            try
            {
                int msgLength = requestingClient.Available;
                byte[] buffer = new byte[msgLength];
                requestingClient.Receive(buffer);
                _requestMessage = "";
                _requestMessage = _requestMessage + Encoding.ASCII.GetString(buffer, 0, msgLength);
                WriteRequest(_requestMessage);
            }
            catch (Exception e)
            {
                Trace.WriteLine("Couldn't read request stream to end, exception:");
                Trace.WriteLine(e.Message);
                throw;
            }
        }

        /// <summary>
        /// Just writes out the incoming request in console
        /// </summary>
        /// <param name="request">The request being received</param>
        public void WriteRequest(string request)
        {
            Console.WriteLine(request);
        }
    }
}
