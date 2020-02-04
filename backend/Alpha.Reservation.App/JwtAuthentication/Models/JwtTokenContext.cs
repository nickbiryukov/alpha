using System;
using Alpha.Reservation.Data.Entities.Enums;

namespace Alpha.Reservation.App.JwtAuthentication.Models
{
    public class JwtTokenContext
    {
        public Guid UserId { get; set; }

        public string Login { get; set; }

        public ERole Role { get; set; }
    }
}