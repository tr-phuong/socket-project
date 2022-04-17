using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Receive
{
    public class ReceiveListData
    {
        public string action { get; set; }
        private bool flags { get; set; } = false;
        public string message { get; set; }
        public string data { get; set; }

        public ReceiveListData(string action, string message, string data)
        {
            this.action = action;
            this.message = message;
            this.data = data;
        }
    }
}
