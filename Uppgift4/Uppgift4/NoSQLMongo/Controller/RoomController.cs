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
    public class RoomController : ControllerBase
    {
        private readonly IBooking _booking;
        public RoomController(IBooking booking)
        {
            _booking = booking;
        }

        [HttpPost]
        public  IActionResult CreateRoom(CreateRoomModel model)
        {
            Room room = new Room { RoomType = model.RoomType, Price = model.Price };
            return new OkObjectResult(_booking.CreateRoom(room));
        }

        [HttpGet]
        public IActionResult GetRoom(string nr)
        {
            return new OkObjectResult(_booking.GetRoomByNr(nr));
        }
        
    }
}
