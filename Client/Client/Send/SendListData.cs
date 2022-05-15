using Client.DTO;
using Client.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Send
{
    public class SendListData
    {
        public string action { get; set; }
        public string message { get; set; }
        public List<BookItemEntity> data { get; set; }

        public SendListData() { }
        public SendListData(string action, string message, List<BookItemEntity> listBookItem)
        {
            this.action = action;
            this.message = message;
            this.data = listBookItem;
        }
    }
}
