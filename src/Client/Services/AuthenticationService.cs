using NiceLabel.Demo.Common.Models;
using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Security;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace NiceLabel.Demo.Client.Services
{
    public class AuthenticationService : HttpService, IAuthenticationService
    {        
        public AuthenticationService(HttpClient httpClient) : base(httpClient)
        {
        }

        public Task<Token> Authenticate(LoginModel login)
        {
            var content = GetStringContent(login);
            return ExecuteAsync<Token>(() => HttpClient.PostAsync("http://localhost:5000/api/login", content));            
        }
    }
}
