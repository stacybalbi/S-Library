using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SLibrary.DataModel.Entities.SLibrary;

namespace SLibrary.DataModel.EntityConfiguration.SLibrary
{
    public class CategoriaConfiguration : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            builder.ToTable("Categoria");
            builder.HasKey(x => x.Id).HasName("CategoriaId");
            builder.Property(x => x.Nombre).IsRequired().HasMaxLength(1000);
        }
    }
}

