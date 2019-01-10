using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LatestAngular.Models;
using Microsoft.EntityFrameworkCore;

namespace LatestAngular.Data
{
    public class AspNetCoreAndAngularContext: DbContext
    {
        public AspNetCoreAndAngularContext(DbContextOptions<AspNetCoreAndAngularContext> options) : base(options) { }

        public DbSet<Vehicle> Vehicle { get; set; }
        public DbSet<Make> Makes { get; set; }
        public DbSet<Feature> Features { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VehicleFeature>().HasKey(vf => new {vf.VehicleId, vf.FeatureId});
        }
    }
}
