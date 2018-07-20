using System;
using System.Collections.Generic;
using System.Text;

namespace SocketCommonsLibrary.Payload
{

    //public abstract class BasePayload
    public abstract class BasePayload : IPayload //where T : IPayload
    {
        public abstract string ToString();
        public abstract BasePayload ToObject(string objectString);
    }
}
