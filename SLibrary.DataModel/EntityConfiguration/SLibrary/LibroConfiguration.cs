using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SLibrary.DataModel.Entities.SLibrary;

namespace SLibrary.DataModel.EntityConfiguration.SLibrary
{
    public class LibroConfiguration : IEntityTypeConfiguration<Libro>
    {

        public void Configure(EntityTypeBuilder<Libro> builder)
        {
            builder.ToTable("Libro");
            builder.HasKey(x => x.Id).HasName("LibroId");
            builder.Property(x => x.Titulo).IsRequired().HasMaxLength(1000);
            builder.Property(x => x.Descripcion).IsRequired().HasMaxLength(1000);

            builder.HasMany(x => x.Autores)
              .WithMany(x => x.Libros);

            builder.HasMany(x => x.Categorias)
              .WithMany(x => x.Libros);


        }
    }
}

