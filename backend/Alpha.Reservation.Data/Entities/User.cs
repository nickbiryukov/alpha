using System;
using System.Collections.Generic;
using Alpha.Reservation.Data.Entities.Enums;

namespace Alpha.Reservation.Data.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        
        public string Login { get; set; }
        
        public string PasswordHash { get; set; }
        
        public string Name { get; set; }
        
        public string Surname { get; set; }

        public ERole RoleId { get; set; }
        
        public virtual Role Role { get; set; }
        
        public virtual ICollection<Reservation> Reservations { get; set; }

        public User()
        {
            Reservations = new List<Reservation>();
        }
    }
}