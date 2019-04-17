using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using KLWines.ShoppingCartService.Domain.Core;
using KLWines.ShoppingCartService.Domain.Core.ValueObjects;

namespace KLWines.ShoppingCartService.Domain.Interfaces
{
    public interface IShoppingCart
    {
        Task AddProductToBasket(Product product, ProductQuantity qty);
        Task RemoveProductFromBasket(Product product);
        Task AdjustProductQty(Product product, ProductQuantity qty);


        long CountUniqueProducts();
        long CountTotalProducts();
    }
}
