using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ExceptionHandling.Filters
{
    public class CustomExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            var controllerName = context.RouteData.Values["controller"];
            var actionName = context.RouteData.Values["action"];

            string message = $"\nTime: {DateTime.Now}, Controller: {controllerName}, Action: {actionName}, Exception: {context.Exception.Message}";
      
            System.IO.Directory.CreateDirectory(Path.Combine(Directory.GetCurrentDirectory(), "Log"));

            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "Log", "Log.txt");
            //saving the data in a text file called Log.txt
            File.AppendAllText(filePath, message);
        }
    }
}
