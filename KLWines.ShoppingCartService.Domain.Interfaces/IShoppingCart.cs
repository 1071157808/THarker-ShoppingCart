using KLWines.ShoppingCartService.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KLWines.ShoppingCartService.Domain.Interfaces
{
    public interface IShoppingCart
    {
        Task AddProductToBasket(Product product, int qty = 1);
        Task RemoveProductFromBasket(Product product);
        Task AdjustProductQty(Product product, int qty = 1);
    }
}
