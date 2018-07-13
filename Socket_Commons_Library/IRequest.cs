using System;

namespace Socket_Commons_Library
{
    public interface IRequest<T>
    {
        Payload<T> Payload { get; set; }
        T GetPayload();
        string ToString();
    }
}
