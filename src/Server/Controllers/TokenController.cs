using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NiceLabel.Demo.Common.Models;
using NiceLabel.Demo.Server.Models;
using NiceLabel.Demo.Server.Services;
using System.Threading.Tasks;

namespace NiceLabel.Demo.Server.Controllers
{
    [Route("api")]
    public class TokenController : Controller
    {
        private readonly ISecurityService _securityService;
        private readonly WarehouseContext _context;
        private const string ErrorMessage = "Username or password is incorrect";

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
                return BadRequest(ModelState);
            }
            var user = await _context.Customers.FirstOrDefaultAsync(x => x.Name.ToUpper() == login.Username.ToUpper() && x.Password == login.PasswordHash);
            if (user == null)
            {
                ModelState.AddModelError(nameof(login.Password), ErrorMessage);
                ModelState.AddModelError(nameof(login.Username), ErrorMessage);
                return BadRequest(ModelState);
            }

            var token = _securityService.GenerateToken(user.Name);
            
            return Ok(new Token(token, user.Name));
        }
    }
}