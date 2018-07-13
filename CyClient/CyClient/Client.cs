using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Text;
using Socket_Commons_Library;

namespace CyClient
{
    public class Client
    {
        public void Start<T>(IRequest<T> request)
        {
            Start(request, SocketType.Stream, ProtocolType.Tcp);
        }

        public void Start<T>(IRequest<T> request, SocketType socketType, ProtocolType protocolType)
        {
            // Data buffer for incoming data.  
            byte[] bytes = new byte[1024];

            // Connect to a remote device.  
            try
            {
                // Establish the remote endpoint for the socket.  
                // This example uses port 11000 on the local computer.  
                IPHostEntry ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());
                IPAddress ipAddress = IPAddress.Parse("127.0.0.1");//ipHostInfo.AddressList[0];
                IPEndPoint remoteEP = new IPEndPoint(ipAddress, 8080);

                // Create a TCP/IP  socket.  
                Socket sender = new Socket(ipAddress.AddressFamily, socketType, protocolType);

                try
                {
                    sender.Connect(remoteEP);
                    Console.WriteLine($"Socket connected to {sender.RemoteEndPoint}");
                    byte[] msg = Encoding.ASCII.GetBytes($"{request.ToString()}<EOF>");
                    //send the data through the socket
                    int bytesSent = sender.Send(msg);
                    //receive the response from the remote device.
                    int bytesRec = sender.Receive(bytes);
                    Console.WriteLine($"Echoed test = {Encoding.ASCII.GetString(bytes, 0, bytesRec)}");
                    sender.Shutdown(SocketShutdown.Both);
                    sender.Close();

                }
                catch(ArgumentNullException argsNullEx)
                {
                    Console.WriteLine($"Argument null exception {argsNullEx}");
                }
                catch(SocketException socketException)
                {
                    Console.WriteLine($"SocketException : {socketException}");
                }
                catch(Exception ex)
                {
                    Console.WriteLine($"Unexpected exception caught {ex}");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Unexpected (outer) exception caught {e}");
            }
        }
    }



    // State object for receiving data from remote device.  
    public class StateObject
    {
        // Client socket.  
        public Socket workSocket = null;
        // Size of receive buffer.  
        public const int BufferSize = 256;
        // Receive buffer.  
        public byte[] buffer = new byte[BufferSize];
        // Received data string.  
        public StringBuilder sb = new StringBuilder();
    }
}
