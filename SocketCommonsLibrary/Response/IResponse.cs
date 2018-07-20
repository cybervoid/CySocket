using System;
using System.Collections.Generic;
using System.Text;

namespace SocketCommonsLibrary.Response
{
    public interface IResponse
    {
        void Execute();
        string Send();
    }
}
