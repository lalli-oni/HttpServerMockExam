using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;

namespace HttpServer
{
    public class ResponseHandler
    {
        private HttpResponseMessage _responseMessage;

        public HttpResponseMessage ResponseMessage
        {
            get { return _responseMessage; }
            set { _responseMessage = value; }
        }

        public ResponseHandler(string request, Socket client)
        {
            _responseMessage = new HttpResponseMessage(HttpStatusCode.OK);

            Byte[] bytesResponse = Encoding.ASCII.GetBytes("Hello world!");
            string sBuffer = "";
            sBuffer = sBuffer + "HTTP/1.1" + " 200 OK" + "\r\n";
            sBuffer = sBuffer + "Server: cx1193719-b\r\n";
            sBuffer = sBuffer + "Content-Type: " + "text/html" + "\r\n";
            sBuffer = sBuffer + "Accept-Ranges: bytes\r\n";
            sBuffer = sBuffer + "Content-Length: " + bytesResponse.Length + "\r\n\r\n";
            sBuffer = sBuffer + "Hello world!\r\n";

            if (request.Contains("GET"))
            {
                HttpContent cont = new StringContent("Hello world!");
                _responseMessage.Content = cont;
                Byte[] bSendData = Encoding.ASCII.GetBytes(sBuffer);
                client.Send(bSendData);
                client.Dispose();
            }
        }
    }
}