using System;
using System.Collections.Generic;
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


            if (request.Contains("GET"))
            {
                if (request.Contains("test.html"))
                {
                    FileStream fStream = new FileStream("C:/Temp/trialHttpServer.html", FileMode.Open);
                    string byteBuff = "";
                    while (fStream.Position < fStream.Length)
                    {
                        byteBuff = byteBuff + fStream.ReadByte();
                    }
                    Byte[] fileBytesResponse = Encoding.ASCII.GetBytes("Hello world!");
                    string fileBuffer = "";
                    fileBuffer = fileBuffer + "HTTP/1.1" + " 200 OK" + "\r\n";
                    fileBuffer = fileBuffer + "Server: cx1193719-b\r\n";
                    fileBuffer = fileBuffer + "Content-Type: " + "text/html" + "\r\n";
                    fileBuffer = fileBuffer + "Accept-Ranges: bytes\r\n";
                    fileBuffer = fileBuffer + "Content-Length: " + fileBytesResponse.Length + "\r\n\r\n";
                    fileBuffer = fileBuffer + "Hello world!\r\n";
                    Byte[] bFileSendData = Encoding.ASCII.GetBytes(fileBuffer);
                    client.Send(bFileSendData);
                    client.Dispose();
                }
                else
                {
                    Byte[] bytesResponse = Encoding.ASCII.GetBytes("Hello world!");
                    string sBuffer = "";
                    sBuffer = sBuffer + "HTTP/1.1" + " 200 OK" + "\r\n";
                    sBuffer = sBuffer + "Server: cx1193719-b\r\n";
                    sBuffer = sBuffer + "Content-Type: " + "text/html" + "\r\n";
                    sBuffer = sBuffer + "Accept-Ranges: bytes\r\n";
                    sBuffer = sBuffer + "Content-Length: " + bytesResponse.Length + "\r\n\r\n";
                    sBuffer = sBuffer + "Hello world!\r\n";
                    Byte[] bSendData = Encoding.ASCII.GetBytes(sBuffer);
                    client.Send(bSendData);
                    client.Dispose();
                }
            }
        }
    }
}