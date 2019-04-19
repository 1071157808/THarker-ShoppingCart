using KLWines.ShoppingCartService.Domain.Core.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace KLWines.ShoppingCartService.Domain.Core.Events
{
    public struct ProductQuantityAdjusted : IEvent
    {
        public Product Product { get; }
        public ProductQuantity Qty { get; }
        public ProductQuantityAdjusted(Product product, ProductQuantity qty)
        {
            Product = product;
            Qty = qty;
        }
    }
}
