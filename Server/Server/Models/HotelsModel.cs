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
                    string sql = String.Format(@"select * from hotels h join rooms r on h.id = r.hotel_id where h.""name"" ILIKE '%{0}%';", name);

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
