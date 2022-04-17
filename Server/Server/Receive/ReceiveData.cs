using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.DTO
{
    public class ReceiveData<DTO>
    {
        [JsonProperty("action")] public string action { get; set; }
        [JsonProperty("message")] public string message { get; set; }
        [JsonProperty("data")] public DTO data { get; set; }

        public ReceiveData(string action, string message, DTO data)
        {
            this.action = action;
            this.message = message;
            this.data = data;
        }

        public ReceiveData<DTO> getObject(string data)
        {
            dynamic user = JsonConvert.DeserializeObject<DTO>(data);
            return user;
        }
    }
}
