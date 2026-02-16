using AM.applicationcore.Domain;
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

    }
}
