using System;
using CySocket;
namespace CyServer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting Server...");

            CySocket.SocketListener.Start();
        }
    }
}
