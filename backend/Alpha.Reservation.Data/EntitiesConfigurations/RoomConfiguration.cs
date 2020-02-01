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
        }
    }
}