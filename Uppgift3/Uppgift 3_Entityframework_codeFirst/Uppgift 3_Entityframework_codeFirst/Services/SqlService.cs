using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uppgift_3_Entityframework_codeFirst.Data;
using Uppgift_3_Entityframework_codeFirst.Models;

//add-migration
//Update-Database

namespace Uppgift_3_Entityframework_codeFirst.Services
{
    public class SqlService
    {
        private DataContext _context;

        public SqlService()
        {
            _context = new DataContext();
        }

        public Guest CreateGuest(string firstName, string lastName, string email)
        {
            var newGuest = new Guest()
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email
            };
            var newID = _context.Guests.Add(newGuest).Entity.ID;
            _context.SaveChanges();
            Console.WriteLine("Guest created");
            return newGuest;
        }

        public Room CreateRoom(Room.roomTypes roomType, decimal price)
        {
            var newRoom = new Room() { RoomType = roomType, Price = price };
            _context.Rooms.Add(newRoom);
            _context.SaveChanges();
            return newRoom;
        }

        public Reservation CreateReservation(Guest guest, Room room, DateTime checkinDate, DateTime checkoutDate, Reservation.paymentMethods payment) {
                               
            var newReservation = new Reservation()
            {
                CheckinDate = checkinDate,
                CheckoutDate = checkoutDate,
                PaymentMethod = payment,
                RoomId = room.ID,
                //GuestId = guest.ID
            };

            _context.Reservations.Add(newReservation);
            _context.SaveChanges();

            return newReservation;           
        }

        public void MakeGuestReservation(Guest guest, Reservation reservation)
        {
            var newGuestReservation = new GuestReservation
            {
                GuestID = guest.ID,
                ReservationNr = reservation.ReservationNr
            };
            _context.GuestReservations.Add(newGuestReservation);
            _context.SaveChanges();
        }
       
        public Guest GetGuestByEmail(string email)
        {
            return _context.Guests.Where(x => x.Email == email).FirstOrDefault();
        }

        public List<Reservation> GetAllReservations()
        {
            return _context.Reservations.ToList();                   
        }

        public Guest GetGuestByReservationNr(int reservationNr)
        {
            var guestID = ReservationNrToGuestID(reservationNr);
            return _context.Guests.Where(x => x.ID == guestID).FirstOrDefault();
        }

        public int ReservationNrToGuestID(int resNr)
        {
            return _context.GuestReservations.Where(x => x.ReservationNr == resNr).FirstOrDefault().GuestID;
        }
    }
}
