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
        }
    }
}