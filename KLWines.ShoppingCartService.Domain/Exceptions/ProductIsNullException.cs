using System;
using System.Collections.Generic;
using System.Text;

namespace KLWines.ShoppingCartService.Domain.Exceptions
{
    public class ProductIsNullException : Exception
    {
        public ProductIsNullException() : base("Product provided was null, please provide a valid object") { }
    }
}
