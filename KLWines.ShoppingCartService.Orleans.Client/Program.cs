using KLWines.ShoppingCartService.Domain.Core.ValueObjects;
using KLWines.ShoppingCartService.ShoppingCartGrain.Inter;
using Orleans;
using Orleans.Configuration;
using System;
using System.Threading.Tasks;

namespace KLWines.ShoppingCartService.Orleans.Client
{
    class Program
    {
        public static int Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            return RunMainAsync().Result;
        }

        public static async Task<int> RunMainAsync()
        {
            try
            {
                var clientBuilder = new ClientBuilder()
                .UseLocalhostClustering()
                .Configure<ClusterOptions>(options =>
                {
                    options.ClusterId = "dev";
                    options.ServiceId = "Shopping Cart Service";
                });
                //.ConfigureLogging(logging => logging.Services.)\

                using (var client = clientBuilder.Build())
                {
                    await client.Connect();
                    var shoppingCart = client.GetGrain<IShoppingCartGrain>(Guid.NewGuid());

                    await shoppingCart.AddProductToBasket(new Product(19, "test item"), new ProductQuantity(2));

                    Console.WriteLine($"Total items in cart: {await shoppingCart.CountTotalProducts()}");
                    Console.WriteLine($"Total unique items in cart: {await shoppingCart.CountUniqueProducts()}");
                    Console.ReadLine();
                }
                return 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return 1;
            }
        }
    }
}
