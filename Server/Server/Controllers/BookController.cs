using Server.DTO.Send;
using Server.entities;
using Server.Models;
using Server.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Controllers
{
    public class BookController
    {
        private BookModel bookModel = new BookModel();
        public SendData<Int64> addListRoomItem(string data)
        {
            try
            {
                int userId = Helper.getUserId(data);
                List<BookItemEntity> listBookItems = Helper.getlistBookItem(data);
                BookEntity inserted = new BookEntity();
                Int64 total = 0;

                BookEntity find = bookModel.findByUserId(userId);
                if (find  == null)
                {
                    inserted = bookModel.createBook(userId);
                }

                total = bookModel.createBookItems(listBookItems, (find != null) ? find.id : inserted.id);

                SendData<Int64> result = new SendData<Int64>(Actions.BOOKING, Message.SUCCESS, total);
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new SendData<Int64>(Actions.BOOKING, ex.Message, 0);
            }
        }
    }
}
