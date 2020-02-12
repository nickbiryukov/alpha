using System;

namespace Alpha.Reservation.App.Models.ReservationModels
{
    public class ShortReservationModel
    {
        public string Title { get; set; }
        
        public string Description { get; set; }
        
        public DateTime Date { get; set; }

        public TimeSpan BeginTime { get; set; }

        public TimeSpan EndTime { get; set; }        

        public bool? IsConfirmed { get; set; }

        public Guid UserId { get; set; }

        public Guid RoomId { get; set; }
    }
}