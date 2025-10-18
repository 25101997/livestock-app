using Microsoft.AspNetCore.Mvc;

namespace API.Application.Controllers
{
    [ApiController]
    [Route("/")]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Server is running...");
        }
    }
}