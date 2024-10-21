using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SLibrary.DataModel.Entities.SLibrary;

namespace SLibrary.DataModel.EntityConfiguration.SLibrary
{
    public class LibroAutorConfiguration : IEntityTypeConfiguration<LibroAutor>
    {
        public void Configure(EntityTypeBuilder<LibroAutor> builder)
        {
            builder.ToTable("LibroAutor");
            builder.HasKey(x => x.Id).HasName("LibroAutorId");
            builder.Property(x => x.Nombre).IsRequired().HasMaxLength(1000);

            builder.HasOne(x => x.Libro)
                .WithMany(x => x.Autores)
                .HasForeignKey(x => x.LibroId);

            builder.HasOne(x => x.Tematica)
                .WithMany()
                .HasForeignKey(x => x.LibroId);
        }
    }
}

