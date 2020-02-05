using Alpha.Reservation.App.JwtAuthentication.Models;
using Alpha.Reservation.App.Models.AccountModels;

namespace Alpha.Reservation.App.JwtAuthentication.Contracts
{
    public interface ITokenProvider
    {
        TokenModel CreateToken(JwtTokenContext jwtTokenContext);

        TokenModel RefreshToken(RefreshTokenModel tokenModel);
    }
}