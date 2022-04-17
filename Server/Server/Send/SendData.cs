using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.DTO.Send
{
    public class SendData<DTO>
    {
        public string action { get; set; }
        private bool flags { get; set; } = false;
        public string message { get; set; }
        public DTO data { get; set; }

        public SendData(string action, string message, DTO data)
        {
            this.action = action;
            this.message = message;
            this.data = data;
        }

        public SendData<DTO> getObject(string data)
        {
            dynamic user = JsonConvert.DeserializeObject<DTO>(data);
            return user;
        }

        public void setFlags()
        {
            this.flags = true;
        }
        public bool getFlags()
        {
            return flags;
        }
    }
}
