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
    public class UserModel
    {
        //public UserEntity findById(int id)
        //{
        //    UserEntity user = new UserEntity();
        //    using (NpgsqlConnection con = PostgresqlConfig.getConnection())
        //    {
        //        con.Open();
        //        if (con.State == ConnectionState.Open)
        //        {
        //            string sql = "select * from users;";

        //            using (NpgsqlCommand command = new NpgsqlCommand(sql, con))
        //            {
        //                NpgsqlDataReader reader = command.ExecuteReader();
        //                while (reader.Read())
        //                {
        //                    user.id = reader.GetInt32("id");
        //                    user.username = reader.GetString("username");
        //                    user.bankCardID = reader.GetString("bank_card_ID");
        //                }
        //                reader.Close();
        //            }
        //        }
        //    }
        //    return user;
        //}
        public UserEntity findById(int id)
        {
            UserEntity user = new UserEntity();
            using (NpgsqlConnection con = PostgresqlConfig.getConnection())
            {
                con.Open();
                if (con.State == ConnectionState.Open)
                {
                    string sql = "select * from users;";

                    using (NpgsqlCommand command = new NpgsqlCommand(sql, con))
                    {
                        NpgsqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            user.id = reader.GetInt32("id");
                            user.username = reader.GetString("username");
                            user.bankCardID = reader.GetString("bank_card_ID");
                        }
                        reader.Close();
                    }
                }
            }
            return user;
        }

        public UserEntity findByUsername(string username)
        {
            UserEntity user = null;
            using (NpgsqlConnection con = PostgresqlConfig.getConnection())
            {
                con.Open();
                if (con.State == ConnectionState.Open)
                {
                    string sql = String.Format(@"select u.id, u.username, u.""password"" from users u where u.username = '{0}';", username);

                    using (NpgsqlCommand command = new NpgsqlCommand(sql, con))
                    {
                        NpgsqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            user = new UserEntity();

                            user.id = reader.GetInt32("id");
                            user.username = reader.GetString("username");
                            user.password = reader.GetString("password");
                        }
                        reader.Close();
                    }
                }
            }
            return user;
        }

        public int create(UserEntity user)
        {
            int result = 0;
            using (NpgsqlConnection con = PostgresqlConfig.getConnection())
            {
                con.Open();
                if (con.State == ConnectionState.Open)
                {
                    string sql = String.Format(@"insert into users(username, ""password"", ""bank_card_ID"") values ('{0}','{1}','{2}');",
                        user.username,
                        user.password,
                        user.bankCardID);

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
