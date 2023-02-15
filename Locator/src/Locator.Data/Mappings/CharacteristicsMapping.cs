using Locator.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locator.Data.Mappings
{
    public class CharacteristicsMapping : IEntityTypeConfiguration<Characteristics>
    {
        public void Configure(EntityTypeBuilder<Characteristics> builder)
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
