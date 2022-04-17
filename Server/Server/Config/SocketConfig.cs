using Newtonsoft.Json;
using Server.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server.Config
{
    public static class SocketConfig
    {
        private const int PORT = 11111;
        private const int BUFFER_SIZE = 1024;
        public static void ExecuteServer()
        {
            // Establish the local endpoint
            // for the socket. Dns.GetHostName
            // returns the name of the host
            // running the application.
            IPHostEntry ipHost = Dns.GetHostEntry(Dns.GetHostName());
            IPAddress ipAddr = ipHost.AddressList[0];
            IPEndPoint localEndPoint = new IPEndPoint(ipAddr, PORT);

            // Creation TCP/IP Socket using
            // Socket Class Constructor
            Socket listener = new Socket(ipAddr.AddressFamily,
                         SocketType.Stream, ProtocolType.Tcp);

            try
            {

                // Using Bind() method we associate a
                // network address to the Server Socket
                // All client that will connect to this
                // Server Socket must know this network
                // Address
                listener.Bind(localEndPoint);

                // Using Listen() method we create
                // the Client list that will want
                // to connect to Server
                listener.Listen(10);

                while (true)
                {

                    Console.WriteLine("Waiting connection ... ");

                    // Suspend while waiting for
                    // incoming connection Using
                    // Accept() method the server
                    // will accept connection of client
                    Socket clientSocket = listener.Accept();

                    bool exit = false;

                    while (true)
                    {
                        //if (clientSocket.Connected)
                        //{

                        //}
                        if (exit)
                            break;
                        // Data buffer
                        byte[] bytes = new Byte[BUFFER_SIZE];

                        int numByte = clientSocket.Receive(bytes);
                        dynamic user = JsonConvert.DeserializeObject(Encoding.ASCII.GetString(bytes, 0, numByte));
                        Console.WriteLine(user.username + " - " + user.password);

                        byte[] message = Encoding.ASCII.GetBytes("Test Server");

                        // Send a message to Client
                        // using Send() method
                        clientSocket.Send(message);
                    }


                    // Close client Socket using the
                    // Close() method. After closing,
                    // we can use the closed Socket
                    // for a new Client Connection
                    clientSocket.Shutdown(SocketShutdown.Both);
                    clientSocket.Close();
                }
            }

            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}
