using System;
using System.Collections.Generic;
using System.Text;
using SocketCommonsLibrary.Payload;
namespace SocketCommonsLibrary.Request
{
    public class Request
    {
        IPayload _Payload;

        public Request()
        {

        }
        public Request(IPayload payload)
        {
            this._Payload = payload; 
        }

        public void ToPayload(string inputData)
        {
            _Payload = Newtonsoft.Json.JsonConvert.DeserializeObject<BasePayload>(inputData);
        }

        public override string ToString()
        {
            return _Payload.ToString();
        }
    }
}
