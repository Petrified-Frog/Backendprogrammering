using System;
using System.Data.SqlClient;

namespace sqlClientDB
{
    class Program
    {
        const string sqlConnection = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Programming\Lexicon\Backendprogrammering\SQLDB\sqldb.mdf;Integrated Security=True;Connect Timeout=30";

        static void Main(string[] args)
        {           
            WelcomeScreen();          

        }

        static private void WelcomeScreen()
        {            
            Console.WriteLine("1. Make a reservation");
            Console.WriteLine("2. Cancel a reservation");
            Console.WriteLine("3. List reservations");
            Console.WriteLine("4. Quit");

            string consoleChoice = Console.ReadLine();

            switch (consoleChoice)
            {
                case "1":
                    MakeReservation(); break;
                case "2":
                    CancelReservation(); break;
                case "3":
                    ListReservations();break;
                case "4":
                    break;

                default:
                    {
                        Console.Clear();
                        Console.WriteLine("Invalid choice, try again");
                        WelcomeScreen();
                        break;
                    }
            }
        }



        //**************Make a reservation**************
        static private void MakeReservation()
        {
            

            Console.Clear();
            //guest
            Guest newGuest = new Guest();
            Console.WriteLine("Enter first name");
            newGuest.firstName = Console.ReadLine();
            Console.WriteLine("Enter last name");
            newGuest.lastName = Console.ReadLine();
            Console.WriteLine("Enter your phone number");
            newGuest.phoneNumber = Console.ReadLine();
            Console.WriteLine("Enter your E-mail");
            newGuest.email = Console.ReadLine();

            //reservation
            Reservation newReservation = new Reservation();
            Console.WriteLine("Enter check-in date (YYYY-MM-DD)");
            newReservation.checkInDate = DateTime.Parse(Console.ReadLine()) ;
            Console.WriteLine("Enter check-out date (YYYY-MM-DD)");
            newReservation.checkOutDate = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("What payment method will be used?");
            Console.WriteLine("1. Card");
            Console.WriteLine("2. Swish");
            Console.WriteLine("3. Cash");
            switch(Console.ReadLine())
            {
                case "1":
                    newReservation.paymentType = paymentMethods.card;break;
                case "2":
                    newReservation.paymentType = paymentMethods.swish; break;
                case "3":
                    newReservation.paymentType = paymentMethods.cash; break;
                default:
                    newReservation.paymentType = paymentMethods.cash; break;
            }

            //room
            Room newRoom = new Room();
            Console.WriteLine("Which room type will be reserved?");
            Console.WriteLine("1. Single");
            Console.WriteLine("2. Double");
            Console.WriteLine("3. Luxury");
            switch (Console.ReadLine())
            {
                case "1":
                    newRoom.roomType = roomTypes.single;
                    newRoom.price = 1000; break;
                case "2":
                    newRoom.roomType = roomTypes.@double;
                    newRoom.price = 2000; break;
                case "3":
                    newRoom.roomType = roomTypes.luxury;
                    newRoom.price = 5000; break;
                default:
                    newRoom.roomType = roomTypes.single;
                    newRoom.price = 1000; break;
            }
            
            

            //guest DB
            var conn = new SqlConnection(sqlConnection);
            using (conn)
            {
                conn.Open();

                using var guestCmd = new SqlCommand("INSERT INTO Guest(FirstName, LastName, Phone, Email) VALUES(@FirstName, @LastName, @Phone, @Email)", conn);
                guestCmd.Parameters.AddWithValue("@FirstName", newGuest.firstName);
                guestCmd.Parameters.AddWithValue("@LastName", newGuest.lastName);
                guestCmd.Parameters.AddWithValue("@Phone", newGuest.phoneNumber);
                guestCmd.Parameters.AddWithValue("@Email", newGuest.email);

                guestCmd.ExecuteNonQuery();
            }          

            //room DB
            conn = new SqlConnection(sqlConnection);
            using (conn)
            {
                conn.Open();

                using var guestCmd = new SqlCommand("INSERT INTO Room(RoomType, Price) VALUES(@RoomType, @Price)", conn);
                guestCmd.Parameters.AddWithValue("@RoomType", newRoom.roomType);
                guestCmd.Parameters.AddWithValue("@Price", newRoom.price);

                guestCmd.ExecuteNonQuery();
            }           

            //reservation DB            
            conn = new SqlConnection(sqlConnection);
            using (conn)
            {
                conn.Open();

                using var getRoomIDcmd = new SqlCommand("SELECT RoomNr FROM Room ORDER BY RoomNr DESC ", conn);
                var result = (Int16)getRoomIDcmd.ExecuteScalar();
                                
                using var resCmd = new SqlCommand("INSERT INTO Reservation (RoomNr, CheckInDate, CheckOutDate, PaymentMethod) VALUES(@RoomNr, @CheckInDate, @CheckOutDate, @PaymentMethod)", conn);
                resCmd.Parameters.AddWithValue("@RoomNr", result);
                resCmd.Parameters.AddWithValue("@CheckInDate", newReservation.checkInDate);
                resCmd.Parameters.AddWithValue("@CheckOutDate", newReservation.checkOutDate);
                resCmd.Parameters.AddWithValue("@PaymentMethod", newReservation.paymentType.ToString());

                resCmd.ExecuteNonQuery();
            }           

            //Party reservation
            conn = new SqlConnection(sqlConnection);
            using (conn)
            {
                conn.Open();
                using var getGuestIDcmd = new SqlCommand("SELECT ID FROM Guest ORDER BY ID DESC ", conn);
                var gResult = (int)getGuestIDcmd.ExecuteScalar();
                using var getReservationNrcmd = new SqlCommand("SELECT ReservationNr FROM Reservation ORDER BY ReservationNr DESC", conn);
                var rResult = (int)getReservationNrcmd.ExecuteScalar();
                newReservation.reservationNr = rResult; //store for printout

                using var pRescmd = new SqlCommand("INSERT INTO PartyReservation (GuestID, ReservationNr) VALUES(@GuestID, @ReservationNr)", conn);
                pRescmd.Parameters.AddWithValue("@GuestID", gResult);
                pRescmd.Parameters.AddWithValue("@ReservationNr", rResult);

                pRescmd.ExecuteNonQuery();
            }
            Console.WriteLine("Reservation complete!");
            Console.WriteLine($"Reservation Nr: {newReservation.reservationNr}");
            Console.WriteLine($"Name: {newGuest.firstName} { newGuest.lastName}");
            Console.WriteLine($"Room Type: {newRoom.roomType}");
            Console.WriteLine($"Staying: {newReservation.checkInDate} - {newReservation.checkOutDate}");

            Console.WriteLine("Press enter to return to start screen");
            Console.ReadLine();
            Console.Clear();
            WelcomeScreen();

        }

