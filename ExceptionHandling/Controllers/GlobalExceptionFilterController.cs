using Microsoft.AspNetCore.Mvc;
using ExceptionHandling.Filters;

namespace ExceptionHandling.Controllers
{
     [ApiController]
    [Route("[controller]")]
    public class ExceptionFilterController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            throw new NotImplementedException();
        }
    }
}
