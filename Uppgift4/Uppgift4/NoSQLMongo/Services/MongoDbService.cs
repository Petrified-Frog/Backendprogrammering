using MongoDB.Driver;
using NoSQLMongo.Interfaces;
using NoSQLMongo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoSQLMongo.Services
{
    public class MongoDbService : IBooking
    {
        private readonly IMongoCollection<Guest> _guests;
        private readonly IMongoCollection<Room> _rooms;
        private readonly IMongoCollection<Reservation> _reservations;

        public MongoDbService(IMongoDbClient mongo)
        {
            _guests = mongo.GuestCollection();
            _rooms = mongo.RoomCollection();
            _reservations = mongo.ReservationCollection();
        }

        //**********************Guest******************************
        public Guest CreateGuest(Guest newGuest)
        {
            _guests.InsertOne(newGuest);
            return newGuest;
        }

        public Guest GetGuestById(string id)
        {
            return _guests.Find(guest => guest.GuestId == id).FirstOrDefault();
        }

        public List<Guest> GetAllGuests()
        {
            return _guests.Find(guest => true).ToList();
        }

        public Guest PutGuest(Guest guest)
        {
            return _guests.FindOneAndReplace(g => g.GuestId == guest.GuestId, guest);
        }

        public void DeleteGuest(string id)
        {
            _guests.DeleteOne(guest => guest.GuestId == id);
        }

        //**********************Room******************************
        public Room CreateRoom(Room newRoom)
        {
            _rooms.InsertOne(newRoom);
            return newRoom;
        }

        public Room GetRoomByNr(string roomNr)
        {
            return _rooms.Find(room => room.RoomNr == roomNr).FirstOrDefault();
        }


        //**********************Reservation******************************
        public Reservation CreateReservation(Reservation newReservation)
        {
            _reservations.InsertOne(newReservation);
            return newReservation;
        }

        public List<Reservation> GetAllReservations()
        {
            return _reservations.Find(res => true).ToList();
        }

        public Reservation GetReservationByNr(string reservationNr)
        {
            return _reservations.Find(res => res.ReservationNr == reservationNr).FirstOrDefault();
        }    

        public Reservation PutReservation(Reservation reservation)
        {
            return _reservations.FindOneAndReplace(res => res.ReservationNr == reservation.ReservationNr, reservation);                
        }
    }
}
