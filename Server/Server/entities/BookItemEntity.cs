using Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.entities
{
    public class BookItemEntity
    {
        public int id { get; set; }
        public HotelsEntity hotelsEntity { get; set; }
        public RoomsEntity roomsEntity { get; set; }
        public BookEntity book { get; set; }
        public DateTime bookingDate { get; set; }
        public DateTime leavingDate { get; set; }
        public string note { get; set; }
        public DateTime createdAt { get; set; }
        public int rate { get; set; }
        public BookItemEntity() {
            hotelsEntity = new HotelsEntity();
            roomsEntity = new RoomsEntity();
            book = new BookEntity();
        }
        public BookItemEntity(int id, HotelsEntity hotelsEntity, RoomsEntity roomsEntity, BookEntity book,
            DateTime bookngDate, DateTime leavingDate, string note, DateTime createdAt, int rate)
        {
            this.id = id;
            this.hotelsEntity = hotelsEntity;
            this.roomsEntity = roomsEntity;
            this.book = book;
            this.bookingDate = bookngDate;
            this.leavingDate = leavingDate;
            this.note = note;
            this.createdAt = createdAt;
            this.rate = rate;
        }
    }
}
