using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DL;

public partial class EliconaCineContext : DbContext
{
    public EliconaCineContext()
    {
    }

    public EliconaCineContext(DbContextOptions<EliconaCineContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cine> Cines { get; set; }
    public virtual DbSet<Cine> PuntoVentas { get; set; }

    public virtual DbSet<Login> Logins { get; set; }

    public virtual DbSet<Zona> Zonas { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=LAPTOP-2POFP3ID; Database= ELiconaCine; TrustServerCertificate=True; User ID=sa; Password=pass@word1;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cine>(entity =>
        {
            entity.HasKey(e => e.IdCine).HasName("PK__Cine__394B724B64AD73C5");

            entity.ToTable("Cine");

            entity.Property(e => e.Direccion)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.NombreCine)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Ventas).HasColumnType("numeric(18, 2)");

            entity.HasOne(d => d.IdZonaNavigation).WithMany(p => p.Cines)
                .HasForeignKey(d => d.IdZona)
                .HasConstraintName("FK__Cine__IdZona__1273C1CD");
        });

        modelBuilder.Entity<Login>(entity =>
        {
            entity.HasKey(e => e.IdLogin).HasName("PK__Login__C3C6C6F17A2A106C");

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
            entity.Property(e => e.NombreUsuario)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Password).HasMaxLength(20);
            entity.Property(e => e.UserName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Zona>(entity =>
        {
            entity.HasKey(e => e.IdZona).HasName("PK__Zona__F631C12D3D3C995C");

            entity.ToTable("Zona");

            entity.Property(e => e.NombreZona)
                .HasMaxLength(200)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
