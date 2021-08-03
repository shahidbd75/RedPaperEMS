using System;
using System.Threading.Tasks;
using RedPaperEMS.Application.Models.Authentication;

namespace RedPaperEMS.Application.Contracts
{
    public interface IAuthenticationService
    {
        Task<AuthenticationResponse> AuthenticateAsync(AuthenticationRequest request);
        Task<RegistrationResponse> RegisterAsync(RegistrationRequest request);
    }
}
