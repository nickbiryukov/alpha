using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace Alpha.Reservation.API.Options
{
    public class JwtAuthenticationOptions
    {
        public string SecurityKey { get; set; }

        public string Issuer { get; set; }
        
        public SymmetricSecurityKey GetSymmetricSecurityKey() =>
            new SymmetricSecurityKey(Encoding.ASCII.GetBytes(SecurityKey));
    }
}