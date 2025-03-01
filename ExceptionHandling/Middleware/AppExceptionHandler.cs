using ExceptionHandling.Models;
using Microsoft.AspNetCore.Diagnostics;

namespace ExceptionHandling
{
    public class AppExceptionHandler: IExceptionHandler
    {
        public ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            if (exception is not NotImplementedException)
            {
                var response = new ErrorResponse()
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Message = exception.Message,
                    Title = "Something went wrong"
                };

                httpContext.Response.WriteAsJsonAsync(response, cancellationToken);
                return ValueTask.FromResult(true);
            }
            return ValueTask.FromResult(false);
        }
    }
}
