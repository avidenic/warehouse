using NiceLabel.Demo.Common.Models;
using System.Threading.Tasks;

namespace NiceLabel.Demo.Client.ViewModels
{
    public interface ILoginPageViewModel : IErrorMessage
    {
        string Username { get; set; }
        Token Token { get; }
        Task<bool> Login(string password);
    }
}
