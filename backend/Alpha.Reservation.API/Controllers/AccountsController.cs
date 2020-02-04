using System.Threading.Tasks;
using Alpha.Reservation.App.JwtAuthentication.Models;
using Alpha.Reservation.App.Models.AccountModels;
using Microsoft.AspNetCore.Mvc;

namespace Alpha.Reservation.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountsController : ControllerBase
    {
        [HttpPost]
        public TokenModel Login([FromBody] LoginModel loginModel)
        {
            return new TokenModel();
        }
    }
}