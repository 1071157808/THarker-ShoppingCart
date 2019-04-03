using System;
using System.Collections.Generic;
using System.Text;

namespace KLWines.ShoppingCartService.Domain.Core.ValueObjects
{
    public class Product
    {
        public string Name { get; private set; }
        public uint Sku { get; private set; }

        public Product(uint sku, string name)
        {
            Name = name;
            Sku = sku;
        }
    }
}
