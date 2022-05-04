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
    public class HotelsModel
    {
        public List<RoomsEntity> findAllHotelsByName(string name)
        {
            List<RoomsEntity> listRoomsOfHotel = new List<RoomsEntity>();
            using (NpgsqlConnection con = PostgresqlConfig.getConnection())
            {
                con.Open();
                if (con.State == ConnectionState.Open)
                {
                    string sql = String.Format(@"SELECT r.id AS id, r.room_type, r.room_rate, date_book, r.poster, r.status, r.activate, h.id AS hotel_id, h.""name"" 
                                                FROM hotels h JOIN rooms r ON h.id = r.hotel_id
                                                WHERE h.""name"" ILIKE '%{0}%';", name);

                    using (NpgsqlCommand command = new NpgsqlCommand(sql, con))
                    {
                        NpgsqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            RoomsEntity entity = new RoomsEntity();
                            entity.id = reader.GetInt32("id");
                            entity.roomType = reader.GetString("room_type");
                            entity.roomRate = reader.GetInt32("room_rate");
                            entity.dateBook = reader.GetDateTime("date_book");
                            entity.poster = reader.GetString("poster");
                            entity.status = reader.GetString("status");
                            entity.activate = reader.GetBoolean("activate");
                            entity.hotels.id = reader.GetInt32("hotel_id");
                            entity.hotels.name = reader.GetString("name");

                            listRoomsOfHotel.Add(entity);
                        }
                        reader.Close();
                    }
                }
            }
            return listRoomsOfHotel;
        }

        public int addImage(string name, byte[] data)
        {
            int result = 0;
            using (NpgsqlConnection con = PostgresqlConfig.getConnection())
            {
                con.Open();
                if (con.State == ConnectionState.Open)
                {
                    string sql = String.Format(@"insert into image(""name"", ""data"") values({0}, {1});", name, data);

                    using (NpgsqlCommand command = new NpgsqlCommand(sql, con))
                    {
                       result = command.ExecuteNonQuery();
                    }
                }
            }
            return result;
        }
    }
}
