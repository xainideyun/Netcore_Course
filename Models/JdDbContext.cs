using HT.P1.Jwt_Swagger.Models.Enums;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace HT.P1.Jwt_Swagger.Models
{
    public class JdDbContext : DbContext
    {
        public JdDbContext([NotNull] DbContextOptions options) : base(options)
        {
        }

        public DbSet<Home> Homes { get; set; }
        public DbSet<Desk> Desks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Home>().HasData(new Home { Id = 1, Address = "武汉市东湖高新区", Age = 3, HostName = "华天晓", Lat = 123.12, Lng = 31.234556 });
            modelBuilder.Entity<Desk>().HasData(
                new Desk { Id = 1, Cost = 600, HomeId = 1, Shape = Shape.Circle, BuyTime = DateTime.Now.AddDays(-1203) },
                new Desk { Id = 2, Cost = 123.5, HomeId = 1, Shape = Shape.Square, BuyTime = DateTime.Now.AddDays(-647) }
                );
        }

    }
}
