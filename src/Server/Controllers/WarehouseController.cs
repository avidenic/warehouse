using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using NiceLabel.Demo.Common.Models;
using NiceLabel.Demo.Server.Hubs;
using System;
using System.Threading.Tasks;

namespace NiceLabel.Demo.Server.Controllers
{
    [Route("api")]
    public class WarehouseController : Controller
    {
        private readonly WarehouseContext _warehouseContext;
        private readonly IHubContext<StatusHub> _hub;
        public WarehouseController(WarehouseContext warehouseContext, IHubContext<StatusHub> hub)
        {
            _hub = hub;
            _warehouseContext = warehouseContext;
        }

        [HttpPut, Route("product")]
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
            await _hub.Clients.All.SendAsync("update", new { customer.Name, customer.Quantity });

            return Ok(new ProductReply { Sum = customer.Quantity });
        }
    }
}
