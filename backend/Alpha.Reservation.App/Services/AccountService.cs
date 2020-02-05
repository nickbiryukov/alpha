using System;
using System.Threading.Tasks;
using Alpha.Reservation.App.Hashing.Contracts;
using Alpha.Reservation.App.JwtAuthentication.Contracts;
using Alpha.Reservation.App.JwtAuthentication.Models;
using Alpha.Reservation.App.Models.AccountModels;
using Alpha.Reservation.App.Services.Contracts;

namespace Alpha.Reservation.App.Services
{
    public class AccountService : IAccountService
    {
        private readonly ITokenProvider _tokenProvider;
        private readonly IUserService _userService;
        private readonly IHashProvider _hashProvider;

        public AccountService(ITokenProvider tokenProvider, IUserService userService, IHashProvider hashProvider)
        {
            _tokenProvider = tokenProvider;
            _userService = userService;
            _hashProvider = hashProvider;
        }

        public async Task<TokenModel> Login(LoginModel loginModel)
        {
            var user = await _userService.FirstOrDefaultAsync(a => a.Login == loginModel.Login) ??
                       throw new Exception("User not found");

            if (!_hashProvider.Validate(loginModel.Password, user.PasswordHash))
                throw new Exception("Wrong password");

            var jwtTokenContext = new JwtTokenContext
            {
                UserId = user.Id,
                Login = loginModel.Login,
                Role = user.RoleId
            };

            return _tokenProvider.CreateToken(jwtTokenContext);
        }

        public TokenModel RefreshToken(RefreshTokenModel tokenModel)
        {
            return _tokenProvider.RefreshToken(tokenModel);
        }
    }
}