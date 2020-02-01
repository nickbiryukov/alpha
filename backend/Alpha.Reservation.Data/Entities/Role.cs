using System.Collections.Generic;
using Alpha.Reservation.Data.Entities.Enums;
using Alpha.Reservation.Extensions;

namespace Alpha.Reservation.Data.Entities
{
    public class Role
    {
        public ERole Id { get; set; }
        
        public string Name { get; set; }

        public virtual ICollection<User> Users { get; set; }

        public Role()
        {
            Users = new List<User>();
        }

        public Role(ERole id)
        {
            Id = id;
            Name = id.GetDescription();
            
            Users = new List<User>();
        }
    }
}