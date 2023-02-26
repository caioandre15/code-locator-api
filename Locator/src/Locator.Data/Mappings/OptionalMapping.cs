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
    public class OptionalMapping : IEntityTypeConfiguration<Optional>
    {
        public void Configure(EntityTypeBuilder<Optional> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(c => c.ElectricWindow)
                .IsRequired()
                .HasColumnType("bit");

            builder.Property(c => c.EletricLock)
                .IsRequired()
                .HasColumnType("bit");

            builder.Property(c => c.HydraulicSteering)
                .IsRequired()
                .HasColumnType("bit");

            builder.Property(c => c.AirBag)
                .IsRequired()
                .HasColumnType("bit");

            builder.Property(c => c.Abs)
                .IsRequired()
                .HasColumnType("bit");

            builder.Property(c => c.AutomaticTransmission)
                .IsRequired()
                .HasColumnType("bit");

            builder.Property(c => c.AirConditioning)
                .IsRequired()
                .HasColumnType("bit");

            builder.Property(c => c.QuantitiesOfDoorserty)
                .IsRequired()
                .HasColumnType("int");

            builder.Property(c => c.QuantitiesOfPeople)
                .IsRequired()
                .HasColumnType("int");

            builder.Property(c => c.QuantitiesOfBags)
                .IsRequired()
                .HasColumnType("int");

            builder.ToTable("Optionals");
        }
    }
}
