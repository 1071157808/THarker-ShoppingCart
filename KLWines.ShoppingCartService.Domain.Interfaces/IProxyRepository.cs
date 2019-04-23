using System;

namespace KLWines.ShoppingCartService.Domain.Interfaces
{
    public interface IProxyRepository
    {
        IShoppingCartProxy GetShoppingCartProxy(Guid shoppingCartId);
    }
}
