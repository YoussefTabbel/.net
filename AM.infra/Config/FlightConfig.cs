using AM.applicationcore.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.infra.Config
{
    public class FlightConfig : IEntityTypeConfiguration<Flight>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Flight> builder)
        {
            builder.HasMany(p=>p.Passengers).WithMany(f=>f.Flights)
                .UsingEntity(j=>j.ToTable("Reservation")); 
            builder.HasOne( p=> p.Plane).WithMany(f => f.Flights).HasForeignKey(fk => fk.PlaneFk);
        }
    }
}
