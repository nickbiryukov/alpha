using System;

namespace Alpha.Reservation.App.Models.RoomModels
{
    public class RoomModel
    {
        public Guid Id { get; set; }
        
        public string Name { get; set; }

        public bool Projector { get; set; }

        public bool Board { get; set; }

        public int Seat { get; set; }

        public string Description { get; set; }
    }
}