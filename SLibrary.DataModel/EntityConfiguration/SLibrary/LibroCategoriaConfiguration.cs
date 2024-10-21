using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SLibrary.DataModel.Entities.SLibrary;

namespace SLibrary.DataModel.EntityConfiguration.SLibrary
{
    public class LibroCategoriaConfiguration : IEntityTypeConfiguration<LibroCategoria>
    {
        public void Configure(EntityTypeBuilder<LibroCategoria> builder)
        {
            builder.ToTable("LibroCategoria");
            builder.HasKey(x => x.Id).HasName("LibroCategoriaId");
        }
    }
}

