using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.DTO
{
    public class BookItemDTO
    {
        public int id { get; set; }
        public string roomType { get; set; }
        public int roomRate { get; set; }
        public DateTime dateBook { get; set; }
        public DateTime leavingDate { get; set; }
        public string note { get; set; }
        public HotelDTO hotel { get; set; }
        public BookItemDTO()
        {
            hotel = new HotelDTO();
        }
        public BookItemDTO(int id, string roomType, int roomRate, DateTime date, DateTime leavingDate, HotelDTO hotel)
        {
            this.id = id;
            this.roomType = roomType;
            this.roomRate = roomRate;
            this.dateBook = date;
            this.leavingDate = leavingDate;
            this.hotel = hotel;
        }
    }
}
