using System.Threading.Tasks;
using KLWines.ShoppingCartService.Orleans.ShoppingCart.Interface;
using Orleans;
using KLWines.ShoppingCartService.Domain.Core.ValueObjects;
using KLWines.ShoppingCartService.Domain.Aggregates;
using Microsoft.Azure.Documents.Client;

namespace KLWines.ShoppingCartService.Orleans.ShoppingCartGrain
{
    /// <summary>
    /// Grain implementation class Grain1.
    /// </summary>
    public class ShoppingCartGrain : Grain, IShoppingCartGrain
    {
        private readonly IEventStore EventStore;
        private string EventStoreKey { get; set; }

        public ShoppingCartGrain()
        {
            var documentClient = new DocumentClient(new System.Uri("https://localhost:8081"), "C2y6yDjf5/R+ob0N8A7Cgv30VRDJIWEHLM+4QDU5DE2nQ9nDuVTqobD4b8mGGyPMbIZnqyMsEcaGQy67XIw/Jw==");

            this.EventStore = new EventStore(documentClient, "EventStore", "ShoppingCart");
            this.EventStore.DeleteMode = DeleteMode.HardDelete;
        }


        public override async Task OnActivateAsync()
        {
            await base.OnActivateAsync();
            this.EventStoreKey = $"{this.GetType().Name}~{this.GetPrimaryKeyLong()}";

            var stream = await this.EventStore.ReadStream(this.EventStoreKey);

            if (stream.HasValue)
            {
                this.Version = stream.Value.Version;

                this._shoppingCart = new ShoppingChart(stream.Value.Events, stream.Value.Snapshot);
            }
        }



        private ShoppingCart _shoppingCart { get; set; }
        public async Task AddProductToBasket(Product product, ProductQuantity qty) => await _shoppingCart.AddProductToBasket(product, qty);
        public async Task RemoveProductFromBasket(Product product) => await _shoppingCart.RemoveProductFromBasket(product);
        public async Task AdjustProductQuantity(Product product, ProductQuantity qty) => await _shoppingCart.AdjustProductQty(product, qty);
    }
}
