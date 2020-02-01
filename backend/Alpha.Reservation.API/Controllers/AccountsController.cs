using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Alpha.Reservation.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountsController : ControllerBase
    {
        [HttpGet]
        public bool Check()
        {
            return true;
        }
    }
}