using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoSQLMongo.Models
{
    public enum roomtypes { single, @double, luxury};
    public class Room
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string RoomNr { get; set; }
        public roomtypes RoomType { get; set; }
        public int Price { get; set; }
    }
}
