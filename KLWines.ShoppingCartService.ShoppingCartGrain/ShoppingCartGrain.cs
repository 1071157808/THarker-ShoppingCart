using Eveneum;
using KLWines.ShoppingCartService.Domain.Aggregates;
using KLWines.ShoppingCartService.Domain.Core.ValueObjects;
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
        public ShoppingCartGrain()
        {
            var documentClient = new DocumentClient(new System.Uri("https://localhost:8081"), "C2y6yDjf5/R+ob0N8A7Cgv30VRDJIWEHLM+4QDU5DE2nQ9nDuVTqobD4b8mGGyPMbIZnqyMsEcaGQy67XIw/Jw==");
            this.EventStore = new EventStore(documentClient, "EventStore", "ShoppingCart");
            this.EventStore.DeleteMode = DeleteMode.HardDelete;
        }

        private Domain.Aggregates.ShoppingCart _shoppingCart { get; set; }
        public async Task AddProductToBasket(Product product, ProductQuantity qty) => await Execute(async () => await _shoppingCart.AddProductToBasket(product, qty));
        public async Task RemoveProductFromBasket(Product product) => await Execute(async () => await _shoppingCart.RemoveProductFromBasket(product));
        public async Task AdjustProductQuantity(Product product, ProductQuantity qty) => await Execute(async () => await _shoppingCart.AdjustProductQty(product, qty));


        public async Task MergeShoppingCart(ShoppingCartId sourceShoppingCartId, Dictionary<Product, ProductQuantity> listOfItems)
        {
            _shoppingCart.MergeShoppingCart(sourceShoppingCartId, )
        }

        public async Task MergeShoppingCartInto(ShoppingCartId targetShoppingCartId)
        {
            await GrainFactory.GetGrain<IShoppingCartGrain>(targetShoppingCartId.Value).MergeShoppingCart();
            //raise event that shopping cart has been merged into.
        }

        public async Task<long> CountTotalProducts() => _shoppingCart.CountTotalProducts();
        public async Task<long> CountUniqueProducts() => _shoppingCart.CountUniqueProducts();

    }
}
