using System;

namespace Alpha.Reservation.Data.Entities
{
    public class Reservation
    {
        public Guid Id { get; set; }
        
        public string Title { get; set; }
        
        public string Description { get; set; }
        
        public DateTimeOffset ReservationStart { get; set; }
        
        public DateTimeOffset ReservationEnd { get; set; }        

        public bool IsConfirmed { get; set; }

        public Guid UserId { get; set; }

        public Guid RoomId { get; set; }
        
        public virtual User User { get; set; }
        
        public virtual Room Room { get; set; }

        public Reservation()
        {
            
        }
    }
}