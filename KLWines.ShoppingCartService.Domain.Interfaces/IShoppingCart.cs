using KLWines.ShoppingCartService.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KLWines.ShoppingCartService.Domain.Interfaces
{
    public interface IShoppingCart
    {
        Task AddProductToBasket(IProduct product, int qty = 1);
        Task RemoveProductFromBasket(IProduct product);
        Task AdjustProductQty(IProduct product, int qty = 1);


        Task<int> CountUniqueProducts();
        Task<int> CountTotalProducts();
    }
}
