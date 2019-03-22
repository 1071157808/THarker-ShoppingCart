using Eveneum;
using KLWines.ShoppingCartService.Domain.Events;
using KLWines.ShoppingCartService.Domain.Exceptions;
using KLWines.ShoppingCartService.Domain.Interfaces;
using KLWines.ShoppingCartService.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KLWines.ShoppingCartService.Domain.Core;

namespace KLWines.ShoppingCartService.Domain.Aggregates
{
    public class ShoppingCart : BaseEventStoreAggregate, IShoppingCart
    {
        private List<BasketItem> BasketItems { get; set; }

        public ShoppingCart()
        {
            BasketItems = new List<BasketItem>();
        }

        #region Public Commands
        public async Task AddProductToBasket(Product product, ProductQuantity qty)
        {
            await RaiseEvent(new BasketItemAdded(product, qty));
        }
        public async Task AdjustProductQty(Product product, ProductQuantity qty)
        {
            await RaiseEvent(new BasketItemQtyAdjusted(product, qty));
        }
        public async Task RemoveProductFromBasket(Product product)
        {
            await RaiseEvent(new BasketItemRemoved(product));
        }
        #endregion


        #region Public Getters
        public async Task<int> CountUniqueProducts() => BasketItems.Select(i => i.Product).Distinct().Count();
        public async Task<uint> CountTotalProducts() => BasketItems.Sum(i => i.Qty);
        #endregion


        #region EventHandlers
        private void Apply(BasketItemAdded @event) => BasketItems.Add(new BasketItem(@event.Product, @event.Qty));
        private void Apply(BasketItemRemoved @event) => BasketItems.RemoveWhere(i => i.Product == @event.Product);
        private void Apply(BasketItemQtyAdjusted @event)
        {
            BasketItems.RemoveAll(i => i.Product == @event.Product);
            BasketItems.Add(new BasketItem(@event.Product, @event.Qty));
        }
        #endregion

        #region Validators
        protected async Task ValidateProduct(IProduct product)
        {
            if(product == null)
            {
                throw new ProductIsNullException();
            }
        }
        protected async Task ValidateQty(int qty)
        {
            if(qty < 1)
            {
                throw new ProductQtyMustBeGreaterThanOneException(qty);
            }
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
        public List<BasketItem> BasketItems { get; private set; }
        public Snapshot(List<BasketItem> basketItems)
        {
            BasketItems = basketItems;
        }
    }
}
