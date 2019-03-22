using KLWines.ShoppingCartService.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace KLWines.ShoppingCartService.Domain.Events
{
    public class BasketItemAdded : IEvent
    {
        public IProduct Product { get; private set; }
        public int Qty { get; private set; }

        public BasketItemAdded(IProduct product, int qty = 1)
        {
            Product = product;
            Qty = qty;
        }
    }
}
