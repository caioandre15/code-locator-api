using Locator.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locator.Data.Mappings
{
    public class CharacteristicMapping : IEntityTypeConfiguration<Characteristic>
    {
        public void Configure(EntityTypeBuilder<Characteristic> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(c => c.Model)
                .IsRequired()
                .HasColumnType("varchar(20)");

            builder.Property(c => c.Motorization)
                .IsRequired()
                .HasColumnType("varchar(20)");

            builder.Property(c => c.Color)
                .IsRequired()
                .HasColumnType("varchar(20)");

            builder.Property(c => c.TransportLoadCapacity)
                .IsRequired()
                .HasColumnType("varchar(20)");

            builder.ToTable("Characteristics");
        }
    }
}
