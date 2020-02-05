using System.Threading.Tasks;
using Alpha.Reservation.App.JwtAuthentication.Models;
using Alpha.Reservation.App.Models.AccountModels;
using Alpha.Reservation.App.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Alpha.Reservation.API.Controllers
{
    [AllowAnonymous]
    [ApiController]
    [Route("api/[controller]")]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountsController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost("Login")]
        public async Task<TokenModel> Login([FromBody] LoginModel loginModel)
        {
            return await _accountService.Login(loginModel);
        }

        [HttpPost("Refresh")]
        public TokenModel Refresh([FromBody] RefreshTokenModel tokenModel)
        {
            return _accountService.RefreshToken(tokenModel);
        }
    }
}