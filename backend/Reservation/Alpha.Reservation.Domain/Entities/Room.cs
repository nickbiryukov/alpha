using System;
using System.Collections.Generic;
using Alpha.Reservation.Domain.Common;

namespace Alpha.Reservation.Domain.Entities
{
    public class Room : EntityBase<Guid>
    {
        public string Name { get; set; }

        public bool Projector { get; set; }

        public bool Board { get; set; }

        public string Seat { get; set; }

        public string Description { get; set; }
        
        public virtual ICollection<Reservation> Reservations { get; set; }

        public Room(Guid id, string name, bool projector, bool board, string seat, string description) : base(id)
        {
            Name = name;
            Projector = projector;
            Board = board;
            Seat = seat;
            Description = description;
            
            Reservations = new List<Reservation>();
        }
    }
}