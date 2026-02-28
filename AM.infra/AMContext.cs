using AM.applicationcore.Domain;
using AM.infra.Config;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.infra
{
    public class AMContext : DbContext
    {
        //1-Dbset:
        public DbSet<Flight> Flights { get; set; }
        public DbSet<Plane> Planes { get; set; }
        public DbSet<Passenger> Passengers { get; set; }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<Traveller> Travellers { get; set; }

        // 2-chain configuration:
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer

  (@"Data Source=(localdb)\mssqllocaldb;

    Initial Catalog=AMSIM1;

    Integrated Security=true;

    MultipleActiveResultSets=true");
        }
        // FluentApi
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //1ere methode
            modelBuilder.ApplyConfiguration(new PlaneConfiguration());
            modelBuilder.ApplyConfiguration(new FlightConfig());
            //2eme methode
            //TPH
            //modelBuilder.Entity<Passenger>().HasDiscriminator<int>("PassengerType")
            //    .HasValue<Passenger>(0)
            //    .HasValue<Traveller>(1)
            //    .HasValue<Staff>(2);
            //TPT
            modelBuilder.Entity<Traveller>().ToTable("Travellers");
                modelBuilder.Entity<Staff>().ToTable("Staffs");
        }

        //pre-conventions
        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)

        {
            base.ConfigureConventions(configurationBuilder);
          //  configurationBuilder.Properties<String>().HaveMaxLength(100);
            configurationBuilder.Properties<DateTime>().HaveColumnType("date");
        }
    }
}
