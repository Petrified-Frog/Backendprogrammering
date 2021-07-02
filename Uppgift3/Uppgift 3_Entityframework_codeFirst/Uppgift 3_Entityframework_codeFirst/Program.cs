using System;
using Uppgift_3_Entityframework_codeFirst.Data;
using Uppgift_3_Entityframework_codeFirst.Services;

namespace Uppgift_3_Entityframework_codeFirst
{
    class Program
    {
        static void Main(string[] args)
        {
            //using var context = new DataContext();

            var service = new SqlService();
            var newGuest = service.CreateGuest("Miamia", "Steddi", "email4.com");
            var newroom = service.CreateRoom(Models.Room.roomTypes.@double, 6547);
            var newReservation = service.CreateReservation(newGuest, newroom, DateTime.Now, DateTime.Now.AddDays(2), Models.Reservation.paymentMethods.blood);
            service.LinkGuest(newGuest, newReservation);


            //context.Add(new Models.Guest { FirstName="Ider", LastName="Jololo", Email="Retcon.com" });
            //context.Add(new Models.Room { Price = 1000, RoomType = Models.Room.roomTypes.single });
            //context.Add(new Models.Reservation { PaymentMethod= Models.Reservation.paymentMethods.card, CheckinDate=DateTime.Today, CheckoutDate=DateTime.Today.AddDays(2) });

            //context.SaveChanges();

           

           
        }
    }
}
