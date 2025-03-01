using ExceptionHandling.Models;
using Microsoft.AspNetCore.Diagnostics;

namespace ExceptionHandling.Middleware
{
    public class NotImplementedExceptionHandler : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            if (exception is NotImplementedException)
            {
                var response = new ErrorResponse()
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Message = exception.Message,
                    Title = "Not Implemented Exception"
                };

                await httpContext.Response.WriteAsJsonAsync(response, cancellationToken);
                return true;
            }
            return false;
        }
    }
}
