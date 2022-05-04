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
    public class RoomController
    {
        private static RoomsModel roomsModel = new RoomsModel();
        public SendData<RoomsEntity> getOne(int id)
        {
            try
            {
                RoomsEntity room = roomsModel.findOne(id);

                if (room == null)
                    return new SendData<RoomsEntity>(Actions.DETAIL_ROOM, "Khong co du lieu", new RoomsEntity());

                SendData<RoomsEntity> result = new SendData<RoomsEntity>(Actions.DETAIL_ROOM, Message.SUCCESS, room);
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new SendData<RoomsEntity>(Actions.SHOW_LIST, "Error", new RoomsEntity());
            }
        }
    }
}
