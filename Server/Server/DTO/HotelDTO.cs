using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.DTO
{
    public class HotelDTO
    {
        public int id { get; set; }
        public string name { get; set; }

        public HotelDTO() { }

        public HotelDTO(int id, string name)
        {
            this.id = id;
            this.name = name;
        }
    }
}
