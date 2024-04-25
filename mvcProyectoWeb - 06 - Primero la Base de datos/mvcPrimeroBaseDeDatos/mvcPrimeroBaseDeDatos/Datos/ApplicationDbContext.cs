using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using mvcPrimeroBaseDeDatos.Models;

namespace mvcPrimeroBaseDeDatos.Datos;

public partial class ApplicationDbContext : DbContext
{
    public ApplicationDbContext()
    {
    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Departamento> Departamentos { get; set; }

    public virtual DbSet<Municipio> Municipios { get; set; }

    public virtual DbSet<Pai> Pais { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=SCSTICEP01\\SQL2022;Database=PrimeroBaseDeDatos;User ID=sa;Password=Password123$;Encrypt=false");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Departamento>(entity =>
        {
            entity.HasKey(e => e.IdDepartamento);

            entity.ToTable("Departamento");

            entity.Property(e => e.IdDepartamento).ValueGeneratedNever();
            entity.Property(e => e.Detalle)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.NombreDepartamento)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Pais).WithMany(p => p.Departamentos)
                .HasForeignKey(d => d.PaisId)
                .HasConstraintName("FK_Departamento_Pais");
        });

        modelBuilder.Entity<Municipio>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Municipio");

            entity.Property(e => e.Detalle)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.NombreMunicipio)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Departamento).WithMany()
                .HasForeignKey(d => d.DepartamentoId)
                .HasConstraintName("FK_Municipio_Departamento");
        });

        modelBuilder.Entity<Pai>(entity =>
        {
            entity.HasKey(e => e.IdPais);

            entity.Property(e => e.IdPais).ValueGeneratedNever();
            entity.Property(e => e.Detalle)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.NombrePais)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
