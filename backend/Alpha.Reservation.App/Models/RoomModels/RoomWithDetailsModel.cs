using System;
using System.Collections.Generic;
using Alpha.Reservation.App.Models.ReservationModels;

namespace Alpha.Reservation.App.Models.RoomModels
{
    public class RoomWithDetailsModel
    {
        public Guid Id { get; set; }
        
        public string Name { get; set; }

        public bool Projector { get; set; }

        public bool Board { get; set; }

        public int Seat { get; set; }

        public string Description { get; set; }
        
        public List<ReservationModel> ReservationModels { get; set; }
    }
}