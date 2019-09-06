using Microsoft.IdentityModel.Tokens;

namespace Server.Services
{
    public interface ISecurityService
    {
        SymmetricSecurityKey SecurityKey { get; }
    }
}