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
            builder.Property(a => a.Password).IsRequired().HasMaxLength(50);
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
                        Password = "test",
                        RoleId = ERole.OfficeManager
                    },
                    new User
                    {
                        Id = Guid.NewGuid(),
                        Login = "Employee",
                        Name = "EmployeeName",
                        Surname = "EmployeeSurname",
                        Password = "test",
                        RoleId = ERole.Employee
                    }
                });
        }
    }
}