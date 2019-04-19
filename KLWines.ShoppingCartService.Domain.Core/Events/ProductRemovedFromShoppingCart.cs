using KLWines.ShoppingCartService.Domain.Core.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace KLWines.ShoppingCartService.Domain.Core.Events
{
    public struct ProductRemovedFromShoppingCart : IEvent
    {
        public Product Product { get; private set; }
        public ProductRemovedFromShoppingCart(Product product)
        {
            Product = product;
        }
    }
}
