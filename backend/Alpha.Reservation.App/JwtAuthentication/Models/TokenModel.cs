using System;

namespace Alpha.Reservation.App.JwtAuthentication.Models
{
    public class TokenModel
    {
        public string Value { get; set; }

        public string Type { get; set; }

        public DateTime Expiration { get; set; }
    }
}