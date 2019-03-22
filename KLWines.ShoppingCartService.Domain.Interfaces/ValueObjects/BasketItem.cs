using KLWines.ShoppingCartService.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace KLWines.ShoppingCartService.Interfaces.ValueObjects
{
    public struct BasketItem
    {
        public Product Product { get; private set; }
        public uint Qty { get; private set; }

        public BasketItem(Product product, uint qty = 1)
        {
            Product = product;
            Qty = qty;
        }
    }
}
