using BuberDinner.Application.Authentication.Comman;
using BuberDinner.Application.Authentication.Commands.Register;
using BuberDinner.Application.Authentication.Queries.Login;
using BuberDinner.Contracts.Authentication;
using ErrorOr;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Runtime.CompilerServices;

namespace BuberDinner.Api.Controllers
{
    [Route("auth")]
    [ApiController]
    public class AuthenticationController : ApiController
    {
        private readonly ISender _mediator;
        private readonly IMapper _mapper;

        public AuthenticationController(ISender mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            var command = _mapper.Map<RegisterCommand>(request);
            ErrorOr<AuthenticationResult> authResult =await  _mediator.Send(command);
            return authResult.Match(
                    authResult => Ok(_mapper.Map<AuthenticationResponse>(authResult)),
                    errors => Problem(errors)
                );
          

        }

        

        [HttpPost("login")]
        public async Task<IActionResult> login(LoginRequest request)
        {
            var query = _mapper.Map<LoginQuery>(request);
            ErrorOr<AuthenticationResult> authResult = await  _mediator.Send(query);
                
            return authResult.Match(
                authResult => Ok(_mapper.Map<AuthenticationResponse>(authResult)),
                errors => Problem(errors)
                );
           

        }
       

    }

}
