using System;
using System.Collections.Generic;
using System.Text;
using SocketCommonsLibrary.Payload;
namespace SocketCommonsLibrary.Request
{
    public class Request<T> : IPayload where T : IPayload
    {
        IPayload _Payload;

        public Request()
        {

        }
        public Request(T payload)
        {
            this._Payload = payload; 
        }

        public void ToPayload<T>(string inputData)
        {
            _Payload = (IPayload)Newtonsoft.Json.JsonConvert.DeserializeObject<T>(inputData);
        }

        public override string ToString()
        {
            return _Payload.ToString();
        }
    }
}
