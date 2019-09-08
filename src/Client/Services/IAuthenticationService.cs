using NiceLabel.Demo.Common.Models;
using System.Threading.Tasks;

namespace NiceLabel.Demo.Client.Services
{
    public interface IAuthenticationService
    {
        Task<Token> Authenticate(LoginModel login);
    }
}