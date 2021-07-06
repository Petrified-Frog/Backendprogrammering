using System;
using Uppgift_3_Entityframework_codeFirst.Data;
using Uppgift_3_Entityframework_codeFirst.Models;
using Uppgift_3_Entityframework_codeFirst.Services;

namespace Uppgift_3_Entityframework_codeFirst
{
    class Program
    {
        static void Main(string[] args)
        {
            //using var context = new DataContext();

            var service = new SqlService();

            //var newGuest = service.CreateGuest("Retia", "Hoppalong", "SuperEmail4.com");
            //var newroom = service.CreateRoom(Models.Room.roomTypes.luxury, 4566);
            //var newReservation = service.CreateReservation(newGuest, newroom, DateTime.Now, DateTime.Now.AddDays(2), Models.Reservation.paymentMethods.blood);
            //service.MakeGuestReservation(newGuest, newReservation);

            var reservationList = service.GetAllReservations();
            foreach(Reservation res in reservationList)
            {
                Console.WriteLine("Booker: " + service.GetGuestByReservationNr(res.ReservationNr).FirstName +" "+ service.GetGuestByReservationNr(res.ReservationNr).LastName);
                Console.WriteLine("Reservation Nr: "+res.ReservationNr);
                Console.WriteLine("Staying: " + res.CheckinDate + " - "+ res.CheckoutDate);
                Console.WriteLine("Room Nr: " + res.RoomId);
            }
        }
    }
}
