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

            Console.WriteLine("before add");
            PrintDB();

            //Make reservation
            //var newGuest = service.CreateGuest("Moln", "Rain", "Wet.com");
            //var newroom = service.CreateRoom(Models.Room.roomTypes.single, 1000);
            //var newReservation = service.CreateReservation(newGuest, newroom, DateTime.Now, DateTime.Now.AddDays(2), Models.Reservation.paymentMethods.cash);
            //service.MakeGuestReservation(newGuest, newReservation);


            Console.WriteLine("before update");
            PrintDB();

            //Update a reservation
            var updReservation = new Reservation { ReservationNr = 2,
                CheckinDate = DateTime.Now,
                CheckoutDate = DateTime.Now.AddDays(5),
                PaymentMethod = Reservation.paymentMethods.cash,
                RoomId = 1 };
            service.UpdateReservation(updReservation);

            Console.WriteLine("before delete");
            PrintDB();

            //Console.WriteLine("\nPick a reservation to delete");
            //var deleteInput = Console.ReadLine();
            //service.DeleteReservation(int.Parse(deleteInput));


            Console.WriteLine("after delete");
            PrintDB();
        }



        private static void PrintDB()
        {
            var service = new SqlService();
            var reservationList = service.GetAllReservations();
            foreach (Reservation res in reservationList)
            {                
                Console.WriteLine("Booker: " + service.GetGuestByReservationNr(res.ReservationNr).FirstName + " " + service.GetGuestByReservationNr(res.ReservationNr).LastName);
                Console.WriteLine("Reservation Nr: " + res.ReservationNr);
                Console.WriteLine("Staying: " + res.CheckinDate + " - " + res.CheckoutDate);
                Console.WriteLine("Room Nr: " + res.RoomId);
                Console.WriteLine("\n");
            }
            Console.WriteLine("\n ********************************* \n");

        }
    }
}
