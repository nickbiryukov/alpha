using System;

namespace Alpha.Reservation.API.Options
{
    public class JwtTokenOptions
    {
        public string SecurityKey { get; set; }

        public string Issuer { get; set; }

        public TimeSpan LifeTime { get; set; }

        public JwtTokenOptions()
        {
            LifeTime = TimeSpan.FromDays(7);
        }
    }
}