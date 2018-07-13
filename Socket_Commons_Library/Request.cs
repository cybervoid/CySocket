using System;

namespace Socket_Commons_Library
{
    public class Request<T>
    {
        Payload<T> _Payload;

        public Request(Payload<T> payload)
        {
            this._Payload = payload;
        }
        public string GetRequest()
        {
            if (_Payload != null)
                return _Payload.ToString();
            return null;
        }
    }
}
