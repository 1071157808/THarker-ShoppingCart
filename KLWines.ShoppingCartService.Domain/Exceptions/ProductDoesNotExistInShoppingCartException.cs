using System;
using System.Collections.Generic;
using System.Text;

namespace KLWines.ShoppingCartService.Domain.Exceptions
{
    public class ProductDoesNotExistInShoppingCartException : Exception
    {
        public ProductDoesNotExistInShoppingCartException(int sku) : base($"Product with sku: {sku} doesn't exist in the shopping cart") { }
    }
}
