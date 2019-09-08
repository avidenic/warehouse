using NiceLabel.Demo.Client.Services;
using NiceLabel.Demo.Common.Exceptions;
using NiceLabel.Demo.Common.Models;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace NiceLabel.Demo.Client.ViewModels
{
    public class LoginPageViewModel : BaseViewModel, ILoginPageViewModel
    {
        private readonly IAuthenticationService _authenticationService;
        public LoginPageViewModel(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        public async Task<bool> Login(string password)
        {
            try
            {
                if (string.IsNullOrEmpty(Username) || string.IsNullOrEmpty(password))
                {
                    Message = "Username and password are required!";
                    return false;
                }
                Token = await _authenticationService.Authenticate(new LoginModel { Username = Username, Password = password }).ConfigureAwait(false);
                return true;
            }
            catch (BusinessLogicViolationException ex)
            {
                Message = ex.Errors.FirstOrDefault().Value?.FirstOrDefault();
                return false;
            }
        }

        public Token Token { get; private set; }

        private string _username;
        public string Username
        {
            get
            {
                return _username;
            }
            set
            {
                _username = value;
                OnPropertyChanged(nameof(Username));
            }
        }
    }
}
