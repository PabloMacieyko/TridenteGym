using Application.DTOs.Requests;

namespace Application.Interfaces
{
    public interface ICustomAuthentication
    {
        Task<string> AutenticarAsync(AuthenticationRequest authenticationRequest);
    }
}
