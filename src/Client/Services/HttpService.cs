using NiceLabel.Demo.Common.Exceptions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Security;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace NiceLabel.Demo.Client.Services
{
    public class HttpService
    {
        protected readonly HttpClient HttpClient;
        private static readonly JsonSerializerOptions _options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        public HttpService(HttpClient httpClient)
        {
            HttpClient = httpClient;
        }

        protected virtual HttpContent GetStringContent<T>(T model) where T : class
        {
            return new StringContent(JsonSerializer.Serialize(model), Encoding.UTF8, "application/json");
        }

        protected async Task<T> ExecuteAsync<T>(Func<Task<HttpResponseMessage>> call)
        {
            using var response = await call().ConfigureAwait(false);
            using var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);

            if (response.IsSuccessStatusCode)
            {
                return await JsonSerializer.DeserializeAsync<T>(responseStream, _options).ConfigureAwait(false);
            }

            if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                var value = await JsonSerializer.DeserializeAsync<Dictionary<string, string[]>>(responseStream, _options);
                throw new BusinessLogicViolationException(value);
            }

            var stringContent = await new StreamReader(responseStream).ReadToEndAsync().ConfigureAwait(false);

            if (response.StatusCode == HttpStatusCode.Unauthorized || response.StatusCode == HttpStatusCode.Forbidden)
            {
                throw new SecurityException(stringContent);
            }

            throw new InvalidOperationException($"Something went terribly wrong! Details: {stringContent}");
        }
    }
}
