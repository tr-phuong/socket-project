using Server.DTO;
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
    public class Rules
    {
        public int hours { get; set; }
        public double percent { get; set; }
    }
    public class BookController
    {
        private BookModel bookModel = new BookModel();
        private const int MAXINUM_ROOMS = 5;
        private const int CHECKIN_TIME = 14;
        private const int CHECKOUT_TIME = 12;

        private static readonly Dictionary<string, Rules> earlyCheckIn = new Dictionary<string, Rules> {
            { "5h-9h", new Rules() { hours = 3, percent = 0.5 } },
            { "9h-14h", new Rules() { hours = 6, percent = 0.3 } }
        };

        private static readonly Dictionary<string, Rules> lateCheckOut = new Dictionary<string, Rules> {
            { "12h-15h", new Rules() { hours = 3, percent = 0.3 } },
            { "15h-18h", new Rules() { hours = 6, percent = 0.5 } },
            { "18h", new Rules() { hours = 7, percent = 1 } }
        };
        private void calculateRateRoom(List<BookItemEntity> listBookItems)
        {
            foreach (var item in listBookItems)
            {
                int hoursBook = Int32.Parse(item.bookingDate.ToString("HH tt"));
                int hoursLeave = Int32.Parse(item.leavingDate.ToString("HH tt"));

                double day = (item.leavingDate - item.bookingDate).TotalDays;

                if (hoursBook <= CHECKIN_TIME && hoursLeave < CHECKOUT_TIME)
                {
                    int dayRound = (int)Math.Round(day);
                    item.rate = item.roomsEntity.roomRate * dayRound;
                }
            }
        }
        public SendData<long> addListRoomItem(BookingDTO data)
        {
            try
            {
                string userId = data.userId;
                List<BookItemEntity> listBookItems = data.listBookItem;
                BookEntity inserted = new BookEntity();
                Int64 total = 0;

                if(listBookItems.Count == 0) return new SendData<long>(Actions.BOOKING, "Hiện không có phòng khách sạn nào được đặt.", 0);
                if(listBookItems.Count > MAXINUM_ROOMS) return new SendData<long>(Actions.BOOKING, String.Format("Chỉ phép đặt tối đa {0} phòng", MAXINUM_ROOMS), 0);
                
                int found = listBookItems.Where(x => x.bookingDate > x.leavingDate).ToList().Count();
                if (found > 0) return new SendData<long>(Actions.BOOKING, "Ngày đặt không được phép lớn hơn ngày rời đi, vui lòng chọn lại", 0);

                var duplicates = listBookItems.GroupBy(s => s).SelectMany(grp => grp.Skip(1)) as BookItemEntity;
                if (duplicates != null) return new SendData<long>(Actions.BOOKING, String.Format("Phòng khách sạn '{0}' đã bị đặt trùng, vui lòng đặt lại.", duplicates.hotelsEntity.name), 0);


                BookEntity find = bookModel.findByUserId(userId);
                if (find  == null)
                {
                    inserted = bookModel.createBook(userId);
                }

                calculateRateRoom(listBookItems);
                total = bookModel.createBookItems(listBookItems, (find != null) ? find.id : inserted.id);

                SendData<long> result = new SendData<long>(Actions.BOOKING, Message.SUCCESS, total);
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new SendData<long>(Actions.BOOKING, ex.Message, 0);
            }
        }

        public SendData<BookingDTO> getListHotelBookingHistory(string userId)
        {
            List<BookItemEntity> bookItemEntities = new List<BookItemEntity>();
            try {
                if(userId.Equals("")) return new SendData<BookingDTO>(Actions.SHOW_HOTEL_BOOKING_HISTORY, "NOT_USER_ID", new BookingDTO());

                bookItemEntities = bookModel.findAllListHotelBookingHistory(userId);
                BookingDTO bookingDTO = new BookingDTO(userId, bookItemEntities);

                return new SendData<BookingDTO>(Actions.SHOW_HOTEL_BOOKING_HISTORY, Message.SUCCESS, bookingDTO);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new SendData<BookingDTO>(Actions.SHOW_HOTEL_BOOKING_HISTORY, ex.Message, new BookingDTO());
            }
        }

        public SendData<bool> cancelBookingItem(int bookingItemId)
        {
            try
            {
                BookItemEntity found = bookModel.findBookingItem(bookingItemId);
                if (found != null)
                {
                    if ((DateTime.Now - found.createdAt).TotalHours <= 24) return new SendData<bool>(Actions.CANCEL_BOOKING_ROOM, "Được hủy phòng trước 24h đặt.", false);
                    if (!bookModel.isCancelBookingItem(found)) return new SendData<bool>(Actions.CANCEL_BOOKING_ROOM, Message.ERROR, false);

                    return new SendData<bool>(Actions.CANCEL_BOOKING_ROOM, Message.SUCCESS, true);
                }
                else {
                    return new SendData<bool>(Actions.CANCEL_BOOKING_ROOM, "Not_found", false);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new SendData<bool>(Actions.CANCEL_BOOKING_ROOM, ex.Message, false);
            }
        }

    }
}
