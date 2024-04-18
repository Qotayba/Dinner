using BuberDinner.Application.Comman.Erorrs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace BuberDinner.Api.Filters
{
    public class ErorrHandlingFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            if (context.Exception is null)
            {
                return;
            }
            var (statusCode, message) = (context.Exception) switch
            {
                IServiceException serviceExpetion => (serviceExpetion.StatusCode, serviceExpetion.ErorrMessage),
                _ =>(HttpStatusCode.InternalServerError,"An unexpected erorr occaure ")
            };
            var problemDetails = new ProblemDetails
            {
                Title = message,
                Status = (int)statusCode
            };
            context.Result = new ObjectResult(problemDetails);
            context.ExceptionHandled = true;
        }

    }
}
