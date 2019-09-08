using NiceLabel.Demo.Client.Configuration;
using NiceLabel.Demo.Common.Models;
using System.Net.Http;
using System.Threading.Tasks;

namespace NiceLabel.Demo.Client.Services
{
    public class AuthenticationService : HttpService, IAuthenticationService
    {
        private readonly Server _server;
        public AuthenticationService(HttpClient httpClient, Server server) : base(httpClient)
        {
            _server = server;
        }

        public Task<Token> Authenticate(LoginModel login)
        {
            var content = GetStringContent(login);
            return ExecuteAsync<Token>(() => HttpClient.PostAsync($"{_server.Url}/api/login", content));
        }
    }
}
