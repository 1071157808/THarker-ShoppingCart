using System;
using System.Collections.Generic;
using System.Text;

namespace KLWines.ShoppingCartService.Domain.Core.ValueObjects
{
    public class BasketItem
    {
        public Product Product { get; private set; }
        public ProductQuantity Qty { get; private set; }

        public BasketItem(Product product, ProductQuantity qty)
        {
            Product = product;
            Qty = qty;
        }
    }
}
