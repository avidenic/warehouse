using System.ComponentModel.DataAnnotations;
using NiceLabel.Demo.Server.Infrastructure;

namespace NiceLabel.Demo.Server.Models
{
    public class Login
    {
        [Required(AllowEmptyStrings = false)]
        public string Username { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string Password { get; set; }

        public string PasswordHash { get { return string.IsNullOrEmpty(Password) ? string.Empty : Password.Hash(); } }
    }
}