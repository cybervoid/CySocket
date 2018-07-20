using System;
using CyClient;
using SocketCommonsLibrary.Payload;
using SocketCommonsLibrary.Request;

namespace CyClientTests
{
    class Program
    {
        static void Main(string[] args)
        {
            SimplePayload payload = new SimplePayload("1");
            Request<SimplePayload> request = new Request<SimplePayload>(payload);
            CyClient.Client.Start(request);
        }
    }
}
