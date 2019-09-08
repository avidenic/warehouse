using System.ComponentModel.DataAnnotations;
using NiceLabel.Demo.Server.Infrastructure;

namespace NiceLabel.Demo.Server.Models
{
    public class Customer
    {
        [MaxLength(500), Key]
        public string Name { get; set; }

        [MaxLength(64), Password]
        public string Password { get; set; }

        public long Quantity { get; set; }

        public void IncreaseQuantity(int quantity)
        {
            if (quantity > 0)
            {
                Quantity += quantity;
            }
        }
    }
}