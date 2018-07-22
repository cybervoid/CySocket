using SocketCommonsLibrary.Payload;
using SocketCommonsLibrary.Request;
using SocketCommonsLibrary.Response;
using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
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
        static bool start = true;

        #region tasking
        Task _requestTask;
        CancellationToken _requestCancellationToken;
        Task _responseTask;
        CancellationToken _responseCancellationToken;
        public static ConcurrentQueue<Request> _RequestQueue { get; set; } = new ConcurrentQueue<Request>();
        public static ConcurrentQueue<Response> _ResponseQueue { get; set; } = new ConcurrentQueue<Response>();
        #endregion

        #region Socket Settings
        private static SocketObject SocketObj { get; set; }
        #endregion
        public void Initialize(SocketObject socketObj)
        {
            SocketObj = socketObj;
        }
        public void Initialize()
        {
            if (SocketObj == null)
            {
                SocketObj.Socket_Type = SocketType.Stream;
                SocketObj.Protocol_Type = ProtocolType.Tcp;
                SocketObj.Ip_Host_Entry = Dns.GetHostEntry(Dns.GetHostName());
                SocketObj.Port = 8080;
                SocketObj.Ip_Address = IPAddress.Parse("127.0.0.1");
                SocketObj.Local_Endpoint = new IPEndPoint(SocketObj.Ip_Address, SocketObj.Port);
            }
            Console.WriteLine($"listening at endpoint: {SocketObj.Local_Endpoint.ToString()}");
            //create the tcp/ip socket
            _requestCancellationToken = new CancellationToken();
            _requestTask = Task.Factory.StartNew(() => StartListener(), _requestCancellationToken);
        }

        public void Terminate()
        {
            //RequestTask.
        }

        private void StartListener()
        {
            SocketObj.Listener = new Socket(SocketObj.Ip_Address.AddressFamily, SocketObj.Socket_Type, SocketObj.Protocol_Type);
            byte[] bytes = new byte[1024];
            try
            {
                SocketObj.Listener.Bind(SocketObj.Local_Endpoint);
                SocketObj.Listener.Listen(10);
                while(_requestTask.IsCanceled == false)
                {
                    try
                    {
                        Console.WriteLine("Awaiting Connection... ");
                        Socket handler = SocketObj.Listener.Accept();

                        if (handler == null)
                        {
                            System.Threading.Thread.Sleep(10);
                        }
                        else
                        {
                            data = null;
                            // an incoming connection needs to be processed
                            while (true)
                            {
                                int bytesRec = handler.Receive(bytes);
                                data += Encoding.ASCII.GetString(bytes, 0, bytesRec);

                                if (data.IndexOf("<EOF>") > -1)
                                    break;
                            }
                            Request request = new Request(data);
                            _RequestQueue.Enqueue(request);
                        }
                    }
                    catch(Exception e)
                    {
                        Console.WriteLine(e);
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private void StartResponder()
        {

        }

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

            IPAddress ipAddress = IPAddress.Parse("127.0.0.1");//ipHostInfo.AddressList[0];
            IPEndPoint localEndpoint = new IPEndPoint(ipAddress, 8080);
            Console.WriteLine($"endpoint: {localEndpoint.ToString()}");
            //create the tcp/ip socket
            Socket listener = new Socket(ipAddress.AddressFamily, socketType, protocolType);

            // bind the socket to the local endpoint and listen for incoming connections
            try
            {
                listener.Bind(localEndpoint);
                listener.Listen(10);

                //start listening for connections

                while(start == true)
                {
                    Console.WriteLine("Awaiting Connection... ");
                    Socket handler = listener.Accept();

                    data = null;

                    // an incoming connection needs to be processed
                    while(true)
                    {
                        int bytesRec = handler.Receive(bytes);
                        data += Encoding.ASCII.GetString(bytes, 0, bytesRec);

                        if (data.IndexOf("<EOF>") > -1)
                            break;
                    }

                    Request request = new Request(data);
                    _RequestQueue.Enqueue(request);

                    //cast input to payload object
                    Response response = new Response(data);

                    response.Execute();
                    //show the data on the console
                    byte[] msg = Encoding.ASCII.GetBytes(response.Send());                    
                    handler.Send(msg);
                    handler.Shutdown(SocketShutdown.Both);
                    handler.Close();

                }

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }

            Console.WriteLine("\nPress any key to continue... ");
            Console.Read();
        }
    }
}
