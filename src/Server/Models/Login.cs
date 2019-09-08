using NiceLabel.Demo.Common.Models;
using NiceLabel.Demo.Server.Infrastructure;

namespace NiceLabel.Demo.Server.Models
{
    public class Login : LoginModel
    {
        public string PasswordHash { get { return string.IsNullOrEmpty(Password) ? string.Empty : Password.Hash(); } }
    }
}