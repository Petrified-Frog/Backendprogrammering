using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoSQLMongo.Models
{
    public enum paymentMethods { cash, card, blood};
    public class Reservation
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string ReservationNr { get; set; }
        public paymentMethods PaymentMethod { get; set; }
        public string CheckInDate { get; set; }
        public string CheckOutDate { get; set; }
        public string RoomNr { get; set; }
        public string GuestId { get; set; }
    }
}
