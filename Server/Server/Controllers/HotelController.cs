using Server.DTO.Send;
using Server.entities;
using Server.Models;
using Server.Send;
using Server.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Controllers
{
    public class HotelController
    {
        HotelsModel hotelsModel = new HotelsModel();

        public SendListData getListRoomsOfHotel(string name)
        {
            try{
                List<RoomsEntity> rooms = hotelsModel.findAllHotelsByName(name);

                if (rooms == null)
                    return new SendListData(Actions.SHOW_LIST, "Khong co du lieu", new List<RoomsEntity>());

                SendListData result = new SendListData(Actions.SHOW_LIST, Message.SUCCESS, rooms);
                return result;
            } catch(Exception ex) {
                Console.WriteLine(ex.Message);
                return new SendListData(Actions.SHOW_LIST, "Error", new List<RoomsEntity>());
            }
        }
    }
}
