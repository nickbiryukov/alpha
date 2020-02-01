using System;
using Alpha.Reservation.Domain.Common;

namespace Alpha.Reservation.Domain.Entities
{
    public class Reservation : EntityBase<Guid>
    {
        public string Description { get; set; }
        
        public DateTimeOffset ReservationStart { get; set; }
        
        public DateTimeOffset ReservationEnd { get; set; }        

        public bool IsConfirmed { get; set; }

        public virtual User User { get; set; }
        
        public virtual Room Room { get; set; }

        public Reservation(Guid id, string description, DateTimeOffset reservationStart, DateTimeOffset reservationEnd, 
            bool isConfirmed) : base(id)
        {
            Description = description;
            ReservationStart = reservationStart;
            ReservationEnd = reservationEnd;
            IsConfirmed = isConfirmed;
        }
    }
}