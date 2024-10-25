using Application.Models.Requests;

namespace Application.Interfaces
{
    public interface ICustomAuthenticationServices
    {
         Task<string> Authenticate(AuthRequest request);

    }
}
