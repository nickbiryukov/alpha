using System;
using Alpha.Reservation.App.Models.RoomModels;
using Alpha.Reservation.App.Models.UserModels;

namespace Alpha.Reservation.App.Models.ReservationModels
{
    public class ReservationWithDetailsModel
    {
        public Guid Id { get; set; }
        
        public string Title { get; set; }
        
        public string Description { get; set; }
        
        public DateTimeOffset ReservationStart { get; set; }
        
        public DateTimeOffset ReservationEnd { get; set; }        

        public bool? IsConfirmed { get; set; }

        public UserModel User { get; set; }

        public RoomModel Room { get; set; }
    }
}