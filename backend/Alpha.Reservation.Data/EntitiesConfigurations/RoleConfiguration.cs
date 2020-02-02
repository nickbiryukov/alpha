using System.Collections.Generic;
using System.Collections.ObjectModel;
using Alpha.Reservation.Data.Entities;
using Alpha.Reservation.Data.Entities.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Alpha.Reservation.Data.EntitiesConfigurations
{
    public class RoleConfiguration: IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasKey(a => a.Id);

            builder.Property(a => a.Name).HasMaxLength(20);
            
            builder
                .HasData(new Collection<Role>
                {
                    new Role(ERole.OfficeManager),
                    new Role(ERole.Employee)
                });
        }
    }
}