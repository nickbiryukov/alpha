using System;
using Alpha.Reservation.Data.Entities.Enums;

namespace Alpha.Reservation.API.Utils
{
    public class RoleAttribute : Attribute
    {
        public ERole[] Roles { get; }
        
        public RoleAttribute(params ERole[] roles)
        {
            Roles = roles;
        }
    }
}