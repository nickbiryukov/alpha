using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Alpha.Reservation.Data.EntitiesConfigurations
{
    public class ReservationConfiguration : IEntityTypeConfiguration<Entities.Reservation>
    {
        public void Configure(EntityTypeBuilder<Entities.Reservation> builder)
        {
            builder.HasKey(a => a.Id);

            builder
                .HasOne(a => a.Room)
                .WithMany(a => a.Reservations)
                .HasForeignKey(a => a.RoomId);

            builder
                .HasOne(a => a.User)
                .WithMany(a => a.Reservations)
                .HasForeignKey(a => a.UserId);
        }
    }
}