using System;
using System.ComponentModel.DataAnnotations;

namespace NiceLabel.Demo.Common.Models
{
    public class ProductRequest
    {
        [Range(1, int.MaxValue)]
        public int QuantityToAdd { get; set; }
    }
}
