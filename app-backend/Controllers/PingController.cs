using Microsoft.AspNetCore.Mvc;

namespace app_backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PingController : Controller
    {
        [HttpGet]
        public IActionResult Ping () {
            return StatusCode(200, "pong");
        }
    }
}
