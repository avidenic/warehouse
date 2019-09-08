using NiceLabel.Demo.Client.Services;
using NiceLabel.Demo.Common.Models;
using System.Threading.Tasks;

namespace NiceLabel.Demo.Client.ViewModels
{
    public class ProductIncreaseViewModel : BaseViewModel, IProductIncreaseViewModel
    {
        private readonly IWarehouseService _warehouseService;
        public ProductIncreaseViewModel(IWarehouseService warehouseService)
        {
            _warehouseService = warehouseService;
        }

        public Token Token { get; set; }

        private int _addQuantity;
        public int AddQuantity
        {
            get
            {
                return _addQuantity;
            }
            set
            {
                _addQuantity = value;
                OnPropertyChanged(nameof(AddQuantity));
            }
        }

        private long _sum;
        public long Sum
        {
            get { return _sum; }
            set { }
        }

        public async Task<bool> IncreaseQuantity()
        {
            if (string.IsNullOrEmpty(Token?.Value))
            {
                Message = "Something is wrong, please re-open the application!";
                return false;
            }
            if (AddQuantity < 1)
            {
                Message = "Quantity must be greater than 0!";
                return false;
            }

            await _warehouseService.IncreaseQuantity(Token, AddQuantity).ConfigureAwait(false);
            return true;
        }

        public bool IsValidQuantityInput(string input)
        {
            return int.TryParse(input, out int result) && result < 1000; // arbitrary max
        }
    }
}
