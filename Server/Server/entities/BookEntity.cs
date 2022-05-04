using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.entities
{
    public class BookEntity
    {
        public int id { get; set; }
        public UserEntity user { get; set; }
        public Int64 total { get; set; }
        public DateTime createdAt { get; set; }
        List<BookItemEntity> listBookItems { get; set; } 
        public BookEntity() {
            user = new UserEntity(); 
            listBookItems = new List<BookItemEntity>();
        }
        public BookEntity(int id, UserEntity user, Int64 total, DateTime createdAt)
        {
            this.id = id;
            this.user = user;
            this.total = total;
            this.createdAt = createdAt;
        }
    }
}
