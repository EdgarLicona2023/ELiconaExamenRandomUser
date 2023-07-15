using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DLL;

public partial class EliconaExamenAeroMexicoContext : DbContext
{
    public EliconaExamenAeroMexicoContext()
    {
    }

    public EliconaExamenAeroMexicoContext(DbContextOptions<EliconaExamenAeroMexicoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Login> Logins { get; set; }

    public virtual DbSet<Pasajero> Pasajeros { get; set; }

    public virtual DbSet<ReservacionVuelo> ReservacionVuelos { get; set; }

    public virtual DbSet<Vuelo> Vuelos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=LAPTOP-2POFP3ID; Database= ELiconaExamenAeroMexico; TrustServerCertificate=True; User ID=sa; Password=pass@word1;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Login>(entity =>
        {
            entity.HasKey(e => e.IdLogin).HasName("PK__Login__C3C6C6F1F20A59F5");

            entity.ToTable("Login");

            entity.Property(e => e.ApellidoMaterno)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ApellidoPaterno)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Correo)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Password).HasMaxLength(20);
            entity.Property(e => e.UserName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Pasajero>(entity =>
        {
            entity.HasKey(e => e.IdPasajero).HasName("PK__Pasajero__78E232CBBA0D64C2");

            entity.ToTable("Pasajero");

            entity.Property(e => e.ApellidoMaterno)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ApellidoPaterno)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Correo)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Password).HasMaxLength(20);
            entity.Property(e => e.UserName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ReservacionVuelo>(entity =>
        {
            entity.HasKey(e => e.IdReservacionVuelos).HasName("PK__Reservac__71B863E2BF4773A8");

            entity.HasOne(d => d.IdPasajeroNavigation).WithMany(p => p.ReservacionVuelos)
                .HasForeignKey(d => d.IdPasajero)
                .HasConstraintName("FK__Reservaci__IdPas__24927208");

            entity.HasOne(d => d.IdVueloNavigation).WithMany(p => p.ReservacionVuelos)
                .HasForeignKey(d => d.IdVuelo)
                .HasConstraintName("FK__Reservaci__IdVue__25869641");
        });

        modelBuilder.Entity<Vuelo>(entity =>
        {
            entity.HasKey(e => e.IdVuelo).HasName("PK__Vuelo__217617263A6EE59B");

            entity.ToTable("Vuelo");

            entity.Property(e => e.Destino)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.FechaSalida).HasColumnType("smalldatetime");
            entity.Property(e => e.NumeroVuelo)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.Origen)
                .HasMaxLength(2)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
