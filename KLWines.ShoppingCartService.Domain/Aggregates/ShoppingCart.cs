using KLWines.ShoppingCartService.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KLWines.ShoppingCartService.Domain.Aggregates
{
    public class ShoppingCart : IShoppingCart
    {
        public Task AddProductToBasket(IProduct product, int qty = 1)
        {
            throw new NotImplementedException();
        }

        public Task AdjustProductQty(IProduct product, int qty = 1)
        {
            throw new NotImplementedException();
        }

        public Task<int> CountTotalProducts()
        {
            throw new NotImplementedException();
        }

        public Task<int> CountUniqueProducts()
        {
            throw new NotImplementedException();
        }

        public Task RemoveProductFromBasket(IProduct product)
        {
            throw new NotImplementedException();
        }
    }
}
