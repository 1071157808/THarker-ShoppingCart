using System.Threading.Tasks;
using KLWines.ShoppingCartService.Domain.Core.ValueObjects;

namespace KLWines.ShoppingCartService.Domain.Interfaces
{
    public interface IShoppingCartProxy
    {
        Task AddProductToBasket(Product product, ProductQuantity qty);
    }
}
