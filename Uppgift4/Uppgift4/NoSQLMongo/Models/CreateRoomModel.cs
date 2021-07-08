using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoSQLMongo.Models
{
    public class CreateRoomModel
    {
        public roomtypes RoomType { get; set; }
        public int Price { get; set; }
    }
}
