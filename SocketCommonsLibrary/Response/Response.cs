using System;
using System.Collections.Generic;
using System.Text;
using SocketCommonsLibrary.Extensions;
namespace SocketCommonsLibrary.Response
{
    public class Response : IResponse
    {

        string _ResponseMsg;
        string RequestPayload;
        public Response()
        {

        }

        public Response(string requestPayload)
        {
            this.RequestPayload = requestPayload;
        }
        public void Execute()
        {
            //dynamic d = new 
            dynamic data = RequestPayload.ToDynamic();
            string number = (string)data.Data;
            _ResponseMsg = string.Format("Text received : {0}", number);
        }

        public string Send()
        {
            return _ResponseMsg;
        }
    }
}
