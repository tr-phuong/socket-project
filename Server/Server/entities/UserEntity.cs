using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.entities
{
    public class UserEntity
    {
        public int id { get; set; }

        [JsonProperty("username")]
        public string username { get;set; }
        [JsonProperty("password")]
        public string password { get;set; }
        [JsonProperty("bankCardID")]
        public string bankCardID { get; set; }

        public UserEntity() { }
        public UserEntity(string username, string password, string bankCardID)
        {
            this.username = username;
            this.password = password;
            this.bankCardID = bankCardID;
        }
    }
}
