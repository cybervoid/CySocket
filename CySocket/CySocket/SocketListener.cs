using System;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace CySocket
{

    public class SocketListener
    {

        //the incoming data from the client
        public static string data = null;
        /// <summary>
        /// Synchronously starts the socket listener
        /// </summary>        
        
        public static void Start()
        {
            Start(SocketType.Stream, ProtocolType.Tcp);
        }
        private static void Start(SocketType socketType, ProtocolType protocolType)
        {
            //data buffer
            byte[] bytes = new byte[1024];
            //establish the local endpoint for the socket
            //dns.GetHostName returns the name of the host running the app
            IPHostEntry iPHostEntry = Dns.GetHostEntry(Dns.GetHostName());
            IPAddress ipAddress = iPHostEntry.AddressList[0];
            IPEndPoint localEndpoint = new IPEndPoint(ipAddress, 8080);

            //create the tcp/ip socket
            Socket listener = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

        }

        //public Task StartAsync()
        //{

        //}
    }
}
