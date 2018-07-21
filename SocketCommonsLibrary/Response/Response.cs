using System;
using System.Collections.Generic;
using System.Text;

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
            throw new NotImplementedException();
        }

        public string Send()
        {
            throw new NotImplementedException();
        }
    }
}