        //**************Cancel reservation**************
        static private void CancelReservation()
        {
            Console.Clear();
            Console.WriteLine("Which reservation do you want to cancel?");
            Console.WriteLine("Enter Reservation number:");
            string cancelNumber = Console.ReadLine();


            var conn = new SqlConnection(sqlConnection);
            using (conn)
            {
                conn.Open();

                using var cmd = new SqlCommand( $"SELECT GuestID FROM PartyReservation WHERE ReservationNr={cancelNumber}", conn);
                var guestId = (int)cmd.ExecuteScalar();
                cmd.CommandText = $"SELECT RoomNr FROM Reservation WHERE ReservationNr={cancelNumber}";
                var roomId = (Int16)cmd.ExecuteScalar();

                cmd.CommandText =  $"DELETE FROM Reservation WHERE ReservationNr={cancelNumber}";
                cmd.ExecuteNonQuery();

                cmd.CommandText = $"DELETE FROM PartyReservation WHERE ReservationNr={cancelNumber}";
                cmd.ExecuteNonQuery();

                cmd.CommandText = $"DELETE FROM Guest WHERE ID={guestId}";
                cmd.ExecuteNonQuery();

                cmd.CommandText = $"DELETE FROM Room WHERE RoomNr={roomId}";
                cmd.ExecuteNonQuery();


            }

            Console.WriteLine($"Reservation Nr {cancelNumber} canceled.");
            Console.WriteLine("Press enter to return to start screen");
            Console.ReadLine();
            Console.Clear();
            WelcomeScreen();
        }

        static private void ListReservations()
        {
            Console.Clear();
            var conn = new SqlConnection(sqlConnection);
            using (conn)
            {
                conn.Open();
                using var cmd = new SqlCommand( "SELECT Reservation.ReservationNr, Reservation.CheckInDate, Reservation.CheckOutDate, Room.RoomType " +
                                                "FROM Reservation " +
                                                "INNER JOIN Room ON Reservation.RoomNr = Room.RoomNr", conn);

                var result = cmd.ExecuteReader();

                while (result.Read())
                {
                    Console.WriteLine($"Reservation Nr: {result.GetValue(0)} Date: {result.GetValue(1)} - {result.GetValue(2)} Roomtype: {(roomTypes)Enum.Parse(typeof(roomTypes), result.GetValue(3).ToString())  }");
                }
            }

            Console.WriteLine("Press enter to return to start screen");
            Console.ReadLine();
            Console.Clear();
            WelcomeScreen();
        }       
    }
}
