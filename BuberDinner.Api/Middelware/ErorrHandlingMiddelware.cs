using System.Net;
using System.Text.Json;

namespace BuberDinner.Api.Middelware
{
    public class ErorrHandlingMiddelware
    {
        private readonly RequestDelegate _next;

        public ErorrHandlingMiddelware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context) 
        {
            try 
            {
                await _next(context);
            }
            catch(Exception exception) 
            {
                await HandelExceptionAsync(context, exception);
                
            }
        }
        private static Task HandelExceptionAsync(HttpContext context,Exception exception)
        {
            var statusCode =HttpStatusCode.InternalServerError;
            var result = JsonSerializer.Serialize(new { erorr = "an erorr occaudrd while prossising the response " });
            context.Response.ContentType = "application/json";
            context.Response.StatusCode =(int) statusCode;
            return context.Response.WriteAsync(result);
        }
    }
}
