using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using NiceLabel.Demo.Server.Infrastructure;
using NiceLabel.Demo.Server.Models;
using Server.Services;

namespace NiceLabel.Demo.Server.Controllers
{
    [Route("api")]
    public class TokenController : Controller
    {
        private readonly ISecurityService _securityService;
        private readonly WarehouseContext _context;

        private readonly JwtSecurityTokenHandler TokenHanlder = new JwtSecurityTokenHandler();

        public TokenController(WarehouseContext context, ISecurityService securityService)
        {
            _securityService = securityService;
            _context = context;
        }

        [HttpPost, Route("login"), AllowAnonymous]
        public async Task<IActionResult> GetToken([FromBody]Login login)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Username or password were incorrect");
            }
            var user = await _context.Customers.FirstOrDefaultAsync(x => x.Name == login.Username && x.Password == login.PasswordHash);
            if (user == null)
            {
                return BadRequest("Username or password were incorrect");
            }

            var claims = new[] { new Claim(ClaimTypes.Name, login.Username) };
            var credentials = new SigningCredentials(_securityService.SecurityKey, SecurityAlgorithms.HmacSha512);
            var token = new JwtSecurityToken("localhost", "wpfClient", claims, expires: DateTime.Now.AddDays(1), signingCredentials: credentials);
            return Ok(new
            {
                Token = TokenHanlder.WriteToken(token)
            });
        }
    }
}