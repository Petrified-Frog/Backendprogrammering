using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NoSQLMongo.Interfaces;
using NoSQLMongo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoSQLMongo.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private readonly IBooking _booking;
        public ReservationController(IBooking booking)
        {
            _booking = booking;
        }

        [HttpPost]
        public IActionResult CreateReservation(CreateReservationModel model)
        {
            Reservation reservation = new Reservation { CheckInDate = model.CheckInDate,
                CheckOutDate = model.CheckOutDate,
                PaymentMethod = model.PaymentMethod,
                GuestId = model.GuestId,
                RoomNr = model.RoomNr 
            };

            _booking.CreateReservation(reservation);
            return new CreatedAtRouteResult("GetReservation", new {id = reservation.ReservationNr },reservation);
        }

        [HttpGet("{id}",Name ="GetReservation")]
        public IActionResult GetReservation(string id)
        {
            return new OkObjectResult( _booking.GetReservationByNr(id));
        }

        [HttpGet]
        public IActionResult GetReservations()
        {
            return new OkObjectResult(_booking.GetAllReservations());
        }

        [HttpPut]
        public IActionResult UpdateReservation (Reservation reservation)
        {
            _booking.PutReservation(reservation);
            return new OkObjectResult(reservation);
        }
        
    }
}
