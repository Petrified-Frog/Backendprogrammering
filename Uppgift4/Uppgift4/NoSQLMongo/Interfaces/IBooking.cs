using NoSQLMongo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoSQLMongo.Interfaces
{
    public interface IBooking
    {
        #region Guest

        Guest CreateGuest(Guest newGuest);
        Guest GetGuestById(string id);
        List<Guest> GetAllGuests();
        Guest PutGuest(Guest updatedGuest);
        void DeleteGuest(string id);

        #endregion

        #region Room

        Room CreateRoom(Room newRoom);
        Room GetRoomByNr(string roomNr);

        #endregion

        #region Reservation

        Reservation CreateReservation(Reservation newReservation);
        Reservation GetReservationByNr(string reservationNr);
        List<Reservation> GetAllReservations();
        Reservation PutReservation(Reservation updateedReservation);


        #endregion

    }
}
