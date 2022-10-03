using Microsoft.AspNetCore.Mvc;

namespace Itau.Api.Controllers
{
    [ApiController]
    [Route("v1/[controller]")]
    public class HomeController : ControllerBase
    {
        [HttpGet, Route("")]
        public IActionResult IndexAsync()
            => Ok(DateTime.Now.ToString("dd/MM/yyyy"));
    }
}
