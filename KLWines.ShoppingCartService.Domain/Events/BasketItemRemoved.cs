using KLWines.ShoppingCartService.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace KLWines.ShoppingCartService.Domain.Events
{
    public class BasketItemRemoved : IEvent
    {
        public IProduct Product { get; private set; }

        public BasketItemRemoved(IProduct product)
        {
            Product = product;
        }
    }
}
