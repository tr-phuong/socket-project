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
    public class BookModel
    {
        public List<BookEntity> FindByUserId(int userId)
        {
            List<BookEntity> listBook = new List<BookEntity>();
            using (NpgsqlConnection conn = PostgresqlConfig.getConnection())
            {
                conn.Open();
                if (conn.State == ConnectionState.Open)
                {
                    string sql = String.Format(@"
                                    select b.id as book_id,
                                            b.total,
                                            bi.id as book_item_id,
                                            h.id as hotel_id,
                                            h.""name"" as hotel_name,
                                            r.id as room_id,
                                            r.room_type, 
                                            r.room_rate,
                                            r.poster, u.id,
                                            u.username, 
                                            bi.rate
                                    from booking b
                                    join booking_item bi on b.id = bi.book_id
                                    join hotels h on h.id = bi.hotel_id
                                    join rooms r on r.id = bi.room_id and r.hotel_id = h.id
                                    join users u on u.id = b.user_id
                                    where u.id = {0}; ", userId);

                    using (NpgsqlCommand command = new NpgsqlCommand(sql, conn))
                    {
                        NpgsqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            //if(bookEntity.id == reader.GetInt32("book_id"))
                            //{
                            //    bookEntity = new BookEntity();
                            //}
                            //entity.id = reader.GetInt32("id");
                            //entity.roomType = reader.GetString("room_type");
                            //entity.roomRate = reader.GetInt32("room_rate");
                            //entity.dateBook = reader.GetDateTime("date_book");
                            //entity.poster = reader.GetString("poster");
                            //entity.status = reader.GetString("status");
                            //entity.activate = reader.GetBoolean("activate");

                            //listRoomsOfHotel.Add(entity);
                        }
                        reader.Close();
                    }
                }
            }
            return listBook;
        }
        public BookEntity findByUserId(int userID)
        {
            BookEntity bookEntity = null;
            using (NpgsqlConnection conn = PostgresqlConfig.getConnection())
            {
                conn.Open();
                if (conn.State == ConnectionState.Open)
                {
                    string sql = String.Format("SELECT id, user_id, total FROM booking WHERE user_id = {0} LIMIT 1", userID);
                    using (NpgsqlCommand command = new NpgsqlCommand(sql, conn))
                    {
                        NpgsqlDataReader reader = command.ExecuteReader();
                        while (reader.Read()) {
                            try {
                                bookEntity = new BookEntity();
                                bookEntity.id = reader.GetInt32("id");
                                bookEntity.user.id = reader.GetInt32("user_id");
                                bookEntity.total = reader.GetInt64("total");
                            }
                            catch (Exception ex) { throw new Exception(ex.Message); }
                        }
                    }
                }
            }
            return bookEntity;
        }
        public BookEntity createBook(int userId)
        {
            BookEntity bookEntity = null;
            using (NpgsqlConnection conn = PostgresqlConfig.getConnection())
            {
                conn.Open();
                if (conn.State == ConnectionState.Open)
                {
                    string sql = String.Format("INSERT INTO booking (user_id) VALUE ({0})", userId);
                    using (NpgsqlCommand command = new NpgsqlCommand(sql, conn))
                    {
                        NpgsqlDataReader reader = command.ExecuteReader();
                        while (reader.Read()) {
                            try{
                                bookEntity = new BookEntity();
                                bookEntity.id = reader.GetInt32("id");
                                bookEntity.user.id = reader.GetInt32("user_id");
                            } catch (Exception ex) { throw new Exception(ex.Message); }
                        }
                    }
                }
            }
            return bookEntity;
        }
        public int createBookItems(List<BookItemEntity> listRoom, int bookId)
        {
            int total = 0;
            using (NpgsqlConnection conn = PostgresqlConfig.getConnection())
            {
                conn.Open();
                if (conn.State == ConnectionState.Open)
                {
                    if(listRoom.Count > 0)
                    {

                        Dictionary<int, Int64> map = new Dictionary<int, Int64>();
                        string sql = "INSERT INTO booking_item(hotel_id, room_id, booking_date, leaving_date, note, book_id, rate) VALUES";
                        foreach (BookItemEntity item in listRoom)
                        {
                            sql += String.Format(@"({0}, {1}, {2}, {3}, {4}, {5}, {6}),",
                                    item.hotelsEntity.id,
                                    item.roomsEntity.id,
                                    item.bookingDate,
                                    item.leavingDate,
                                    item.note,
                                    bookId,
                                    item.rate);
                            //if (!map.ContainsKey(item.book.id))
                            //{
                            //    map.Add(item.book.id, 0);
                            //}
                            //map[item.book.id] += item.rate;
                        }
                        sql = sql.Remove(sql.Length - 1);

                        using (NpgsqlCommand command = new NpgsqlCommand(sql, conn))
                        {
                            try
                            {
                                int rows = command.ExecuteNonQuery();
                                if(rows > 0)
                                {
                                    string querySQL = String.Format(@"SELECT sum(bi.rate) as total FROM booking_item bi WHERE bi.book_id = {0}", bookId);
                                    using (NpgsqlCommand comm = new NpgsqlCommand(querySQL, conn))
                                    {
                                        total = Convert.ToInt32(comm.ExecuteScalar());
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                throw new Exception(ex.Message);
                            }


                        }
                    }
                    
                }
            }
            return total;
        }
    }
}
