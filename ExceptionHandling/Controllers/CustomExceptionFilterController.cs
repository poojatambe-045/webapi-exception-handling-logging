using ExceptionHandling.Filters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExceptionHandling.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomExceptionFilterController : ControllerBase
    {
        [HttpGet]
        [CustomExceptionFilter]
        public IActionResult Get()
        {
            throw new NotImplementedException();
        }
    }
}
