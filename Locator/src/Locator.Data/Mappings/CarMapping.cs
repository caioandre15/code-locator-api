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
    public class CarMapping : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(c => c.Name)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property(c => c.Brand)
                .IsRequired()
                .HasColumnType("varchar(20)");

            builder.Property(c => c.YearOfManufacture)
                .IsRequired()
                .HasColumnType("varchar(10)");

            builder.Property(c => c.Version)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property(c => c.Plate)
                .IsRequired()
                .HasColumnType("varchar(10)");

            builder.Property(c => c.TypeOfUse)
                .IsRequired()
                .HasColumnType("varchar(20)");

            builder.Property(c => c.Group)
                .IsRequired()
                .HasColumnType("varchar(20)");

            builder.Property(c => c.Description)
                .IsRequired()
                .HasColumnType("varchar(150)");

            // 1 : 1 => Car : Characteristics
            builder.HasOne(c => c.Characteristics)
                .WithOne(n => n.Car);

            // 1 : 1 => Consultant : Picture
            builder.HasOne(c => c.Optional)
                .WithOne(c => c.Car);

            builder.ToTable("Cars");
        }
    }
}
