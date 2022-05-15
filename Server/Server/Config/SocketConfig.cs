using Newtonsoft.Json;
using Server.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Server.Controllers;
using Server.DTO;
using Server.DTO.Send;
using Server.entities;
using Server.Logs;
using Server.Models;
using Server.Utils;
using Newtonsoft.Json.Linq;

namespace Server.Config
{
    public static class SocketConfig
    {
        private const int PORT = 11111;
        private const int BUFFER_SIZE = 20480; //20MB
        private static readonly Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        private static readonly List<Socket> clientSockets = new List<Socket>();
        private static readonly byte[] buffer = new byte[BUFFER_SIZE];

        private static Helper helper = new Helper();

        private static UserController userController = new UserController();
        private static HotelController hotelController = new HotelController();
        private static RoomController roomController = new RoomController();
        private static BookController bookController = new BookController();

        public static ManualResetEvent allDone = new ManualResetEvent(false);

        public static void StartListening()
        {
            Console.Title = "Server";
            var read = String.Empty;
            try
            {
                SetupServer();
                Console.WriteLine("Enter any to exit: ", Console.ReadLine());
                //if (read.Equals("exit server".ToLower()) && !read.Equals("")) {
                //    var choose = String.Empty;
                //    do {
                //        Console.Write("YES or NO: ");
                //        choose = Console.ReadLine();
                //        if (choose.Equals("YES".ToLower()) || choose.Equals("YES".ToUpper())){
                //            Console.WriteLine("\nExit!");
                //            CloseAllSockets();
                //            break;
                //        }

                //    }while(true);
                //}

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
        private static void CloseAllSockets()
        {
            foreach (Socket socket in clientSockets)
            {
                socket.Shutdown(SocketShutdown.Both);
                socket.Close();
            }

            serverSocket.Close();
        }
        private static void SetupServer()
        {
            try
            {
                Console.WriteLine("Setting up server...");
                IPHostEntry ipHost = Dns.GetHostEntry(Dns.GetHostName());
                IPAddress ipAddr = ipHost.AddressList[0];
                IPEndPoint localEndPoint = new IPEndPoint(IPAddress.Any, PORT);

                serverSocket.Bind(localEndPoint);
                serverSocket.Listen(0);
                serverSocket.BeginAccept(AcceptCallback, null);
                Console.WriteLine("Server setup complete, waiting for a connection...");
            }
            catch (Exception ex)
            {

            }
        }
        private static void AcceptCallback(IAsyncResult AR)
        {
            Socket socket;

            try
            {
                socket = serverSocket.EndAccept(AR);
            }
            catch (ObjectDisposedException) // I cannot seem to avoid this (on exit when properly closing sockets)
            {
                return;
            }

            clientSockets.Add(socket);
            socket.BeginReceive(buffer, 0, BUFFER_SIZE, SocketFlags.None, ReceiveCallback, socket);
            serverSocket.BeginAccept(AcceptCallback, null);
        }
        private static void closeConnect(Socket current)
        {
            Console.WriteLine("Client forcefully disconnected");
            // Don't shutdown because the socket may be disposed and its disconnected anyway.
            current.Close();
            clientSockets.Remove(current);
            Console.WriteLine("=== Client close connect ===");
        }
        private static void ReceiveCallback(IAsyncResult AR)
        {
            Socket currentClient = (Socket)AR.AsyncState;
            int received;

            try
            {
                received = currentClient.EndReceive(AR);
            }
            catch (SocketException)
            {
                closeConnect(currentClient);
                return;
            }

            bool exit = false;
            bool authentication = false;

            try
            {
                // clientSocket.Connected
                byte[] recBuf = new byte[received];
                Array.Copy(buffer, recBuf, received);
                string json = Encoding.UTF8.GetString(recBuf);
                dynamic dataReceive = JsonConvert.DeserializeObject(json);

                string actions = dataReceive.action;
                switch (actions)
                {
                    case Actions.REGISTER:
                        try
                        {
                            Log.info(Lever.CLIENT, Actions.REGISTER, json);
                            UserEntity userReg = dataReceive.data;
                            var userRegisterSend = userController.register(userReg);

                            string registerData = JsonConvert.SerializeObject(userRegisterSend);
                            byte[] registerDataBytes = Encoding.UTF8.GetBytes(registerData);

                            // Send a data to Client
                            currentClient.Send(registerDataBytes);
                            Log.info(Lever.SERVER, Actions.REGISTER, registerData);
                        }
                        catch (Exception ex)
                        {
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


                                currentClient.Send(loggedDataBytes);
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
                                    currentClient.Send(loggedDataBytes);
                                    Log.info(Lever.SERVER, Actions.LOGGED, loggedData);
                                    break;
                                }
                                string loginData = JsonConvert.SerializeObject(userLoginSend);
                                byte[] loginDataBytes = Encoding.UTF8.GetBytes(loginData);

                                // Send a message to Client
                                currentClient.Send(loginDataBytes);
                                Log.info(Lever.SERVER, Actions.LOGIN, loginData);
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                    case Actions.SHOW_LIST:
                        try
                        {
                            Log.info(Lever.CLIENT, Actions.SHOW_LIST, json);
                            string name = (string)dataReceive.data;
                            var listRoomsOfhotel = hotelController.getListRoomsOfHotel(name);

                            string showListData = JsonConvert.SerializeObject(listRoomsOfhotel);
                            byte[] showListDataBytes = Encoding.UTF8.GetBytes(showListData);

                            // Send a data to Client
                            currentClient.Send(showListDataBytes);
                            Log.info(Lever.SERVER, Actions.SHOW_LIST, showListData);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                    case Actions.BOOKING:
                        try {
                            Log.info(Lever.CLIENT, Actions.BOOKING, json);
                            BookingDTO data = ((JObject)dataReceive?.data).ToObject<BookingDTO>();
                            //BookingDTO data = (BookingDTO)dataReceive.data;

                            var dataSend = bookController.addListRoomItem(data);
                            string dataSendJson = JsonConvert.SerializeObject(dataSend);
                            byte[] dataSendBytes = Encoding.UTF8.GetBytes(dataSendJson);

                            currentClient.Send(dataSendBytes);
                            Log.info(Lever.SERVER, Actions.BOOKING, dataSendJson);
                        }catch (Exception ex) {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                    case Actions.DETAIL_ROOM:
                        try
                        {
                            Log.info(Lever.CLIENT, Actions.DETAIL_ROOM, json);
                            int id = dataReceive.data;
                            var detailRoomSend = roomController.getOne(id);

                            string detailRoomData = JsonConvert.SerializeObject(detailRoomSend);
                            byte[] detailDataBytes = Encoding.UTF8.GetBytes(detailRoomData);

                            // Send a data to Client
                            currentClient.Send(detailDataBytes);
                            Log.info(Lever.SERVER, Actions.DETAIL_ROOM, detailRoomData);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                    case Actions.SHOW_HOTEL_BOOKING_HISTORY:
                        try {
                            Log.info(Lever.CLIENT, Actions.SHOW_HOTEL_BOOKING_HISTORY, json);

                            string userId = (string)dataReceive.data;
                            var listHotelBookingHistory = bookController.getListHotelBookingHistory(userId);

                            string listHotelBookingHistoryJson = JsonConvert.SerializeObject(listHotelBookingHistory);
                            byte[] listHotelBookingHistoryBytes = Encoding.UTF8.GetBytes(listHotelBookingHistoryJson);

                            // Send a data to Client
                            currentClient.Send(listHotelBookingHistoryBytes);
                            Log.info(Lever.SERVER, Actions.SHOW_HOTEL_BOOKING_HISTORY, listHotelBookingHistoryJson);

                        } catch (Exception ex) {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                    case Actions.CANCEL_BOOKING_ROOM:
                        try {
                            Log.info(Lever.CLIENT, Actions.CANCEL_BOOKING_ROOM, json);

                            int bookingItemId = (int)dataReceive?.data;

                            var cancelRoom = bookController.cancelBookingItem(bookingItemId);

                            string cancelRoomJson = JsonConvert.SerializeObject(cancelRoom);
                            byte[] cancelRoomBytes = Encoding.UTF8.GetBytes(cancelRoomJson);

                            // Send a data to Client
                            currentClient.Send(cancelRoomBytes);
                            Log.info(Lever.SERVER, Actions.CANCEL_BOOKING_ROOM, cancelRoomJson);
                        }
                        catch (Exception ex) {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                    case Actions.EXIT:
                        try
                        {
                            Log.info(Lever.CLIENT, Actions.EXIT, json);
                            if (!exit)
                            {
                                exit = true;
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                    default:
                        break;
                }

                if (exit)
                {
                    closeConnect(currentClient);
                    return;
                }

                currentClient.BeginReceive(buffer, 0, BUFFER_SIZE, SocketFlags.None, ReceiveCallback, currentClient);

            }
            catch (Exception ex) { 
                Console.WriteLine(ex.ToString());
                closeConnect(currentClient);
                return;
            }
        }
        //private static void processing(Socket clientSocket)
        //{
        //    bool exit = false;
        //    bool authentication = false;
        //    byte[] bytes = new Byte[BUFFER_SIZE]; // Data buffer

        //    Console.WriteLine(" === Client starting connect... === ");

        //    try
        //    {
        //        while (true)
        //        {
        //            // clientSocket.Connected
        //            buffer, 0, BUFFER_SIZE, SocketFlags.None, ReceiveCallback, socket
        //            int numByte = clientSocket.BeginReceive(bytes, 0, BUFFER_SIZE, SocketFlags.None, );
        //            string json = Encoding.UTF8.GetString(bytes, 0, numByte);
        //            dynamic dataReceive = JsonConvert.DeserializeObject(json);

        //            string actions = dataReceive.action;
        //            switch (actions)
        //            {
        //                case Actions.REGISTER:
        //                    try
        //                    {
        //                        Log.info(Lever.CLIENT, Actions.REGISTER, json);
        //                        UserEntity userReg = dataReceive.data;
        //                        var userRegisterSend = userController.register(userReg);

        //                        string registerData = JsonConvert.SerializeObject(userRegisterSend);
        //                        byte[] registerDataBytes = Encoding.UTF8.GetBytes(registerData);

        //                        // Send a data to Client
        //                        clientSocket.BeginSend(registerDataBytes);
        //                        Log.info(Lever.SERVER, Actions.REGISTER, registerData);
        //                    }
        //                    catch (Exception ex)
        //                    {
        //                        Console.WriteLine(ex.Message);
        //                    }
        //                    break;
        //                case Actions.LOGIN:
        //                    try
        //                    {
        //                        Log.info(Lever.CLIENT, Actions.LOGIN, json);
        //                        JObject jobj = dataReceive.data as JObject;
        //                        UserLogin userLogin = jobj.ToObject<UserLogin>();
        //                        SendData<UserDTO> userLoginSend = userController.login(userLogin);

        //                        if (userLoginSend.getFlags() && userLoginSend.action.Equals(Actions.LOGGED))
        //                        {
        //                            string loggedData = JsonConvert.SerializeObject(userLoginSend);
        //                            byte[] loggedDataBytes = Encoding.UTF8.GetBytes(loggedData);

        //                            // Send a message to Client
        //                            clientSocket.Send(loggedDataBytes);
        //                            Log.info(Lever.SERVER, Actions.LOGGED, loggedData);

        //                            // Xác nhận đã đăng nhập, client gửi yêu cầu đăng nhập lần tiếp theo sẽ thông báo đã đăng nhập
        //                            // Hiển thị danh sách
        //                            authentication = true;
        //                        }
        //                        else
        //                        {
        //                            // Đã đăng nhập
        //                            // Chỉ gửi thông báo đã đăng nhập
        //                            if (authentication)
        //                            {
        //                                SendData<UserDTO> userLoggedSend = userController.logged();
        //                                string loggedData = JsonConvert.SerializeObject(userLoggedSend);
        //                                byte[] loggedDataBytes = Encoding.UTF8.GetBytes(loggedData);
        //                                clientSocket.Send(loggedDataBytes);
        //                                Log.info(Lever.SERVER, Actions.LOGGED, loggedData);
        //                                break;
        //                            }
        //                            string loginData = JsonConvert.SerializeObject(userLoginSend);
        //                            byte[] loginDataBytes = Encoding.UTF8.GetBytes(loginData);

        //                            // Send a message to Client
        //                            clientSocket.Send(loginDataBytes);
        //                            Log.info(Lever.SERVER, Actions.LOGIN, loginData);
        //                        }
        //                    }
        //                    catch (Exception ex)
        //                    {
        //                        Console.WriteLine(ex.Message);
        //                    }
        //                    break;
        //                case Actions.SHOW_LIST:
        //                    try
        //                    {
        //                        Log.info(Lever.CLIENT, Actions.SHOW_LIST, json);
        //                        string name = (string)dataReceive.data;
        //                        var listRoomsOfhotel = hotelController.getListRoomsOfHotel(name);

        //                        string showListData = JsonConvert.SerializeObject(listRoomsOfhotel);
        //                        byte[] showListDataBytes = Encoding.UTF8.GetBytes(showListData);

        //                        // Send a data to Client
        //                        clientSocket.Send(showListDataBytes);
        //                        Log.info(Lever.SERVER, Actions.SHOW_LIST, showListData);
        //                    }
        //                    catch (Exception ex)
        //                    {
        //                        Console.WriteLine(ex.Message);
        //                    }
        //                    break;
        //                case Actions.BOOKING:
        //                    Log.info(Lever.CLIENT, Actions.BOOKING, json);
        //                    //Dictionary<int, Int64> map = new Dictionary<int, Int64>();
        //                    string data = dataReceive.data.toList();

        //                    var dataSend = bookController.addListRoomItem(data);
        //                    string dataSendJson = JsonConvert.SerializeObject(dataSend);
        //                    byte[] dataSendBytes = Encoding.UTF8.GetBytes(dataSendJson);

        //                    clientSocket.Send(dataSendBytes);
        //                    Log.info(Lever.SERVER, Actions.BOOKING, dataSendJson);
        //                    break;
        //                case Actions.DETAIL_ROOM:
        //                    try
        //                    {
        //                        Log.info(Lever.CLIENT, Actions.DETAIL_ROOM, json);
        //                        int id = dataReceive.data;
        //                        var detailRoomSend = roomController.getOne(id);

        //                        string detailRoomData = JsonConvert.SerializeObject(detailRoomSend);
        //                        byte[] registerDataBytes = Encoding.UTF8.GetBytes(detailRoomData);

        //                        // Send a data to Client
        //                        clientSocket.Send(registerDataBytes);
        //                        Log.info(Lever.SERVER, Actions.DETAIL_ROOM, detailRoomData);
        //                    }
        //                    catch (Exception ex)
        //                    {
        //                        Console.WriteLine(ex.Message);
        //                    }
        //                    break;
        //                case Actions.EXIT:
        //                    try
        //                    {
        //                        Log.info(Lever.CLIENT, Actions.EXIT, json);
        //                        if (!exit)
        //                        {
        //                            exit = true;
        //                        }
        //                    }
        //                    catch (Exception ex)
        //                    {
        //                        Console.WriteLine(ex.Message);
        //                    }
        //                    break;
        //                default:
        //                    break;
        //            }

        //            if (exit)
        //            {
        //                Console.WriteLine("=== Client close connect ===");
        //                break;
        //            }

        //            //int numByte = clientSocket.Receive(bytes);
        //            //dynamic user = JsonConvert.DeserializeObject(Encoding.ASCII.GetString(bytes, 0, numByte));
        //            //Console.WriteLine(user.username + " - " + user.password);

        //            //byte[] message = Encoding.ASCII.GetBytes("Test Server");

        //            //// Send a message to Client
        //            //// using Send() method
        //            //clientSocket.Send(message);
        //        }


        //        // Close client Socket using the
        //        // Close() method. After closing,
        //        // we can use the closed Socket
        //        // for a new Client Connection
        //        clientSocket.Shutdown(SocketShutdown.Both);
        //        clientSocket.Close();
        //    }
        //    catch (Exception ex) { Console.WriteLine(ex.ToString()); }
        //}
    }
}
