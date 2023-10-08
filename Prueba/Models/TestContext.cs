using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Prueba.Models;

public partial class TestContext : DbContext
{
    public TestContext()
    {
    }

    public TestContext(DbContextOptions<TestContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Comentario> Comentarios { get; set; }

    public virtual DbSet<Imagen> Imagens { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Comentario>(entity =>
        {
            entity.ToTable("Comentario");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Descripcion)
                .HasMaxLength(200)
                .IsFixedLength();
            entity.Property(e => e.IdImagen).HasColumnName("Id_Imagen");

            entity.HasOne(d => d.IdImagenNavigation).WithMany(p => p.Comentarios)
                .HasForeignKey(d => d.IdImagen)
                .HasConstraintName("FK_Comentario_Imagen");
        });

        modelBuilder.Entity<Imagen>(entity =>
        {
            entity.ToTable("Imagen");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Imagen1)
                .HasColumnType("image")
                .HasColumnName("Imagen");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
