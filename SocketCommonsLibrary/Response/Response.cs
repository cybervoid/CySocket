using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using SocketCommonsLibrary.Extensions;
namespace SocketCommonsLibrary.Response
{
    public class Response : IResponse
    {
        string _ResponseMsg;
        string RequestPayload;
        public Socket SocketHandler { get; set; }
        public Response()
        {
        }
        public Response(string requestPayload)
        {
            this.RequestPayload = requestPayload;
        }
        public Response(string requestPayload, Socket handler) : this(requestPayload)
        {
            this.SocketHandler = handler;
        }
        public void Execute()
        {
            dynamic data = RequestPayload.ToDynamic();
            string value = (string)data.Data;
            _ResponseMsg = string.Format("Text received : {0}", value);
        }

        public string Send()
        {
            return _ResponseMsg;
        }
    }
}
