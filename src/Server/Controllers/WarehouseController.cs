using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NiceLabel.Demo.Common.Models;
using System;
using System.Threading.Tasks;

namespace NiceLabel.Demo.Server.Controllers
{
    [Route("api")]
    public class WarehouseController : Controller
    {
        private readonly WarehouseContext _warehouseContext;
        public WarehouseController(WarehouseContext warehouseContext)
        {
            _warehouseContext = warehouseContext;
        }

        [HttpPut, Route("product"), Authorize]
        public async Task<IActionResult> AddQuantity([FromBody]ProductRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var username = HttpContext.User.Identity.Name;
            var customer = await _warehouseContext.Customers.FirstOrDefaultAsync(x => x.Name == username);
            
            if (customer == null)
            {
                throw new InvalidOperationException("User does not exist, something went terribly wrong!");
            }

            customer.IncreaseQuantity(request.QuantityToAdd);
            await _warehouseContext.SaveChangesAsync();

            return Ok(new ProductReply { Sum = customer.Quantity });
        }
    }
}
