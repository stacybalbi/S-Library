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

        }
    }
}

