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
        public BookEntity findByUserId(string userId)
        {
            BookEntity bookEntity = null;
            using (NpgsqlConnection conn = PostgresqlConfig.getConnection())
            {
                conn.Open();
                if (conn.State == ConnectionState.Open)
                {
                    string sql = String.Format("SELECT b.id, b.user_id, b.total FROM booking b INNER JOIN users u ON b.user_id = u.id WHERE b.user_id = {0} LIMIT 1;", Int32.Parse(userId));
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
        public BookEntity createBook(string userId)
        {
            BookEntity bookEntity = null;
            using (NpgsqlConnection conn = PostgresqlConfig.getConnection())
            {
                conn.Open();
                if (conn.State == ConnectionState.Open)
                {
                    string sql = String.Format("INSERT INTO booking (user_id) VALUES ({0})", Int32.Parse(userId));
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
                            sql += String.Format(@"({0}, {1}, '{2}', '{3}', '{4}', {5}, {6}),",
                                    item.hotelsEntity.id,
                                    item.roomsEntity.id,
                                    item.bookingDate,
                                    item.leavingDate,
                                    (item.note.Equals("")) ? "." : item.note,
                                    bookId,
                                    item.rate);
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

                                    string listRoomIdStr = String.Join("', '", listRoom.Select(s => s.roomsEntity.id).ToList());
                                    string queryUpdateRoom = String.Format("UPDATE rooms SET status = 'HẾT PHÒNG', activate = false WHERE id IN ('{0}')", listRoomIdStr);

                                    using (NpgsqlCommand commUpdate = new NpgsqlCommand(queryUpdateRoom, conn))
                                    {
                                        int rowsUpdate = commUpdate.ExecuteNonQuery();
                                        if (rowsUpdate <= 0) {
                                            throw new Exception("Update fail");
                                        }
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
        public List<BookItemEntity> findAllListHotelBookingHistory(string userId)
        {
            List<BookItemEntity> listroom = new List<BookItemEntity>();
            using (NpgsqlConnection conn = PostgresqlConfig.getConnection())
            {
                conn.Open();
                if (conn.State == ConnectionState.Open)
                {
                    string sql = String.Format(@"
                                    SELECT b.id AS book_id,
                                            b.total,
                                            bi.id AS book_item_id,
                                            h.id AS hotel_id,
                                            h.""name"" AS hotel_name,
                                            r.id AS room_id,
                                            r.room_type,
                                            r.room_rate,
                                            r.poster,
                                            bi.rate,
                                            bi.booking_date,
                                            bi.leaving_date
                                    FROM booking b
                                    JOIN booking_item bi ON b.id = bi.book_id
                                    JOIN hotels h ON h.id = bi.hotel_id
                                    JOIN rooms r ON r.id = bi.room_id AND r.hotel_id = h.id
                                    JOIN users u ON u.id = b.user_id
                                    WHERE u.id = {0}; ", Int32.Parse(userId));

                    using (NpgsqlCommand command = new NpgsqlCommand(sql, conn))
                    {
                        NpgsqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            try {
                                listroom.Add(new BookItemEntity()
                                {
                                    id = reader.GetInt32("book_item_id"),
                                    hotelsEntity = new HotelsEntity()
                                    {
                                        id = reader.GetInt32("hotel_id"),
                                        name = reader.GetString("hotel_name")
                                    },
                                    roomsEntity = new RoomsEntity()
                                    {
                                        id = reader.GetInt32("room_id"),
                                        roomType = reader.GetString("room_type"),
                                        roomRate = reader.GetInt32("room_rate"),
                                        poster = reader.GetString("poster")
                                    },
                                    bookingDate = reader.GetDateTime("booking_date"),
                                    leavingDate = reader.GetDateTime("leaving_date"),
                                    rate = reader.GetInt32("rate"),
                                    book = new BookEntity()
                                    {
                                        total = reader.GetInt64("total")
                                    }
                                });
                            }
                            catch(Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                                throw new Exception(ex.Message);
                            }
                        }
                        reader.Close();
                    }
                }
            }

            return (listroom.Count > 0) ? listroom : null;
        }
        public bool isCancelBookingItem(BookItemEntity bookItemEntity)
        {
            bool isCancel = false;
            using (NpgsqlConnection conn = PostgresqlConfig.getConnection())
            {
                conn.Open();
                if (conn.State == ConnectionState.Open)
                {
                    string sql = String.Format("DELETE FROM booking_item b WHERE b.id = {0} AND b.book_id = {1};", bookItemEntity.id, bookItemEntity.book.id);
                    using (NpgsqlCommand command = new NpgsqlCommand(sql, conn))
                    {
                        try {
                            int rows = command.ExecuteNonQuery();
                            if(rows > 0)
                            {
                                isCancel = true;
                            }
                        }
                        catch (Exception ex)
                        {
                            throw new Exception(ex.Message);
                        }
                       
                    }
                }
            }
            return isCancel;
        }

        public BookItemEntity findBookingItem(int bookingItemId)
        {
            BookItemEntity bookItemEntity = null;
            using (NpgsqlConnection conn = PostgresqlConfig.getConnection())
            {
                conn.Open();
                if (conn.State == ConnectionState.Open)
                {
                    string sql = String.Format("SELECT b.id, b.book_id, b.hotel_id, b.room_id, booking_date, leaving_date, b.created_at FROM booking_item b WHERE b.id = {0};", bookingItemId);
                    using (NpgsqlCommand command = new NpgsqlCommand(sql, conn))
                    {
                        NpgsqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            try
                            {
                                bookItemEntity = new BookItemEntity();
                                bookItemEntity.id = reader.GetInt32("id");
                                bookItemEntity.book.id = reader.GetInt32("book_id");
                                bookItemEntity.hotelsEntity.id = reader.GetInt32("hotel_id");
                                bookItemEntity.roomsEntity.id = reader.GetInt32("room_id");
                                bookItemEntity.bookingDate = reader.GetDateTime("booking_date");
                                bookItemEntity.leavingDate = reader.GetDateTime("leaving_date");
                                bookItemEntity.createdAt = reader.GetDateTime("created_at");
                            }
                            catch (Exception ex)
                            {
                                throw new Exception(ex.Message);
                            }
                        }

                    }
                }
            }
            return bookItemEntity;
        }

    }
}
