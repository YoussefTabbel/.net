using AM.applicationcore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.infra.Config
{
    public class PlaneConfiguration : IEntityTypeConfiguration<Plane>
    {
        public void Configure(EntityTypeBuilder<Plane> builder)
        {
            builder.HasKey(k => k.PlaneId); // Clé primaire
            builder.ToTable("MyPlanes"); // Renommer la table 
            builder.Property(k => k.Capacity).HasColumnName("PlaneCapacity"); // Renommer la colonne
        }
    }
}
