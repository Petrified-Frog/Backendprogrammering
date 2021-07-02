using BookingExample.Data;
using BookingExample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingExample.Services
{
    public class SqlService
    {

        public static void CreateGuest(Guest guest)
        {
            using var _context = new SqlContext();
            _context.Add(guest);
            _context.SaveChanges();
        }

        public static void CreateRoomType(RoomType roomType)
        {
            using var _context = new SqlContext();
            _context.Add(roomType);
            _context.SaveChanges();
        }

        public static void CreateRoom(Room room)
        {
            using var _context = new SqlContext();
            _context.Add(room);
            _context.SaveChanges();
        }

        public static void CreatePaymentMethod(PaymentMethod paymentMethod)
        {
            using var _context = new SqlContext();
            _context.Add(paymentMethod);
            _context.SaveChanges();
        }

        public static Reservation CreateReservation(ReservationModel model)
        {
            using var _context = new SqlContext();

            var reservation = new Reservation()
            {
                GuestId = model.GuestId,
                RoomId = model.RoomId,
                PaymentMethodId = model.PaymentMethodId,
                StartDate = model.StartDate,
                EndDate = model.EndDate
            };

            _context.Add(reservation);
            _context.SaveChanges();

            return reservation;
        }

        public static IEnumerable<Guest> GetGuests()
        {
            using var _context = new SqlContext();
            return _context.Guests.ToList();
        }

        public static IEnumerable<RoomType> GetRoomTypes()
        {
            using var _context = new SqlContext();
            return _context.RoomTypes.ToList();
        }

        public static IEnumerable<Room> GetRooms()
        {
            using var _context = new SqlContext();
            return _context.Rooms.ToList();
        }

        public static IEnumerable<PaymentMethod> GetPaymentMethods()
        {
            using var _context = new SqlContext();
            return _context.PaymentMethods.ToList();
        }

        public static Guest GetGuestByEmail(string email)
        {
            using var _context = new SqlContext();
            return _context.Guests.Where(guest => guest.Email == email).FirstOrDefault();
        }


        public static IEnumerable<Reservation> GetReservations()
        {
            using var _context = new SqlContext();
            return _context.Reservations.ToList();
        }

    }
}
