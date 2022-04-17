using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    public class ReceiveData<DTO>
    {
        public string action { get; set; }
        private bool flags { get; set; } = false;
        public string message { get; set; }
        public DTO data { get; set; }

        public ReceiveData() { }
        public ReceiveData(string action, string message, DTO data)
        {
            this.action = action;
            this.message = message;
            this.data = data;
        }

        public static ReceiveData<DTO> getObject(string data)
        {
            dynamic result = JsonConvert.DeserializeObject<DTO>(data);
            return result;
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
