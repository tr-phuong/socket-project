using Newtonsoft.Json;
using Server.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Send
{
    public class SendListData
    {
        public string action { get; set; }
        private bool flags { get; set; } = false;
        public string message { get; set; }
        public List<RoomsEntity> listData { get; set; }

        public SendListData(string action, string message, List<RoomsEntity> listData)
        {
            this.action = action;
            this.message = message;
            this.listData = listData;
        }

        public SendListData getListObject(string data)
        {
            dynamic obj = JsonConvert.DeserializeObject<RoomsEntity>(data);
            return obj;
        }
    }
}
