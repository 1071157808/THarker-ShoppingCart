using System;
using System.Collections.Generic;
using System.Text;

namespace KLWines.ShoppingCartService.Domain.Exceptions
{
    public class ProductQtyMustBeGreaterThanOneException : Exception
    {
        public ProductQtyMustBeGreaterThanOneException(int qty) : base($"Qty must be greater than 1. Value provided: {qty}") { }
    }
}
