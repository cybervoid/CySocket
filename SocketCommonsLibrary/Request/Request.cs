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

        /// <summary>
        /// converts a string to a payload type
        /// </summary>
        /// <param name="inputData"></param>
        public void ToPayload(string inputData)
        {
            _Payload = Newtonsoft.Json.JsonConvert.DeserializeObject<BasePayload>(inputData);
        }

        /// <summary>
        /// Converts the payload to a json string
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return _Payload.ToString();
        }
    }
}
