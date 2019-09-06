using System;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace Server.Services
{
    public class SecurityService : ISecurityService
    {
        public SymmetricSecurityKey SecurityKey 
        {
            get { return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Guid.NewGuid().ToString())); }
        }
    }
}