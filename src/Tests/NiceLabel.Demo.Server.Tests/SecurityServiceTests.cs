using System;
using Xunit;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using NiceLabel.Demo.Server.Infrastructure;
using NiceLabel.Demo.Server.Models;
using NiceLabel.Demo.Server.Services;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;

namespace NiceLabel.Demo.Server.Tests
{
    public class SecurityServiceTests
    {
        [Fact]
        public void TokenGeneratedWithCorrectClaims()
        {
            var target = new SecurityService();
            var token = target.GenerateToken("name");
            var handler = new JwtSecurityTokenHandler();
            var decoded = handler.ReadToken(token) as JwtSecurityToken;

            Assert.Equal("localhost", decoded.Issuer);
            Assert.Equal("wpfClient", decoded.Claims.FirstOrDefault(x => x.Type == "aud")?.Value);
        }
    }
}
