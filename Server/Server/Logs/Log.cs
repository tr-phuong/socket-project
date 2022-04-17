using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Logs
{
    public class Log
    {
        public static void info(string lever, string action, string data)
        {
            string str = String.Format(@"{0} - LEVER: {1} - ACTION: {2} - Data: {3}", DateTime.Now, lever, action, data);
            Console.WriteLine(str);
        }

    }
}
