using Alpha.Reservation.App.JwtAuthentication.Models;

namespace Alpha.Reservation.App.JwtAuthentication.Contracts
{
    public interface ITokenProvider
    {
        TokenModel CreateToken(JwtTokenContext jwtTokenContext);

        TokenModel RefreshToken(string oldToken);
    }
}