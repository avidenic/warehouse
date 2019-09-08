using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using NiceLabel.Demo.Common.Models;

namespace NiceLabel.Demo.Client.Services
{
    public class WarehouseService : HttpService, IWarehouseService
    {
        public WarehouseService(HttpClient httpClient) : base(httpClient)
        {
        }

        public Task<ProductReply> IncreaseQuantity(Token token, int quantity)
        {
            var content = GetStringContent(new ProductRequest { QuantityToAdd = quantity });
            HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token.Value);
            return ExecuteAsync<ProductReply>(() => HttpClient.PutAsync("http://localhost:5000/api/product", content));
        }
    }
}
