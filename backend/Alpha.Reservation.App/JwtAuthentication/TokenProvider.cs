using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using Alpha.Reservation.App.JwtAuthentication.Contracts;
using Alpha.Reservation.App.JwtAuthentication.Models;
using Alpha.Reservation.App.JwtAuthentication.Options;
using Alpha.Reservation.App.Models.AccountModels;
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
            var claimsIdentity = GetClaimsIdentity(jwtTokenContext);

            return CreateToken(claimsIdentity);
        }

        public TokenModel RefreshToken(RefreshTokenModel tokenModel)
        {
            var jwtToken = new JwtSecurityTokenHandler().ReadJwtToken(tokenModel.OldToken);
            var claimsIdentity = new ClaimsIdentity(jwtToken.Claims);

            return CreateToken(claimsIdentity);
        }

        private TokenModel CreateToken(ClaimsIdentity claimsIdentity)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateJwtSecurityToken(new SecurityTokenDescriptor
            {
                Issuer = _jwtTokenOptions.Issuer,
                Subject = claimsIdentity,
                SigningCredentials = GetSigningCredentials(),
                Expires = _jwtTokenOptions.GetExpires()
            });

            return new TokenModel
            {
                Value = tokenHandler.WriteToken(token),
                Expiration = token.ValidTo,
                Type = "Bearer"
            };
        }

        private static ClaimsIdentity GetClaimsIdentity(JwtTokenContext jwtTokenContext)
        {
            return new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.NameIdentifier, jwtTokenContext.UserId.ToString()),
                new Claim(ClaimTypes.Name, jwtTokenContext.Login),
                new Claim(ClaimTypes.Role, jwtTokenContext.Role.GetDescription())
            });
        }

        private SigningCredentials GetSigningCredentials()
        {
            return new SigningCredentials(
                _jwtTokenOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256Signature);
        }
    }
}