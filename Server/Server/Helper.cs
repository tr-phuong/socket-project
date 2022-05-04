﻿using Newtonsoft.Json;
using Server.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public class Helper
    {
        public static List<BookItemEntity> getlistBookItem(string json)
        {
            dynamic parseJson = JsonConvert.DeserializeObject(json);
            List<BookItemEntity> listBookItems = parseJson.list_book_items;
            return listBookItems;
        }
        public static int getUserId(string json)
        {
            dynamic parseJson = JsonConvert.DeserializeObject(json);
            int userId = parseJson.user_id;
            return userId;
        }
    }
}
