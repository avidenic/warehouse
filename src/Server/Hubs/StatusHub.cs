using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

namespace NiceLabel.Demo.Server.Hubs
{
    public class StatusHub : Hub
    {
        private readonly WarehouseContext _context;
        public StatusHub(WarehouseContext context)
        {
            _context = context;
        }

        public override async Task OnConnectedAsync()
        {
            var data = await _context.Customers.ToArrayAsync();

            await Clients.Caller.SendAsync("customers", data.Select(x=> new { x.Name, x.Quantity}) );
        }
    }
}
