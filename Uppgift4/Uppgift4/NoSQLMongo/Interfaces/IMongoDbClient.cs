using MongoDB.Driver;
using NoSQLMongo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoSQLMongo.Interfaces
{
    public interface IMongoDbClient
    {
        IMongoCollection<Guest> GuestCollection();
        IMongoCollection<Room> RoomCollection();
        IMongoCollection<Reservation> ReservationCollection();
    }
}
