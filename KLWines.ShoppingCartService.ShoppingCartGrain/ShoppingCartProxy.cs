using KLWines.ShoppingCartService.Domain.Core.ValueObjects;
using KLWines.ShoppingCartService.Domain.Interfaces;
using KLWines.ShoppingCartService.ShoppingCartGrain.Inter;
using Orleans;
using System;
using System.Threading.Tasks;

namespace KLWines.ShoppingCartService.ShoppingCartGrain
{
    class ShoppingCartProxy : IShoppingCartProxy
    {
        private readonly IGrainFactory GrainFactory;
        private readonly Guid ShoppingCartId;

        public ShoppingCartProxy(IGrainFactory grainFactory, Guid shoppingCartId)
        {
            this.GrainFactory = grainFactory;
            this.ShoppingCartId = shoppingCartId;
        }

        public Task AddProductToBasket(Product product, ProductQuantity qty)
        {
            return this.GrainFactory.GetGrain<IShoppingCartGrain>(this.ShoppingCartId).AddProductToBasket(product, qty);
        }
    }
}
