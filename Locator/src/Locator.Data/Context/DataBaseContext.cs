using Locator.Business.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Locator.Data.Context
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions options)
        : base(options)
        {

        }

        public DbSet<Car> Cars { get; set; }
        public DbSet<Characteristic> Characteristics { get; set; }
        public DbSet<Optional> Opcionals { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var property in modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetProperties()
                    .Where(p => p.ClrType == typeof(string))))
                property.SetColumnType("varchar(100)");

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DataBaseContext).Assembly);

            //Para não deletar dados em cascata
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys())) relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;

            base.OnModelCreating(modelBuilder);
        }
    }
}
