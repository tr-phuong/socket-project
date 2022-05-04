using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.entities
{
    public class HotelsEntity
    {
        public int id { get; set; }
        public string name { get; set; }
        public List<RoomsEntity> rooms { get; set; }

        public HotelsEntity()
        {
            this.rooms = new List<RoomsEntity>();
        }

        public HotelsEntity(int id, string name, List<RoomsEntity> rooms)
        {
            this.id = id;
            this.name = name;
            this.rooms = rooms;
        }
    }
}
