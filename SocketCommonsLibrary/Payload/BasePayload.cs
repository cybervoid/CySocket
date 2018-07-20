using System;
using System.Collections.Generic;
using System.Text;

namespace SocketCommonsLibrary.Payload
{

    //public abstract class BasePayload
    public abstract class BasePayload<T> : IPayload where T : IPayload
    {
        public abstract string ToString<T>();
        public abstract T ToObject(string objectString);
    }
}
