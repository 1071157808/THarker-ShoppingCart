using System.Threading.Tasks;
using Orleans;
using KLWines.ShoppingCartService.Domain.Core.ValueObjects;

namespace KLWines.ShoppingCartService.Orleans.ShoppingCart.Interface
{
    /// <summary>
    /// Grain interface IGrain1
    /// </summary>
    public interface IShoppingCartGrain : IGrainWithGuidKey
    {
        Task AddProductToBasket(Product product, ProductQuantity qty);
        Task RemoveProductFromBasket(Product product);
        Task AdjustProductQuantity(Product product, ProductQuantity qty);
    }
}
