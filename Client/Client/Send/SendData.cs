using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    public class SendData<DTO>
    {
        public string action { get; set; }
        public string message { get; set; }
        public DTO data { get; set; }

        public SendData() { }
        public SendData(string action, string message, DTO data)
        {
            this.action = action;
            this.message = message;
            this.data = data;
        }

        public static SendData<DTO> getObject(string data)
        {
            try
            {
                dynamic result = JsonConvert.DeserializeObject<DTO>(data);
                return result;
            }
            catch(Exception ex) { return new SendData<DTO>(); }
        }

    }
}
