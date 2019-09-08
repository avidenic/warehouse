using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace NiceLabel.Demo.Server.Services
{
    public class SecurityService : ISecurityService
    {
        private static readonly JwtSecurityTokenHandler TokenHandler = new JwtSecurityTokenHandler();
        private static readonly SymmetricSecurityKey _securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Guid.NewGuid().ToString()));
        
        public SymmetricSecurityKey SecurityKey 
        {
            get { return _securityKey;  }
        }

        public string GenerateToken(string username)
        {
            var claims = new[] { new Claim(ClaimTypes.Name, username) };
            var credentials = new SigningCredentials(this.SecurityKey, SecurityAlgorithms.HmacSha512);
            var token = new JwtSecurityToken("localhost", "wpfClient", claims, expires: DateTime.Now.AddDays(1), signingCredentials: credentials);
            return TokenHandler.WriteToken(token);
        }
    }
}