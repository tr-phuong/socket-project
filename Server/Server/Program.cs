using System;
using System.Data;
using System.Net;
using System.Net.Sockets;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Npgsql;
using Server.Config;
using Server.Controllers;
using Server.DTO;
using Server.DTO.Send;
using Server.entities;
using Server.Logs;
using Server.Models;
using Server.Utils;

namespace Server
{
    class Program
    {
        private const int PORT = 11111;
        private const int BUFFER_SIZE = 20480; //20MB

        private Helper helper = new Helper();
        static void Main(string[] args)
        {

            PostgresqlConfig.connection();
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

            UserController userController = new UserController();
            HotelController hotelController = new HotelController();
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
                    byte[] bytes = new Byte[BUFFER_SIZE]; // Data buffer

                    Console.WriteLine("Client starting connect...");

                    bool authentication = false;

                    while (true)
                    {
                        if (exit)
                        {
                            Console.WriteLine("Client close connect...");
                            break;
                        }
                        // clientSocket.Connected

                        int numByte = clientSocket.Receive(bytes);
                        string json = Encoding.UTF8.GetString(bytes, 0, numByte);
                        dynamic dataReceive = JsonConvert.DeserializeObject(json);

                        string actions = dataReceive.action;
                        switch (actions)
                        {
                            case Actions.REGISTER:
                                try {
                                    Log.info(Lever.CLIENT, Actions.REGISTER, json);
                                    UserEntity userReg = dataReceive.data;
                                    var userRegisterSend = userController.register(userReg);

                                    string registerData = JsonConvert.SerializeObject(userRegisterSend);
                                    byte[] registerDataBytes = Encoding.UTF8.GetBytes(registerData);

                                    // Send a data to Client
                                    clientSocket.Send(registerDataBytes);
                                    Log.info(Lever.SERVER, Actions.REGISTER, registerData);
                                }catch(Exception ex) { 
                                    Console.WriteLine(ex.Message); 
                                }
                                break;
                            case Actions.LOGIN:
                                try
                                {
                                    Log.info(Lever.CLIENT, Actions.LOGIN, json);
                                    JObject jobj = dataReceive.data as JObject;
                                    UserLogin userLogin = jobj.ToObject<UserLogin>();
                                    SendData<UserDTO> userLoginSend = userController.login(userLogin);

                                    if (userLoginSend.getFlags() && userLoginSend.action.Equals(Actions.LOGGED))
                                    {
                                        string loggedData = JsonConvert.SerializeObject(userLoginSend);
                                        byte[] loggedDataBytes = Encoding.UTF8.GetBytes(loggedData);

                                        // Send a message to Client
                                        clientSocket.Send(loggedDataBytes);
                                        Log.info(Lever.SERVER, Actions.LOGGED, loggedData);

                                        // Xác nhận đã đăng nhập, client gửi yêu cầu đăng nhập lần tiếp theo sẽ thông báo đã đăng nhập
                                        // Hiển thị danh sách
                                        authentication = true;
                                    }
                                    else
                                    {
                                        // Đã đăng nhập
                                        // Chỉ gửi thông báo đã đăng nhập
                                        if (authentication)
                                        {
                                            SendData<UserDTO> userLoggedSend = userController.logged();
                                            string loggedData = JsonConvert.SerializeObject(userLoggedSend);
                                            byte[] loggedDataBytes = Encoding.UTF8.GetBytes(loggedData);
                                            clientSocket.Send(loggedDataBytes);
                                            Log.info(Lever.SERVER, Actions.LOGGED, loggedData);
                                            break;
                                        }
                                        string loginData = JsonConvert.SerializeObject(userLoginSend);
                                        byte[] loginDataBytes = Encoding.UTF8.GetBytes(loginData);

                                        // Send a message to Client
                                        clientSocket.Send(loginDataBytes);
                                        Log.info(Lever.SERVER, Actions.LOGIN, loginData);
                                    }
                                }
                                catch (Exception ex) {
                                    Console.WriteLine(ex.Message);
                                }
                                break;
                            case Actions.SHOW_LIST:
                                try {
                                    Log.info(Lever.CLIENT, Actions.SHOW_LIST, json);
                                    string name = (string)dataReceive.data;
                                    var listRoomsOfhotel = hotelController.getListRoomsOfHotel(name);

                                    string showListData = JsonConvert.SerializeObject(listRoomsOfhotel);
                                    byte[] showListDataBytes = Encoding.UTF8.GetBytes(showListData);

                                    // Send a message to Client
                                    clientSocket.Send(showListDataBytes);
                                    Log.info(Lever.SERVER, Actions.SHOW_LIST, showListData);
                                } catch(Exception ex) {
                                    Console.WriteLine(ex.Message);
                                }
                                break;
                            case Actions.BOOKING:
                                break;
                            default:
                                break;
                        }

                        //int numByte = clientSocket.Receive(bytes);
                        //dynamic user = JsonConvert.DeserializeObject(Encoding.ASCII.GetString(bytes, 0, numByte));
                        //Console.WriteLine(user.username + " - " + user.password);

                        //byte[] message = Encoding.ASCII.GetBytes("Test Server");

                        //// Send a message to Client
                        //// using Send() method
                        //clientSocket.Send(message);
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
