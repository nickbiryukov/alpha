using Microsoft.AspNetCore.Mvc;

namespace Alpha.Reservation.API.Controllers
{
    [ApiController]
    [Route("")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class HomeController : ControllerBase
    {
        public IActionResult Index()
        {
            return new RedirectResult("api/help");
        }
    }
}