using System.Collections.Generic;
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

            builder
                .HasData(new List<Role>
                {
                    new Role(ERole.OfficeManager),
                    new Role(ERole.Employee)
                });
        }
    }
}