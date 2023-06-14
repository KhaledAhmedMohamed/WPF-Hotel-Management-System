using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Management__WPF_
{
    class HotelDBContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=HotelDB;Integrated Security=true;" +
                "Encrypt=false");

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //    => optionsBuilder.UseSqlServer("Data Source=(LocalDb)\\MSSQLLocalDB;Initial Catalog=HotelDB;Integrated Security=true;" +
        //        "Encrypt=false");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Reservation>(entity =>
            {
                entity.HasKey(r => r.ID);

                entity.Property(r => r.ID)
                .HasColumnName("ID")
                .IsRequired()
                .UseIdentityColumn(1001,1);

                entity.Property(r => r.FirstName)
                .IsRequired()
                .HasMaxLength(50);

                entity.Property(r => r.LastName)
                .IsRequired()
                .HasMaxLength(50);

                entity.Property(r => r.Birthday)
                .IsRequired()
                .HasMaxLength(50);

                entity.Property(r => r.Gender)
                .IsRequired()
                .HasMaxLength(10);

                entity.Property(r => r.PhoneNumber)
                .IsRequired()
                .HasMaxLength(50);

                entity.Property(r => r.Email)
                .IsRequired();

                entity.Property(r => r.GusteNumber)
                .IsRequired();

                entity.Property(r => r.StreetAddress)
                .IsRequired();

                entity.Property(r => r.Apt_Suite)
                .IsRequired()
                .HasMaxLength(50);

                entity.Property(r => r.City)
                .IsRequired()
                .HasMaxLength(50);

                entity.Property(r => r.State)
                .IsRequired()
                .HasMaxLength(50);

                entity.Property(r => r.ZipCode)
                .IsRequired()
                .HasMaxLength(10);

                entity.Property(r => r.RoomType)
                .IsRequired()
                .HasMaxLength(10);

                entity.Property(r => r.RoomFloor)
                .IsRequired()
                .HasMaxLength(10);

                entity.Property(r => r.RoomNumber)
                .IsRequired()
                .HasMaxLength(50);

                entity.Property(r => r.TotalBill)
                .IsRequired()
                .HasColumnType("float");

                entity.Property(r => r.PaymentType)
                .IsRequired()
                .HasMaxLength(10);

                entity.Property(r => r.CardType)
                .IsRequired()
                .HasMaxLength(10);

                entity.Property(r => r.CardNumber)
                .IsRequired()
                .HasMaxLength(30);

                entity.Property(r => r.CardExp)
                .IsRequired()
                .HasMaxLength(20);

                entity.Property(r => r.CardCVV)
                .IsRequired()
                .HasMaxLength(5);

                entity.Property(r => r.ArrivalDate)
                .IsRequired()
                .HasColumnType("date");

                entity.Property(r => r.LeavingDate)
                .IsRequired()
                .HasColumnType("date");

                entity.Property(r => r.CheckIn)
                .IsRequired()
                .HasColumnType("bit");

                entity.Property(r => r.BreakFast)
                .IsRequired();

                entity.Property(r => r.Lunch)
                .IsRequired();

                entity.Property(r => r.Dinner)
                .IsRequired();

                entity.Property(r => r.Cleaning)
                .IsRequired()
                .HasColumnType("bit");

                entity.Property(r => r.Towel)
                .IsRequired()
                .HasColumnType("bit");

                entity.Property(r => r.SweetestSurprise)
                .IsRequired()
                .HasColumnType("bit");

                entity.Property(r => r.supplyStatus)
                .IsRequired()
                .HasColumnType("bit");

                entity.Property(r => r.FoodBill)
                .IsRequired();
            });

            modelBuilder.Entity<FrontendLogin>(entity =>
            {
                entity.HasKey(f => f.UserName);

                entity.ToTable("FrontendLogins");

                entity.Property(f => f.UserName)
                .IsRequired()
                .HasMaxLength(50);

                entity.Property(f => f.Password)
                .IsRequired()
                .HasMaxLength(50);

            });

            modelBuilder.Entity<KitchenLogin>(entity =>
            {
                entity.HasKey(k => k.UserName);

                entity.ToTable("KitchenLogins");

                entity.Property(k => k.UserName)
                .IsRequired()
                .HasMaxLength(50);

                entity.Property(k => k.Password)
                .IsRequired()
                .HasMaxLength(50);

            });
        }

        public virtual DbSet<Reservation> Reservations { get; set; }

        public virtual DbSet<FrontendLogin> Frontend { get; set; }

        public virtual DbSet<KitchenLogin> Kitchen { get; set; }
    }
}
