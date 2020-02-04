using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using Alpha.Reservation.App.JwtAuthentication.Contracts;
using Alpha.Reservation.App.JwtAuthentication.Models;
using Alpha.Reservation.App.JwtAuthentication.Options;
using Alpha.Reservation.Extensions;
using Microsoft.IdentityModel.Tokens;

namespace Alpha.Reservation.App.JwtAuthentication
{
    public class TokenProvider : ITokenProvider
    {
        private readonly JwtTokenOptions _jwtTokenOptions;

        public TokenProvider(JwtTokenOptions jwtTokenOptions)
        {
            _jwtTokenOptions = jwtTokenOptions;
        }

        public TokenModel CreateToken(JwtTokenContext jwtTokenContext)
        {
            var claimsIdentity = CreateClaimsIdentity(jwtTokenContext);

            return CreateToken(claimsIdentity);
        }

        public TokenModel RefreshToken(string oldToken)
        {
            var jwtToken = new JwtSecurityTokenHandler().ReadJwtToken(oldToken);
            var claimsIdentity = new ClaimsIdentity(new GenericIdentity(jwtToken.Subject), jwtToken.Claims);

            return CreateToken(claimsIdentity);
        }

        private TokenModel CreateToken(ClaimsIdentity claimsIdentity)
        {
            var credentials =
                new SigningCredentials(_jwtTokenOptions.SecurityKey, SecurityAlgorithms.HmacSha256Signature);
            
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(new SecurityTokenDescriptor
            {
                Subject = claimsIdentity,
                Expires = DateTime.UtcNow.AddDays(_jwtTokenOptions.LifeTime.Days),
                SigningCredentials = credentials
            });

            return new TokenModel
            {
                Value = tokenHandler.WriteToken(token),
                Expiration = token.ValidTo,
                Type = "bearer"
            };
        }
        
        private static ClaimsIdentity CreateClaimsIdentity(JwtTokenContext jwtTokenContext)
        {
            return new ClaimsIdentity(new GenericIdentity(jwtTokenContext.Login), new []
            {
                new Claim(ClaimTypes.Name, jwtTokenContext.Login),
                new Claim(ClaimTypes.Role, jwtTokenContext.Role.GetDescription())
            });
        }
    }
}