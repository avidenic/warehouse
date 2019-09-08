using NiceLabel.Demo.Client.Services;
using NiceLabel.Demo.Common.Models;
using System.Collections.Generic;
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

        public string Hello => $"Hello {Token?.Username}!";

        private Token _token;
        public Token Token
        {
            get { return _token; }
            set
            {
                _token = value;
                OnPropertyChanged(nameof(Hello));
            }
        }

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

        private string _messageColour;
        public string MessageColour
        {
            get { return _messageColour; }
            set { _messageColour = value; OnPropertyChanged(nameof(MessageColour)); }
        }

        public async Task<bool> IncreaseQuantity()
        {
            if (string.IsNullOrEmpty(Token?.Value))
            {
                Message = "Something is wrong, please re-open the application!";
                SetMessageType(MessageType.Error);
                return false;
            }
            if (AddQuantity < 1)
            {
                Message = "Quantity must be greater than 0!";
                SetMessageType(MessageType.Error);
                return false;
            }

            var result = await _warehouseService.IncreaseQuantity(Token, AddQuantity).ConfigureAwait(false);
            Message = $"Success! Current quantity: {result.Sum}";
            SetMessageType(MessageType.Success);
            return true;
        }

        public bool IsValidQuantityInput(string input)
        {
            return int.TryParse(input, out int result);
        }

        private void SetMessageType(MessageType type)
        {
            MessageColour = _colours[type];
        }

        private Dictionary<MessageType, string> _colours = new Dictionary<MessageType, string>
        {
            { MessageType.Error, "Red" },
            { MessageType.Success, "Green" }
        };
    }

    enum MessageType
    {
        Error,
        Success
    }
}
