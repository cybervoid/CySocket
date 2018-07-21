using System;
using System.Collections.Generic;
using System.Text;

namespace SocketCommonsLibrary.Payload
{

    //public abstract class BasePayload
    public class BasePayload : IPayload //where T : IPayload
    {
        public virtual string Data { get; set; }
        public virtual string ToString()
        {
            throw new NotImplementedException();
        }
        public virtual BasePayload ToObject(string objectString)
        {
            throw new NotImplementedException();
        }
    }
}
