using Npgsql;
using Server.Config;
using Server.entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Models
{
    public class RoomsModel
    {
        public RoomsEntity findOne(int id)
        {
            RoomsEntity room = null;
            using (NpgsqlConnection conn = PostgresqlConfig.getConnection())
            {
                conn.Open();
                if (conn.State == ConnectionState.Open)
                {
                    string sql = String.Format("select r.id, r.room_type, r.room_rate, r.date_book, r.poster, r.description, r.status, r.activate from rooms r where r.id = {0};", id);

                    using (NpgsqlCommand command = new NpgsqlCommand(sql, conn))
                    {
                        NpgsqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            room = new RoomsEntity();

                            room.id = reader.GetInt32("id");
                            room.roomType = reader.GetString("room_type");
                            room.roomRate = reader.GetInt32("room_rate");
                            room.dateBook = reader.GetDateTime("date_book");
                            room.poster = reader.GetString("poster");
                            room.description = reader.GetString("description");
                            room.status = reader.GetString("status");
                            room.activate = reader.GetBoolean("activate");
                        }
                        reader.Close();
                    }
                }
            }
            return room;
        }
    }
}
