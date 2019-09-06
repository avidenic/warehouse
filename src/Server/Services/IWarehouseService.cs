using System.Threading.Tasks;
using Grpc.Core;

namespace NiceLabel.Demo.Server.Services
{
    public interface IWarehouseService
    {
        Task<SendProductReply> SendProduct(SendProductRequest request, ServerCallContext context);
    }
}