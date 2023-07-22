using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DLL;

public partial class EliocnaPracticoApoloServivesContext : DbContext
{
    public EliocnaPracticoApoloServivesContext()
    {
    }

    public EliocnaPracticoApoloServivesContext(DbContextOptions<EliocnaPracticoApoloServivesContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Area> Areas { get; set; }

    public virtual DbSet<Departamento> Departamentos { get; set; }

    public virtual DbSet<EstadoCivil> EstadoCivils { get; set; }

    public virtual DbSet<Puesto> Puestos { get; set; }

    public virtual DbSet<Sexo> Sexos { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=LAPTOP-2POFP3ID; Database= ELiocnaPracticoApoloServives; TrustServerCertificate=True; User ID=sa; Password=pass@word1;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Area>(entity =>
        {
            entity.HasKey(e => e.IdArea).HasName("PK__Area__2FC141AA5831D20D");

            entity.ToTable("Area");

            entity.Property(e => e.Areas)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Departamento>(entity =>
        {
            entity.HasKey(e => e.IdDepartamento).HasName("PK__Departam__787A433DCFE1924B");

            entity.ToTable("Departamento");

            entity.Property(e => e.Departamentos)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.IdAreaNavigation).WithMany(p => p.Departamentos)
                .HasForeignKey(d => d.IdArea)
                .HasConstraintName("FK__Departame__IdAre__787EE5A0");
        });

        modelBuilder.Entity<EstadoCivil>(entity =>
        {
            entity.HasKey(e => e.IdEstadoCivil).HasName("PK__EstadoCi__889DE1B2B919811B");

            entity.ToTable("EstadoCivil");

            entity.Property(e => e.EstadoCivil1)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("EstadoCivil");
        });

        modelBuilder.Entity<Puesto>(entity =>
        {
            entity.HasKey(e => e.IdPuesto).HasName("PK__Puesto__ADAC6B9CD51A672D");

            entity.ToTable("Puesto");

            entity.Property(e => e.Puestos)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Sexo>(entity =>
        {
            entity.HasKey(e => e.IdSexo).HasName("PK__Sexo__A7739FA257099CFC");

            entity.ToTable("Sexo");

            entity.Property(e => e.Sexos)
                .HasMaxLength(10)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUser).HasName("PK__Usuario__B7C9263865E87472");

            entity.ToTable("Usuario");

            entity.Property(e => e.ApellidoMaterno)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ApellidoPaterno)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FechaNacimiento)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Telefono).HasColumnType("numeric(12, 0)");
            entity.Property(e => e.UserName)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.IdDepartamentoNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.IdDepartamento)
                .HasConstraintName("FK__Usuario__IdDepar__7E37BEF6");

            entity.HasOne(d => d.IdEstadoCivilNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.IdEstadoCivil)
                .HasConstraintName("FK__Usuario__IdEstad__7C4F7684");

            entity.HasOne(d => d.IdPuestoNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.IdPuesto)
                .HasConstraintName("FK__Usuario__IdPuest__7D439ABD");

            entity.HasOne(d => d.IdSexoNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.IdSexo)
                .HasConstraintName("FK__Usuario__IdSexo__7B5B524B");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
