using System;
using System.Collections.Generic;
using Alpha.Reservation.Data.Entities;
using Alpha.Reservation.Data.Entities.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Alpha.Reservation.Data.EntitiesConfigurations
{
    public class UserConfiguration: IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(a => a.Id);

            builder
                .HasOne(a => a.Role)
                .WithMany(a => a.Users)
                .HasForeignKey(a => a.RoleId);

            builder
                .HasData(new List<User>
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