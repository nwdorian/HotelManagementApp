using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DataLibrary.Models;

public partial class HotelManagementContext : DbContext
{
    public HotelManagementContext()
    {
    }

    public HotelManagementContext(DbContextOptions<HotelManagementContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Bed> Bed { get; set; }

    public virtual DbSet<City> City { get; set; }

    public virtual DbSet<Country> Country { get; set; }

    public virtual DbSet<Guest> Guest { get; set; }

    public virtual DbSet<Reservation> Reservation { get; set; }

    public virtual DbSet<Room> Room { get; set; }

    public virtual DbSet<RoomReservation> RoomReservation { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP\\SQLEXPRESS;Database=HotelManagement;Trusted_Connection=SSPI;Encrypt=false;TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Bed>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__bed__3213E83F15FD82BF");

            entity.ToTable("bed");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
        });

        modelBuilder.Entity<City>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__city__3213E83FCD560F54");

            entity.ToTable("city");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Country>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__country__3213E83F84989503");

            entity.ToTable("country");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Guest>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__guest__3213E83FBF410793");

            entity.ToTable("guest");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Adress)
                .HasMaxLength(50)
                .HasColumnName("adress");
            entity.Property(e => e.CityId).HasColumnName("cityId");
            entity.Property(e => e.CountryId).HasColumnName("countryId");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .HasColumnName("firstName");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .HasColumnName("lastName");
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .HasColumnName("phone");

            entity.HasOne(d => d.City).WithMany(p => p.Guest)
                .HasForeignKey(d => d.CityId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__guest__cityId__3B75D760");

            entity.HasOne(d => d.Country).WithMany(p => p.Guest)
                .HasForeignKey(d => d.CountryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__guest__countryId__3C69FB99");
        });

        modelBuilder.Entity<Reservation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__reservat__3213E83FDFBF7070");

            entity.ToTable("reservation");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CheckIn)
                .HasColumnType("datetime")
                .HasColumnName("checkIn");
            entity.Property(e => e.CheckOut)
                .HasColumnType("datetime")
                .HasColumnName("checkOut");
            entity.Property(e => e.GuestId).HasColumnName("guestId");

            entity.HasOne(d => d.Guest).WithMany(p => p.Reservation)
                .HasForeignKey(d => d.GuestId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__reservati__guest__3F466844");
        });

        modelBuilder.Entity<Room>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__room__3213E83F6A01716E");

            entity.ToTable("room");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.BedId).HasColumnName("bedId");
            entity.Property(e => e.Floor).HasColumnName("floor");
            entity.Property(e => e.NumBeds).HasColumnName("numBeds");
            entity.Property(e => e.Number).HasColumnName("number");

            entity.HasOne(d => d.Bed).WithMany(p => p.Room)
                .HasForeignKey(d => d.BedId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__room__bedId__440B1D61");
        });

        modelBuilder.Entity<RoomReservation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__roomRese__3213E83F893A179D");

            entity.ToTable("roomReservation");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ReservationId).HasColumnName("reservationId");
            entity.Property(e => e.RoomId).HasColumnName("roomId");

            entity.HasOne(d => d.Reservation).WithMany(p => p.RoomReservation)
                .HasForeignKey(d => d.ReservationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__roomReser__reser__46E78A0C");

            entity.HasOne(d => d.Room).WithMany(p => p.RoomReservation)
                .HasForeignKey(d => d.RoomId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__roomReser__roomI__47DBAE45");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
