using KLWines.ShoppingCartService.Domain.Core.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace KLWines.ShoppingCartService.Domain.Core.Events
{
    public class ProductQuantityAdjusted : IEvent
    {
        public Product Product { get; private set; }
        public ProductQuantity Qty { get; private set; }
        public ProductQuantityAdjusted(Product product, ProductQuantity qty)
        {
            Product = product;
            Qty = qty;
        }
    }
}
