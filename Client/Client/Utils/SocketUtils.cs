using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Client.entities;
using Client.Receive;
using Client.DTO;

namespace Client.Utils
{
    public class SocketUtils
    {
        private const int PORT = 11111;

        private const int BUFFER_SIZE = 20480; // 20MB

        private static Socket socket;

        private static byte[] buffer = new byte[BUFFER_SIZE]; // Data buffer

        public static void connection()
        {
            // Establish the remote endpoint
            // for the socket. This example
            // computer.
            IPHostEntry ipHost = Dns.GetHostEntry(Dns.GetHostName());
            IPAddress ipAddr = ipHost.AddressList[0];
            IPEndPoint localEndPoint = new IPEndPoint(ipAddr, PORT);

            // Creation TCP/IP Socket using
            // Socket Class Constructor
            socket = new Socket(ipAddr.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            try
            {

                // Connect Socket to the remote
                // endpoint using method Connect()
                socket.Connect(localEndPoint);
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
        public static ReceiveListData receiveListRooms()
        {
            ReceiveListData receiveListData = new ReceiveListData();
            int byteRecv = socket.Receive(buffer);
            string dataServerRecv = Encoding.UTF8.GetString(buffer, 0, byteRecv);
            ReceiveListData list = receiveListData.getListRooms(dataServerRecv);
            return list;
        }
        public static ReceiveData<UserDTO> receiveUser()
        {
            int byteRecv = socket.Receive(buffer);
            string dataServerRecv = Encoding.UTF8.GetString(buffer, 0, byteRecv);
            ReceiveData<UserDTO> obj = ReceiveData<UserDTO>.getObject(dataServerRecv);
            return obj;
        }
        public static int send(SendData<UserEntity> sendData)
        {
            string data = JsonConvert.SerializeObject(sendData);
            // Creation of message that
            // we will send to Server
            byte[] byteSent = Encoding.UTF8.GetBytes(data);
            int byteSentNum = socket.Send(byteSent);
            return byteSentNum;
            //dynamic dataSend = JsonConvert.DeserializeObject(Encoding.ASCII.GetString(buffer, 0, byteSentNum));
            //SendData<UserEntity> send = SendData<UserEntity>.getObject(dataSend);
            //return send;
        }
        public static int sendUserLogin(SendData<UserLogin> sendData)
        {
            string data = JsonConvert.SerializeObject(sendData);
            // Creation of message that
            // we will send to Server
            byte[] byteSent = Encoding.UTF8.GetBytes(data);
            int byteSentNum = socket.Send(byteSent);
            return byteSentNum;
            //dynamic dataSend = JsonConvert.DeserializeObject(Encoding.ASCII.GetString(buffer, 0, byteSentNum));
            //SendData<UserEntity> send = SendData<UserEntity>.getObject(dataSend);
            //return send;
        }

        public static int send(SendData<String> sendData)
        {
            string data = JsonConvert.SerializeObject(sendData);
            // Creation of message that
            // we will send to Server
            byte[] byteSent = Encoding.UTF8.GetBytes(data);
            int byteSentNum = socket.Send(byteSent);
            return byteSentNum;
            //dynamic dataSend = JsonConvert.DeserializeObject(Encoding.ASCII.GetString(buffer, 0, byteSentNum));
            //SendData<UserEntity> send = SendData<UserEntity>.getObject(dataSend);
            //return send;
        }
        public static void close()
        {
            try
            {
                // Close Socket using
                // the method Close()
                socket.Shutdown(SocketShutdown.Both);
                socket.Close();
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
        public static void ExecuteClient(Object ob)
        {

            try
            {
                string data = JsonConvert.SerializeObject(ob);
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

                        ReceiveData<Object> obj = ReceiveData<Object>.getObject(dataServerRecv);


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
