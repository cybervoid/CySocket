using System;
using System.Collections.Generic;
using System.Text;

namespace Socket_Commons_Library
{
    public class Request
    {
        IPayload _Payload;

        public Request(IPayload payload)
        {
            this._Payload = payload; 
        }

        public string PayloadToString()
        {
            return _Payload.ToString();
        }
    }
}
