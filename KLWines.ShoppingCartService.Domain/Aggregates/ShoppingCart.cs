using KLWines.ShoppingCartService.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KLWines.ShoppingCartService.Domain.Core;
using KLWines.ShoppingCartService.Domain.Core.ValueObjects;
using KLWines.ShoppingCartService.Domain.Core.Events;

namespace KLWines.ShoppingCartService.Domain.Aggregates
{
    public class ShoppingCart : BaseEventStoreAggregate, IShoppingCart
    {
        private ShoppingCartId Id { get; set; }
        private ShopperId? ShopperId { get; set; }
        private readonly List<BasketItem> BasketItems = new List<BasketItem>();



        public ShoppingCart() { }
        public ShoppingCart(ShoppingCartId id, AnonomousShopperId anonomousShopperId)
        {
            //raise anonomous hsopping cart created.
        }
        public ShoppingCart(ShoppingCartId id, ShopperId? shopperId)
        {
            RaiseEvent(new ShoppingCartCreated(id, shopperId));
        }

        /*
         *  Used to hydrate model from eventstore
         */ 
        public ShoppingCart(List<IEvent> events = null, Snapshot snapshot = null) : base(events, snapshot)
        {
            
        }

        #region Public Commands
        public async Task AddProductToBasket(Product product, ProductQuantity qty)
        {
            await Task.CompletedTask;
            /*
             * Do any db checks & validation checks
             */ 


            //if successful rais event that item was added
            RaiseEvent(new ProductAddedToShoppingCart(product, qty));
        }
        public async Task AdjustProductQty(Product product, ProductQuantity qty)
        {
            await Task.CompletedTask;
            RaiseEvent(new ProductQuantityAdjusted(product, qty));
        }
        public async Task RemoveProductFromBasket(Product product)
        {
            await Task.CompletedTask;
            RaiseEvent(new ProductRemovedFromShoppingCart(product));
        }
        public async Task MergeShoppingCart(ShoppingCartId sourceShoppingCart, Dictionary<Product, ProductQuantity> listOfItems)
        {
            
            await Task.CompletedTask;
        }



        #endregion


        #region Public Getters
        public long CountUniqueProducts() => BasketItems.Select(i => i.Product).Distinct().Count();
        public long CountTotalProducts() => BasketItems.Sum(i => i.Qty.Value);
        #endregion


        #region EventHandlers
        private void Apply(ProductAddedToShoppingCart @event) => BasketItems.Add(new BasketItem(@event.Product, @event.Qty));
        private void Apply(ProductRemovedFromShoppingCart @event) => BasketItems.RemoveAll(i => i.Product == @event.Product);
        private void Apply(ProductQuantityAdjusted @event)
        {
            BasketItems.RemoveAll(i => i.Product == @event.Product);
            BasketItems.Add(new BasketItem(@event.Product, @event.Qty));
        }
        #endregion


        

        protected override void ApplySnapshot(ISnapshot snapshot)
        {
            BasketItems.AddRange(((Snapshot)snapshot).BasketItems);
        }
    }

    public class Snapshot : ISnapshot
    {
        public List<BasketItem> BasketItems { get; private set; }
        public Snapshot(List<BasketItem> basketItems)
        {
            BasketItems = basketItems;
        }
    }
}
