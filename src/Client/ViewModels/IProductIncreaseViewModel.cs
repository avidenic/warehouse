using NiceLabel.Demo.Common.Models;
using System.Threading.Tasks;

namespace NiceLabel.Demo.Client.ViewModels
{
    public interface IProductIncreaseViewModel : IErrorMessage
    {
        Token Token { get; set; }

        int AddQuantity { get; set; }

        Task<bool> IncreaseQuantity();

        bool IsValidQuantityInput(string input);
    }
}
