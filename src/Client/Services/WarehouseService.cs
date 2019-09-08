using NiceLabel.Demo.Client.Configuration;
using NiceLabel.Demo.Common.Models;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace NiceLabel.Demo.Client.Services
{
    public class WarehouseService : HttpService, IWarehouseService
    {
        private readonly Server _server;
        public WarehouseService(HttpClient httpClient, Server server) : base(httpClient)
        {
            _server = server;
        }

        public Task<ProductReply> IncreaseQuantity(Token token, int quantity)
        {
            var content = GetStringContent(new ProductRequest { QuantityToAdd = quantity });
            HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token.Value);
            return ExecuteAsync<ProductReply>(() => HttpClient.PutAsync($"{_server.Url}/api/product", content));
        }
    }
}
