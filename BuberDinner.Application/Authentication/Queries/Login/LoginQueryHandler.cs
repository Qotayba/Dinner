using BuberDinner.Application.Authentication.Comman;
using BuberDinner.Application.Comman.Interfaces.Authetication;
using BuberDinner.Application.Comman.Interfaces.Persistence;

using BuberDinner.Domain.Entities;
using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuberDinner.Application.Authentication.Queries.Login
{
    public class LoginQueryHandler : IRequestHandler<LoginQuery, ErrorOr<AuthenticationResult>>
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IUserRepository _userRepository;

        public LoginQueryHandler(IJwtTokenGenerator jwtTokenGenerator,
            IUserRepository userRepository)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
            _userRepository = userRepository;
        }
        public async Task<ErrorOr<AuthenticationResult>> Handle(LoginQuery query , CancellationToken cancellationToken)
        {
            if (_userRepository.getUserByEmail(query.Email) is not User user)
            {
                return Domain.Common.Errors.Error.Authentication.InvalidCredential;
            }

            // 2- Validate if the password is correct
            if (user.Password != query.Password)
            {
                return Domain.Common.Errors.Error.Authentication.InvalidCredential;
            }
            var token = _jwtTokenGenerator.GenerateToken(user);
            return new AuthenticationResult(
                user,
                token);
        }
    }
}
