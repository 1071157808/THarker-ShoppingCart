using KLWines.ShoppingCartService.Domain.Core.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace KLWines.ShoppingCartService.Domain.Core.Events
{
    public struct ShoppingCartCreated : IEvent
    {
        public ShoppingCartId Id { get; private set; }
        public ShopperId? ShopperId { get; private set; }

        public ShoppingCartCreated(ShoppingCartId id, ShopperId? shopperId)
        {
            Id = id;
            ShopperId = shopperId;
        }
    }
}
