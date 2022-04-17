using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.DTO
{
    public class UserLogin
    {
        public string username { get; set; }
        public string password { get; set; }

        public UserLogin() { }

        public UserLogin(string username, string password)
        {
            this.username = username;
            this.password = password;
        }
    }
}
