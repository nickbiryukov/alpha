using System;
using System.Collections.ObjectModel;
using Alpha.Reservation.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Alpha.Reservation.Data.EntitiesConfigurations
{
    public class RoomConfiguration: IEntityTypeConfiguration<Room>
    {
        public void Configure(EntityTypeBuilder<Room> builder)
        {
            builder.HasKey(a => a.Id);

            builder.Property(a => a.Name).HasMaxLength(100);
            builder.Property(a => a.Description).HasMaxLength(500);
            builder.Property(a => a.Seat).HasMaxLength(1000);
            
            builder
                .HasMany(a => a.Reservations)
                .WithOne(a => a.Room)
                .HasForeignKey(a => a.RoomId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasData(new Collection<Room>
                {
                    new Room
                    {
                        Id = Guid.Parse("10000000-0000-0000-0000-000000000000"),
                        Name = "Room 402",
                        Description = "Small room",
                        Projector = true,
                        Board = true,
                        Seat = 10
                    },
                    new Room
                    {
                        Id = Guid.Parse("20000000-0000-0000-0000-000000000000"),
                        Name = "Room 112",
                        Description = "Medium room",
                        Projector = false,
                        Board = false,
                        Seat = 30
                    },
                    new Room
                    {
                        Id = Guid.Parse("30000000-0000-0000-0000-000000000000"),
                        Name = "Room 54",
                        Description = "Large room",
                        Projector = true,
                        Board = false,
                        Seat = 50
                    }
                });
        }
    }
}