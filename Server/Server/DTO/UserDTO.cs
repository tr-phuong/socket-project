using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.DTO
{
    public class UserDTO
    {
        public int id { get; set; }
        public string username { get; set; }

        public UserDTO() { }
        public UserDTO(int id, string username)
        {
            this.id = id;
            this.username = username;
        }
    }
}
