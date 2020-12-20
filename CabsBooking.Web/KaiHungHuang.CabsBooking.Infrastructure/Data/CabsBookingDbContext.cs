using KaiHungHuang.CabsBooking.Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CabsBooking.Infrastructure.Data
{
    public class CabsBookingDbContext: DbContext
    {
        public CabsBookingDbContext(DbContextOptions<CabsBookingDbContext> options): base(options)
        {
            
        }
        // Adding Tables
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<BookingHistory> BookingHistories { get; set; }
        public DbSet<CabType> CabTypes { get; set; }
        public DbSet<Place> Places { get; set; }
        
        //Fluent API
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Booking>(ConfigureBooking);
            modelBuilder.Entity<BookingHistory>(ConfigureBookingHistory);
            modelBuilder.Entity<CabType>(ConfigureCabType);
            modelBuilder.Entity<Place>(ConfigurePlace);
        }

        private void ConfigureBooking(EntityTypeBuilder<Booking> builder)
        {
            builder.ToTable("Bookings");
            builder.HasKey(b => b.Id);
            builder.Property(b => b.Email).HasMaxLength(50);
            builder.Property(b => b.BookingDate).HasColumnType("date");
            builder.Property(b => b.BookingTime).HasMaxLength(5);
            builder.Property(b => b.PickupAddress).HasMaxLength(200);
            builder.Property(b => b.Landmark).HasMaxLength(30);
            builder.Property(b => b.PickupDate).HasColumnType("date");
            builder.Property(b => b.PickupTime).HasMaxLength(5);
            builder.Property(b => b.ContactNo).HasMaxLength(25);
            builder.Property(b => b.Status).HasMaxLength(30);
            builder.HasOne(b => b.CabType)
                .WithMany(c => c.Bookings)
                .HasForeignKey(b => b.CabTypeId);
            builder.HasOne(b => b.FromPlaceName)
                .WithMany(p => p.FromPlaceBookings)
                .HasForeignKey(b => b.FromPlace);
            builder.HasOne(b => b.ToPlaceName)
                .WithMany(p => p.ToPlaceBookings)
                .HasForeignKey(b => b.ToPlace);
        }

        private void ConfigureBookingHistory(EntityTypeBuilder<BookingHistory> builder)
        {
            builder.ToTable("Bookings_history");
            builder.HasKey(b => b.Id);
            builder.Property(b => b.Email).HasMaxLength(50);
            builder.Property(b => b.BookingDate).HasColumnType("date");
            builder.Property(b => b.BookingTime).HasMaxLength(5);
            builder.Property(b => b.PickupAddress).HasMaxLength(200);
            builder.Property(b => b.Landmark).HasMaxLength(30);
            builder.Property(b => b.PickupDate).HasColumnType("date");
            builder.Property(b => b.PickupTime).HasMaxLength(5);
            builder.Property(b => b.ContactNo).HasMaxLength(25);
            builder.Property(b => b.Status).HasMaxLength(30);
            builder.Property(b => b.Comp_time).HasMaxLength(5);
            builder.Property(b => b.Charge).HasColumnType("money");
            builder.Property(b => b.Feedback).HasMaxLength(1000);
            builder.HasOne(b => b.CabType)
                .WithMany(c => c.BookingHistories)
                .HasForeignKey(b => b.CabTypeId);
            builder.HasOne(b => b.FromPlaceName)
                .WithMany(p => p.FromPlaceBookingHistories)
                .HasForeignKey(b => b.FromPlace);
            builder.HasOne(b => b.ToPlaceName)
                .WithMany(p => p.ToPlaceBookingHistories)
                .HasForeignKey(b => b.ToPlace);
        }

        private void ConfigureCabType(EntityTypeBuilder<CabType> builder)
        {
            builder.ToTable("CabTypes");
            builder.HasKey(c => c.CabTypeId);
            builder.Property(c => c.CabTypeName).HasMaxLength(30);
        }

        private void ConfigurePlace(EntityTypeBuilder<Place> builder)
        {
            builder.ToTable("Places");
            builder.Property(p => p.PlaceName).HasMaxLength(30);
        }
    }
}