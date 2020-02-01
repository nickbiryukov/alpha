using System;
using System.Collections.Generic;
using Alpha.Reservation.Domain.Common;

namespace Alpha.Reservation.Domain.Entities
{
    public class Role : EntityBase<Guid>
    {
        public string Name { get; set; }

        public virtual ICollection<User> Users { get; set; }

        public Role(Guid id, string name) : base(id)
        {
            Name = name;
            
            Users = new List<User>();
        }
    }
}