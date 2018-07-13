using System;
using System.Collections.Generic;
using System.Text;

namespace Socket_Commons_Library
{
    /// <summary>
    /// As dynamic data type
    /// </summary>
    public interface IResponse<T>
    {
        string response { get; set; }
        void Process(IRequest<T> request);
        string ToString();
    }
}
