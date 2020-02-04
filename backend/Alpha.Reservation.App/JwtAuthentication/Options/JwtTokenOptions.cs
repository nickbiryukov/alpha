using System;
using Microsoft.IdentityModel.Tokens;

namespace Alpha.Reservation.App.JwtAuthentication.Options
{
    public class JwtTokenOptions
    {
        public SecurityKey SecurityKey { get; set; }

        public string Issuer { get; set; }

        public TimeSpan LifeTime { get; set; }

        public JwtTokenOptions()
        {
            LifeTime = TimeSpan.FromDays(7);
        }
    }
}