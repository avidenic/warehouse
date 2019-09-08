using Microsoft.IdentityModel.Tokens;

namespace NiceLabel.Demo.Server.Services
{
    public interface ISecurityService
    {
        SymmetricSecurityKey SecurityKey { get; }

        string GenerateToken(string username);
    }
}