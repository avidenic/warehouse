using NiceLabel.Demo.Common.Models;
using System.Threading.Tasks;

namespace NiceLabel.Demo.Client.Services
{
    public interface IWarehouseService
    {
        Task<ProductReply> IncreaseQuantity(Token token, int quantity);
    }
}
