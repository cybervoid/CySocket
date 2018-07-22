using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace CySocket
{
    public class SocketObject
    {
        public SocketType Socket_Type { get; set; }
        public ProtocolType Protocol_Type { get; set; }
        public IPHostEntry Ip_Host_Entry { get; set; }
        public IPAddress Ip_Address { get; set; }
        public IPEndPoint Local_Endpoint { get; set; }
    }
}
