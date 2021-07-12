using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfDapperDB.Models;

namespace WpfDapperDB
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
               
        private void button_Click(object sender, RoutedEventArgs e)
        {
            MakeReservation();
        }

        private void ListReservations_Click(object sender, RoutedEventArgs e)
        {
            
            Reservations();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            DeleteReservation();
        }

        private void MakeReservation()
        {
            using (IDbConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Programming\Lexicon\Backendprogrammering\SQLDB\sqldb.mdf;Integrated Security=True;Connect Timeout=30"))
            {
                var guestModel = new RegisterGuestModel();
                guestModel.FirstName = textboxFirstName.Text;
                guestModel.LastName = textboxLastName.Text;
                guestModel.Phone = textboxPhone.Text;
                guestModel.Email = textboxEmail.Text;
                var guestId = (int)conn.ExecuteScalar("INSERT INTO Guest (FirstName, LastName, Phone, Email) OUTPUT Inserted.Id VALUES(@FirstName, @LastName, @Phone, @Email)", guestModel);


                var roomModel = new RoomModel();
                roomModel.RoomType = TranslateRoomtypeCombo(comboboxRoomType.Text);
                roomModel.Price = roomModel.RoomType + 50;
                var roomId = (Int16)conn.ExecuteScalar("INSERT INTO Room(RoomType, Price) OUTPUT Inserted.RoomNr VALUES(@RoomType, @Price)", roomModel);


                var reservationModel = new ReservationModel();
                reservationModel.RoomNr = roomId;
                reservationModel.CheckInDate = DateTime.Parse( textboxCheckin.Text);
                reservationModel.CheckOutDate = DateTime.Parse(textboxCheckout.Text);                
                reservationModel.paymentMethod = TranslatePaymentCombo(comboboxPayment.Text);
                var reservationId = (int)conn.ExecuteScalar("INSERT INTO Reservation(RoomNr, CheckInDate, CheckOutDate, PaymentMethod) OUTPUT Inserted.ReservationNr VALUES(@RoomNr, @CheckInDate, @CheckOutDate, @PaymentMethod)", reservationModel);
                
                conn.Execute("INSERT INTO PartyReservation(GuestID,ReservationNr) VALUES(@GuestID, @ReservationNr)", new { GuestID = guestId, ReservationNr = reservationId });
            }
        }

        private void Reservations()
        {
            using (IDbConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Programming\Lexicon\Backendprogrammering\SQLDB\sqldb.mdf;Integrated Security=True;Connect Timeout=30"))
            {
                var result = conn.Query("SELECT Reservation.ReservationNr, Reservation.CheckInDate, Reservation.CheckOutDate, Room.RoomType " +
                                                "FROM Reservation " +
                                                "INNER JOIN Room ON Reservation.RoomNr = Room.RoomNr").ToList();

                reservationBox.ItemsSource = result;
               
            }
                
        }

        private void DeleteReservation()
        {
            int cancelNumber = Int32.Parse(deleteNrBox.Text);
            using (IDbConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Programming\Lexicon\Backendprogrammering\SQLDB\sqldb.mdf;Integrated Security=True;Connect Timeout=30"))
            {
                int guestId = (int)conn.ExecuteScalar($"SELECT GuestID FROM PartyReservation WHERE ReservationNr ={cancelNumber}");
                Int16 roomId = (Int16)conn.ExecuteScalar($"SELECT RoomNr FROM Reservation WHERE ReservationNr={cancelNumber}");

                conn.ExecuteScalar($"DELETE FROM PartyReservation WHERE ReservationNr={cancelNumber}");
                conn.ExecuteScalar($"DELETE FROM Guest WHERE ID={guestId}");
                conn.ExecuteScalar($"DELETE FROM Reservation WHERE ReservationNr={cancelNumber}");
                conn.ExecuteScalar($"DELETE FROM Room WHERE RoomNr={roomId}");
            }
        }

      
        private int TranslateRoomtypeCombo(string boxText)
        {
            switch (boxText)
            {
                case "Single": return 0;
                case "Double": return 1;
                case "Luxury": return 2;
                default: return 0;
            }
        }

        private int TranslatePaymentCombo(string boxText)
        {
            switch (boxText)
            {
                case "Cash": return 0;
                case "Card": return 1;
                case "Blood": return 2;
                default: return 0;
            }
        }


    }
}
