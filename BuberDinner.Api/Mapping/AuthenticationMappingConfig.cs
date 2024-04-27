using BuberDinner.Application.Authentication.Comman;
using BuberDinner.Contracts.Authentication;
using Mapster;
using Microsoft.AspNetCore.Routing.Constraints;

namespace BuberDinner.Api.Mapping
{
    public class AuthenticationMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<AuthenticationResult, AuthenticationResponse>()
                .Map(dest => dest.Token, src => src.Token)
                .Map(dest => dest, src => src.User);
        }
    }
}
