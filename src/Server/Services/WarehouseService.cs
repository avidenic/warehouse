using System.Threading.Tasks;
using Grpc.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace NiceLabel.Demo.Server.Services
{
    public class WarehouseService : Warehouse.WarehouseBase, IWarehouseService
    {
        private readonly WarehouseContext _dbContext;
        public WarehouseService(WarehouseContext context)
        {
            _dbContext = context;
        }

        [Authorize]
        public override async Task<SendProductReply> SendProduct(SendProductRequest request, ServerCallContext context)
        {
            var user = context.GetHttpContext().User;
            var customer = await _dbContext.Customers.FirstOrDefaultAsync(x => x.Name == user.Identity.Name);
            
            // something went terribly wrong
            if (customer == null)
            {
                return new SendProductReply { Message = "Invalid customer" };
            }

            customer.Quantity += request.Quantity;
            await _dbContext.SaveChangesAsync();

            return new SendProductReply{ Sum = customer.Quantity, Message = "Success" };
        }
    }
}