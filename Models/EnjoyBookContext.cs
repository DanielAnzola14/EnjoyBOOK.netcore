using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Proyecto.Models;

public partial class EnjoyBookContext : DbContext
{
    public EnjoyBookContext()
    {
    }

    public EnjoyBookContext(DbContextOptions<EnjoyBookContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Libro> Libros { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Libro>(entity =>
        {
            entity.HasKey(e => e.IdLibro).HasName("PK__Libros__5BC0F026817E8881");

            entity.Property(e => e.IdLibro).HasColumnName("idLibro");
            entity.Property(e => e.AutorLibro)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("autorLibro");
            entity.Property(e => e.Caracteristicas)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("caracteristicas");
            entity.Property(e => e.EditorialLibro)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("editorialLibro");
            entity.Property(e => e.NombreLibro)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("nombreLibro");
            entity.Property(e => e.NumPag).HasColumnName("numPag");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
