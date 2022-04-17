using Client.entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Client.Models
{
    public class UserModel
    {
        private const int PORT = 11111;
        public static void ExecuteClient(UserEntity user)
        {

            try
            {
                string data = JsonConvert.SerializeObject(user);
                // Establish the remote endpoint
                // for the socket. This example
                // computer.
                IPHostEntry ipHost = Dns.GetHostEntry(Dns.GetHostName());
                IPAddress ipAddr = ipHost.AddressList[0];
                IPEndPoint localEndPoint = new IPEndPoint(ipAddr, PORT);

                // Creation TCP/IP Socket using
                // Socket Class Constructor
                Socket sender = new Socket(ipAddr.AddressFamily,
                           SocketType.Stream, ProtocolType.Tcp);

                try
                {

                    // Connect Socket to the remote
                    // endpoint using method Connect()
                    sender.Connect(localEndPoint);

                    // We print EndPoint information
                    // that we are connected
                    //Console.WriteLine("Socket connected to -> {0} ",
                    //              sender.RemoteEndPoint.ToString());

                    while (true)
                    {
                        // Creation of message that
                        // we will send to Server
                        byte[] messageSent = Encoding.ASCII.GetBytes(data);
                        int byteSent = sender.Send(messageSent);

                        // Data buffer
                        byte[] receivedData = new byte[1024];

                        // We receive the message using
                        // the method Receive(). This
                        // method returns number of bytes
                        // received, that we'll use to
                        // convert them to string
                        int byteRecv = sender.Receive(receivedData);
                        string dataServerRecv = Encoding.ASCII.GetString(receivedData, 0, byteRecv);

                        ReceiveData<UserEntity> obj = ReceiveData<UserEntity>.getObject(dataServerRecv);


                        if (obj.getFlags())
                        {
                            break;
                        }

                    }

                    // Close Socket using
                    // the method Close()
                    sender.Shutdown(SocketShutdown.Both);
                    sender.Close();
                }

                // Manage of Socket's Exceptions
                catch (ArgumentNullException ane)
                {

                    Console.WriteLine("ArgumentNullException : {0}", ane.ToString());
                }

                catch (SocketException se)
                {

                    Console.WriteLine("SocketException : {0}", se.ToString());
                }

                catch (Exception e)
                {
                    Console.WriteLine("Unexpected exception : {0}", e.ToString());
                }
            }

            catch (Exception e)
            {

                Console.WriteLine(e.ToString());
            }
        }
    }
}
