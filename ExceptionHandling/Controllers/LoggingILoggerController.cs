using Microsoft.AspNetCore.Mvc;

namespace ExceptionHandling.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoggingILoggerController : ControllerBase
    {
        private readonly ILogger<LoggingILoggerController> _logger;
        public LoggingILoggerController(ILogger<LoggingILoggerController> logger)
        {
            _logger = logger;
        }
        [HttpGet]
        public IActionResult Get()
        {
            _logger.LogInformation("Start");
            _logger.LogCritical("LogCritical");
            //_logger.LogDebug("LogDebug");
            _logger.LogWarning("This is a warning");
            _logger.LogError(new Exception(), "demo exception");
            _logger.LogInformation($"Action excecuted on: {DateTime.Now.TimeOfDay}");
            _logger.LogInformation("End");
            return Ok();
        }
    }
}
