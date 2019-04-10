using System.Threading.Tasks;
using KLWines.ShoppingCartService.Orleans.ShoppingCartGrain.Interfaces;
using Orleans;
using KLWines.ShoppingCartService.Domain.Core.ValueObjects;
using KLWines.ShoppingCartService.Domain.Aggregates;
using Microsoft.Azure.Documents.Client;
using Eveneum;

namespace KLWines.ShoppingCartService.Orleans.ShoppingCartGrain
{
    /// <summary>
    /// Grain implementation class Grain1.
    /// </summary>
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

        
    }
}
