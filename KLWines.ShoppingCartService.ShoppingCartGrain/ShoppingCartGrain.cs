using Eveneum;
using KLWines.ShoppingCartService.Domain.Aggregates;
using KLWines.ShoppingCartService.Domain.Core.Events;
using KLWines.ShoppingCartService.Domain.Core.ValueObjects;
using KLWines.ShoppingCartService.Domain.Interfaces;
using KLWines.ShoppingCartService.ShoppingCartGrain.Inter;
using Microsoft.Azure.Documents.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KLWines.ShoppingCartService.ShoppingCartGrain
{
    public class ShoppingCartGrain : BaseEventStoreGrain<ShoppingCart>, IShoppingCartGrain
    {
        private ShoppingCartId Id { get; set; }
        private ShopperId ShopperId { get; set; }

        private readonly List<BasketItem> BasketItems = new List<BasketItem>();
        private Domain.Aggregates.ShoppingCart ShoppingCart { get; set; }

        public ShoppingCartGrain()
        {
            var documentClient = new DocumentClient(new System.Uri("https://localhost:8081"), "C2y6yDjf5/R+ob0N8A7Cgv30VRDJIWEHLM+4QDU5DE2nQ9nDuVTqobD4b8mGGyPMbIZnqyMsEcaGQy67XIw/Jw==");
            this.EventStore = new EventStore(documentClient, "EventStore", "ShoppingCart");
            this.EventStore.DeleteMode = DeleteMode.HardDelete;
        }

        public async Task AddProductToBasket(Product product, ProductQuantity qty) => await Execute(async () =>
        {
            await Task.CompletedTask;
            RaiseEvent(new ProductAddedToShoppingCart(product, qty));
        });
        public async Task RemoveProductFromBasket(Product product) => await Execute(async () =>
        {
            await Task.CompletedTask;
            RaiseEvent(new ProductRemovedFromShoppingCart(product));
        });
        public async Task AdjustProductQuantity(Product product, ProductQuantity qty) => await Execute(async () =>
        {
            await Task.CompletedTask;
            RaiseEvent(new ProductQuantityAdjusted(product, qty));
        });


        public async Task MergeShoppingCart(ShoppingCartId sourceShoppingCartId, Dictionary<Product, ProductQuantity> listOfItems)
        {
            //_shoppingCart.MergeShoppingCart(sourceShoppingCartId, )
        }

        public async Task MergeShoppingCartInto(ShoppingCartId targetShoppingCartId)
        {
            //await GrainFactory.GetGrain<IShoppingCartGrain>(targetShoppingCartId.Value).MergeShoppingCart();
            //raise event that shopping cart has been merged into.
        }

        public async Task<long> CountTotalProducts() => BasketItems.Sum(i => i.Qty.Value);
        public async Task<long> CountUniqueProducts() => BasketItems.Select(i => i.Product).Distinct().LongCount();

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
