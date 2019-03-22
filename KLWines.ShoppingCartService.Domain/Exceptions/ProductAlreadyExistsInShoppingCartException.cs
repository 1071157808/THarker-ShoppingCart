using System;
using System.Collections.Generic;
using System.Text;

namespace KLWines.ShoppingCartService.Domain.Exceptions
{
    public class ProductAlreadyExistsInShoppingCartException : Exception
    {
        public ProductAlreadyExistsInShoppingCartException(int sku) : base($"Product with sku: {sku} already exists in the shopping cart.") { }
    }
}
