using KLWines.ShoppingCartService.Domain.Events;
using KLWines.ShoppingCartService.Domain.Interfaces;
using KLWines.ShoppingCartService.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KLWines.ShoppingCartService.Domain.Aggregates
{
    public class ShoppingCart : IShoppingCart
    {
        private HashSet<BasketItem> BasketItems { get; set; }

        public ShoppingCart()
        {

        }

        #region Public Commands
        public Task AddProductToBasket(IProduct product, int qty = 1)
        {
            throw new NotImplementedException();
        }
        public Task AdjustProductQty(IProduct product, int qty = 1)
        {
            throw new NotImplementedException();
        }
        public Task RemoveProductFromBasket(IProduct product)
        {
            throw new NotImplementedException();
        }
        #endregion


        #region Public Getters
        public Task<int> CountTotalProducts()
        {
            throw new NotImplementedException();
        }
        public Task<int> CountUniqueProducts()
        {
            throw new NotImplementedException();
        }
        #endregion


        #region EventHandlers
        private void Apply(BasketItemAdded @event) => BasketItems.Add(new BasketItem(@event.Product, @event.Qty));
        #endregion





    }
}
