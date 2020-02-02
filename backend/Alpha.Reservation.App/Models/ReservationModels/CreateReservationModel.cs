using System;

namespace Alpha.Reservation.App.Models.ReservationModels
{
    public class CreateReservationModel
    {
        public string Title { get; set; }
        
        public string Description { get; set; }
        
        public DateTimeOffset ReservationStart { get; set; }
        
        public DateTimeOffset ReservationEnd { get; set; }     

        public Guid UserId { get; set; }

        public Guid RoomId { get; set; }
    }
}