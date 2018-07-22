using System;
using CySocket;
using System.Threading;
namespace CyServer
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Starting Server...");

            //create the socket thread
            Thread socketThread = new Thread(StartSocket);
            socketThread.IsBackground = true;
            socketThread.Start();

        }

        

        public static void StartSocket()
        {
            CySocket.SocketListener.Start();
        }
    }
}
