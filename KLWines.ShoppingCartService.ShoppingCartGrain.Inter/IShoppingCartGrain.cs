using KLWines.ShoppingCartService.Domain.Core.ValueObjects;
using Orleans;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KLWines.ShoppingCartService.ShoppingCartGrain.Inter
{
    public interface IShoppingCartGrain : IGrainWithGuidKey
    {
        Task AddProductToBasket(Product product, ProductQuantity qty);
        Task RemoveProductFromBasket(Product product);
        Task AdjustProductQuantity(Product product, ProductQuantity qty);

        Task<long> CountUniqueProducts();
        Task<long> CountTotalProducts();
    }
}
