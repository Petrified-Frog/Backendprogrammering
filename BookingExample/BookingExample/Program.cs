using BookingExample.Services;
using BookingExample.Models;
using System;
using System.Linq;

namespace BookingExample
{
    class Program
    {
        

        static void Main(string[] args)
        {



            // Create new RoomTypes if no exists
            if(!SqlService.GetRoomTypes().Any())
            {
                SqlService.CreateRoomType(new RoomType { Name = "Single" });
                SqlService.CreateRoomType(new RoomType { Name = "Double" });
                SqlService.CreateRoomType(new RoomType { Name = "Suite" });
            }


            // Create new Rooms if no exists
            if(!SqlService.GetRooms().Any())
            {
                SqlService.CreateRoom(new Room { RoomTypeId = 1 });     // room 1 - single
                SqlService.CreateRoom(new Room { RoomTypeId = 2 });     // room 2 - double
                SqlService.CreateRoom(new Room { RoomTypeId = 3 });     // room 3 - suite
            }


            // Create new PaymentMethods if no exists
            if(!SqlService.GetPaymentMethods().Any())
            {
                SqlService.CreatePaymentMethod(new PaymentMethod { Name = "Credit Card" });
                SqlService.CreatePaymentMethod(new PaymentMethod { Name = "Paypal" });
                SqlService.CreatePaymentMethod(new PaymentMethod { Name = "Swish" });
            }


            // Get Guest or Create new Guest if guest not exists (example with hard coded values)
            var guest = SqlService.GetGuestByEmail("hans@domain.com");

            if (guest == null)
            {
                SqlService.CreateGuest(new Guest { FirstName = "Hans", LastName = "Mattin-Lassei", Email = "hans@domain.com" });
            }
            

            // Create new Reservation (Example with hard coded values)
            var reservation = SqlService.CreateReservation(new ReservationModel { GuestId = 1, RoomId = 1, PaymentMethodId = 1, StartDate = DateTime.Now, EndDate = DateTime.Now.AddDays(2) });
            Console.WriteLine(reservation.Id);

        }

    }
}
