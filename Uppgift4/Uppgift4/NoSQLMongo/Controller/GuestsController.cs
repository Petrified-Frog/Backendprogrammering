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
    public class GuestsController : ControllerBase
    {
        private readonly IBooking _booking;

        public GuestsController(IBooking booking)
        {
            _booking = booking;
        }

        [HttpPost]
        public IActionResult CreateGuest(CreateGuestModel model)
        {
            Guest guest = new Guest { FirstName = model.FirstName, LastName = model.LastName, Email = model.Email };

            _booking.CreateGuest(guest);
            return new CreatedAtRouteResult("GetGuest", new { id = guest.GuestId}, guest);
        }

        [HttpGet("{id}",Name ="GetGuest")]
        public IActionResult GetGuest(string id)
        {
            return new OkObjectResult(_booking.GetGuestById(id));
        }

        [HttpGet]
        public IActionResult GetGuests()
        {
            return new OkObjectResult( _booking.GetAllGuests());
        }

        [HttpPut]
        public IActionResult UpdateGuest(Guest guest)
        {
            _booking.PutGuest(guest);
            return new OkObjectResult(guest );
             
        }

        [HttpDelete]
        public IActionResult DeleteGuest(string id)
        {
            _booking.DeleteGuest(id);
            return new NoContentResult();
        }

    }
}
