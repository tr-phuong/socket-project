using Client.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.DTO
{
    public class BookingDTO
    {
        public string userId { get; set; }

        public List<BookItemEntity> listBookItem { get; set; }

        public BookingDTO()
        {
            this.listBookItem = new List<BookItemEntity>(); 
        }
        public BookingDTO(string userId, List<BookItemEntity> listBookItem)
        {
            this.userId = userId;
            this.listBookItem = listBookItem;
        }
    }
}
