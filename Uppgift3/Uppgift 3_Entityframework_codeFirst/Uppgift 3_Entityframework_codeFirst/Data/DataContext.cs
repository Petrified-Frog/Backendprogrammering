using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uppgift_3_Entityframework_codeFirst.Models;

namespace Uppgift_3_Entityframework_codeFirst.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Guest> Guests { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<GuestReservation> GuestReservations { get; set; }

        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Programming\Lexicon\Backendprogrammering\Uppgift3\Uppgift 3_Entityframework_codeFirst\Uppgift 3_Entityframework_codeFirst\Data\db_efupg3.mdf;Integrated Security=True;Connect Timeout=30");
           
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<GuestReservation>(entity => 
            {
                entity.HasKey(e => new { e.ReservationNr, e.GuestID }).HasName("PK_GuestReservat");
            });
        }
    }
}
