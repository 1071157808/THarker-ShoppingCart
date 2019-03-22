using Eveneum;
using KLWines.ShoppingCartService.Domain.Events;
using KLWines.ShoppingCartService.Domain.Interfaces;
using KLWines.ShoppingCartService.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KLWines.ShoppingCartService.Domain.Aggregates
{
    public class ShoppingCart : BaseEventStoreAggregate, IShoppingCart
    {
        private HashSet<BasketItem> BasketItems { get; set; }

        public ShoppingCart()
        {

        }

        #region Public Commands
        public async Task AddProductToBasket(IProduct product, int qty = 1)
        {
            throw new NotImplementedException();
        }
        public async Task AdjustProductQty(IProduct product, int qty = 1)
        {
            throw new NotImplementedException();
        }
        public async Task RemoveProductFromBasket(IProduct product)
        {
            throw new NotImplementedException();
        }
        #endregion


        #region Public Getters
        public async Task<int> CountTotalProducts() => BasketItems.Select(i => i.Product).Distinct().Count();
        public async Task<int> CountUniqueProducts() => BasketItems.Sum(i => i.Qty);
        #endregion


        #region EventHandlers
        private void Apply(BasketItemAdded @event) => BasketItems.Add(new BasketItem(@event.Product, @event.Qty));
        private void Apply(BasketItemRemoved @event) => BasketItems.RemoveWhere(i => i.Product == @event.Product);
        private void Apply(BasketItemQtyAdjusted @event)
        {
            BasketItems.RemoveWhere(i => i.Product == @event.Product);
            BasketItems.Add(new BasketItem(@event.Product, @event.Qty));
        }
        #endregion


        protected override async Task ApplyEvent(IEvent @event)
        {
            dynamic me = this;
            me.Apply((dynamic)@event);
        }

        protected override ISnapshot CreateSnapshot() => new Snapshot(BasketItems);


    }

    class Snapshot : ISnapshot
    {
        public HashSet<BasketItem> BasketItems { get; private set; }
        public Snapshot(HashSet<BasketItem> basketItems)
        {
            BasketItems = basketItems;
        }
    }
}
