using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SLibrary.DataModel.Entities.SLibrary;

namespace SLibrary.DataModel.EntityConfiguration.SLibrary
{
	public class AutorConfiguration : IEntityTypeConfiguration<Autor>
	{

        public void Configure(EntityTypeBuilder<Autor> builder)
        {
            builder.ToTable("Autor");
            builder.HasKey(x => x.Id).HasName("AutorId");
            builder.Property(x => x.Nombre).IsRequired().HasMaxLength(1000);
        }
    }
}

