using System.Threading.Tasks;
using Alpha.Reservation.App.JwtAuthentication.Models;
using Alpha.Reservation.App.Models.AccountModels;

namespace Alpha.Reservation.App.Services.Contracts
{
    public interface IAccountService
    {
        Task<TokenModel> Login(LoginModel loginModel);
        TokenModel RefreshToken(RefreshTokenModel tokenModel);
    }
}