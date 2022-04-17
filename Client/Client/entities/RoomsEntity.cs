using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.entities
{
    public class RoomsEntity
    {
        public int id { get; set; }
        public string roomType { get; set; }
        public int roomRate { get; set; }
        public DateTime dateBook { get; set; }
        public string poster { get; set; }
        public string description { get; set; }
        public string status { get; set; }
        public bool activate { get; set; }
        public RoomsEntity() { }
        public RoomsEntity(int id, string roomType, int roomRate, DateTime date, string poster, string description, string status, bool activate)
        {
            this.id = id;
            this.roomType = roomType;
            this.roomRate = roomRate;
            this.dateBook = date;
            this.poster = poster;
            this.description = description;
            this.status = status;
            this.activate = activate;
        }
    }
}
