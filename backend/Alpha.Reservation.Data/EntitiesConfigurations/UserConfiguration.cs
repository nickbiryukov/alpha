using System;
using System.Collections.ObjectModel;
using Alpha.Reservation.Data.Entities;
using Alpha.Reservation.Data.Entities.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Alpha.Reservation.Data.EntitiesConfigurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(a => a.Id);

            builder.Property(a => a.Login).IsRequired().HasMaxLength(50);
            builder.Property(a => a.PasswordHash).IsRequired().HasMaxLength(100);
            builder.Property(a => a.Name).HasMaxLength(100);
            builder.Property(a => a.Surname).HasMaxLength(100);

            builder
                .HasOne(a => a.Role)
                .WithMany(a => a.Users)
                .HasForeignKey(a => a.RoleId);

            builder
                .HasMany(a => a.Reservations)
                .WithOne(a => a.User)
                .HasForeignKey(a => a.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasData(new Collection<User>
                {
                    new User
                    {
                        Id = Guid.NewGuid(),
                        Login = "Manager",
                        Name = "ManagerName",
                        Surname = "ManagerSurname",
                        PasswordHash = "9xHnygSC9V42fWBY8eqA8Q==.Yif8svarnDn8f+N3bhQ/6MyUSSIoo55uXIWv9XtFxyE=",
                        RoleId = ERole.OfficeManager
                    },
                    new User
                    {
                        Id = Guid.NewGuid(),
                        Login = "Employee",
                        Name = "EmployeeName",
                        Surname = "EmployeeSurname",
                        PasswordHash = "9xHnygSC9V42fWBY8eqA8Q==.Yif8svarnDn8f+N3bhQ/6MyUSSIoo55uXIWv9XtFxyE=",
                        RoleId = ERole.Employee
                    }
                });
        }
    }
}