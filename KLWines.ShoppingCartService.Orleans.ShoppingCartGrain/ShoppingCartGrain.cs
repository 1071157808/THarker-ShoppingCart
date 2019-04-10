using System.Threading.Tasks;
using KLWines.ShoppingCartService.Orleans.ShoppingCart.Interface;
using Orleans;
using KLWines.ShoppingCartService.Domain.Core.ValueObjects;
using KLWines.ShoppingCartService.Domain.Aggregates;
using Microsoft.Azure.Documents.Client;
using KLWines.ShoppingCartService.Orleans.ShoppingCartGrain.Interfaces;

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

                this._shoppingCart = new ShoppingCart(stream.Value.Events, stream.Value.Snapshot);
            }
        }



        private Domain.Aggregates.ShoppingCart _shoppingCart { get; set; }
        public async Task AddProductToBasket(Product product, ProductQuantity qty)
        {
            try
            {
                await _shoppingCart.AddProductToBasket(product, qty);
            }
            catch(Exception ex)
            {
                //if exception ocurs while executing the command, we want to rollback any events that may have been added where the action wasn't successful
                _shoppingCart.PopNewEvents();
                throw;
            }
            var newEvents = _shoppingCart.PopNewEvents();

            if(newEvents.Count > 0)
            {
                //store in event store
                _shoppingCart.ApplyEvents(newEvents);
                //create snapshot
            }
        }
        public async Task RemoveProductFromBasket(Product product) => await _shoppingCart.RemoveProductFromBasket(product);
        public async Task AdjustProductQuantity(Product product, ProductQuantity qty) => await _shoppingCart.AdjustProductQty(product, qty);

    }
}
