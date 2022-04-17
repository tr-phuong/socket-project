using Client.entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Receive
{
    public class ReceiveListData
    {
        public string action { get; set; }
        private bool flags { get; set; } = false;
        public string message { get; set; }
        public List<RoomsEntity> listData { get; set; }

        public ReceiveListData() { 
            this.listData = new List<RoomsEntity>();
        }
        public ReceiveListData(string action, string message, List<RoomsEntity> listData)
        {
            this.action = action;
            this.message = message;
            this.listData = listData;
        }

        public ReceiveListData getListRooms(string data)
        {
            var list = JsonConvert.DeserializeObject<ReceiveListData>(data);
            return list;
        }
    }
}
