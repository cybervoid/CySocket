using System;

namespace Socket_Commons_Library
{
    public interface IRequest
    {
        Payload<T> GetPayload<T>();
    }
}
