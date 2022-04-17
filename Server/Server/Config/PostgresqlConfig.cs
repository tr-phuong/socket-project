using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace Server.Config
{
    public class PostgresqlConfig
    {
        public static void connection()
        {
            using (NpgsqlConnection con = getConnection())
            {
                con.Open();
                if (con.State == ConnectionState.Open)
                {
                    Console.WriteLine("Successfully connected to PostgreSQL.");
                }
            }
        }

        public static NpgsqlConnection getConnection()
        {
            NpgsqlConnection conn = new NpgsqlConnection(@"Server=localhost;Port=5432;User Id=postgres;Password=postgres;Database=E-BOOKING;");
            return conn;
        }
    }
}
