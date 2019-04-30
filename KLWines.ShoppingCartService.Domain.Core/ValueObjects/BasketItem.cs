using System;
using System.Collections.Generic;
using System.Text;

namespace KLWines.ShoppingCartService.Domain.Core.ValueObjects
{
    public class BasketItem
    {
        public Product Product { get; }
        public ProductQuantity Qty { get; }

        public BasketItem(Product product, ProductQuantity qty)
        {
            Product = product;
            Qty = qty;
        }
    }
}
