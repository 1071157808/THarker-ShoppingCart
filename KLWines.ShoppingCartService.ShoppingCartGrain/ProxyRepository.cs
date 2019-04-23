using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KLWines.ShoppingCartService.ShoppingCartGrain
{
    class ProxyRepository : IProxyRepository
    {
        private readonly IGrainFactory GrainFactory;

        public ProxyRepository(IGrainFactory grainFactory)
        {
            this.GrainFactory = grainFactory;
        }

        public IShoppingCartProxy GetShoppingCartProxy(Guid shoppingCartId) => new ShoppingCartProxy(this.GrainFactory, shoppingCartId);
    }
}
