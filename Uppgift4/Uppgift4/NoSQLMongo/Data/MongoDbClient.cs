using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using NoSQLMongo.Interfaces;
using NoSQLMongo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoSQLMongo.Data
{
    public class MongoDbClient : IMongoDbClient
    {
        private readonly IMongoCollection<Guest> _guests;
        private readonly IMongoCollection<Room> _rooms;
        private readonly IMongoCollection<Reservation> _reservations;

        public MongoDbClient(IConfiguration config)
        {
            var client = new MongoClient(config.GetSection("MongoDb").GetSection("ConnectionString").Value);
            var db = client.GetDatabase(config.GetSection("MongoDb").GetSection("DatabaseName").Value);
            _guests = db.GetCollection<Guest>(config.GetSection("MongoDb").GetSection("GuestsCollectionName").Value);
            _rooms = db.GetCollection<Room>(config.GetSection("MongoDb").GetSection("RoomsCollectionName").Value);
            _reservations = db.GetCollection<Reservation>(config.GetSection("MongoDb").GetSection("ReservationCollectionName").Value);
        }

        public IMongoCollection<Guest> GuestCollection()
        {
            return _guests;
        }

        public IMongoCollection<Reservation> ReservationCollection()
        {
            return _reservations;
        }

        public IMongoCollection<Room> RoomCollection()
        {
            return _rooms;
        }
    }
}
