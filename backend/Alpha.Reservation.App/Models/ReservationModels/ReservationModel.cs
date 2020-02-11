using System;

namespace Alpha.Reservation.App.Models.ReservationModels
{
    public class ReservationModel
    {
        public Guid Id { get; set; }
        
        public string Title { get; set; }
        
        public string Description { get; set; }
        
        public DateTimeOffset ReservationStart { get; set; }
        
        public DateTimeOffset ReservationEnd { get; set; }        

        public bool? IsConfirmed { get; set; }

        public Guid UserId { get; set; }

        public Guid RoomId { get; set; }
    }
}