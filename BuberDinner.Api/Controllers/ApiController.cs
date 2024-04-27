﻿
using ErrorOr;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Reflection.Metadata.Ecma335;

namespace BuberDinner.Api.Controllers
{
    
    [ApiController]
    public class ApiController : ControllerBase
    {
        protected IActionResult Problem(List<Error> errors) 
        { 
            if (errors.All(error=> error.Type == ErrorType.Validation))
            {
                return ValidationProblems(errors);
            }
            var firstError= errors[0];
            var statusCode = firstError.Type switch
            {
                ErrorType.Conflict => StatusCodes.Status409Conflict,
                ErrorType.Validation => StatusCodes.Status400BadRequest,
                ErrorType.NotFound => StatusCodes.Status404NotFound,
                _ => StatusCodes.Status500InternalServerError
            };
            return Problem(statusCode: statusCode, title: firstError.Description);
        }

        private IActionResult ValidationProblems(List<Error> errors)
        {
            var modelStateDictionary = new ModelStateDictionary();
            foreach (var error in errors)
            {
                modelStateDictionary.AddModelError(
                    error.Code,
                    error.Description
                    );
            }
            return ValidationProblem(modelStateDictionary);
        }



    }
}
