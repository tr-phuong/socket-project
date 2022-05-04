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
        static void Main(string[] args)
        {
            PostgresqlConfig.connection();
            SocketConfig.StartListening();
        }
       
    }

}
