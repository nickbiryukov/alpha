using System;
using System.Collections.Generic;
using Alpha.Reservation.Domain.Common;

namespace Alpha.Reservation.Domain.Entities
{
    public class User : EntityBase<Guid>
    {
        public string Login { get; set; }
        
        public string Password { get; set; }
        
        public string Name { get; set; }
        
        public string Surname { get; set; }
        
        public virtual Role Role { get; set; }
        
        public virtual ICollection<Reservation> Reservations { get; set; }

        public User(Guid id, string login, string password, string name, string surname) : base(id)
        {
            Login = login;
            Password = password;
            Name = name;
            Surname = surname;

            Reservations = new List<Reservation>();
        }
    }
}