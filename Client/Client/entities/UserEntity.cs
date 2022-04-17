using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.entities
{
    public class UserEntity
    {
        public int id { get; set; } 
        public string username { get; set; }
        public string password { get; set; }
        public string bankCardId { get; set; }

        public UserEntity() { }

        public UserEntity(string username, string password, string bankCardId)
        {
            this.username = username;
            this.password = password;
            this.bankCardId = bankCardId;
        }
    }
}
