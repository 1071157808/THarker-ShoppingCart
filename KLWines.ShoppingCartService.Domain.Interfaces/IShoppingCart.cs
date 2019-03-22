using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using KLWines.ShoppingCartService.Domain.Core;

namespace KLWines.ShoppingCartService.Domain.Interfaces
{
    public interface IShoppingCart
    {
        Task AddProductToBasket(Product product, ProductQuantity qty);
        Task RemoveProductFromBasket(Product product);
        Task AdjustProductQty(Product product, ProductQuantity qty);


        Task<int> CountUniqueProducts();
        Task<int> CountTotalProducts();
    }
}
