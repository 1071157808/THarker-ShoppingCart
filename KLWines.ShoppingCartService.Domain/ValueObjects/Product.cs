using KLWines.ShoppingCartService.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace KLWines.ShoppingCartService.Domain.ValueObjects
{
    public class Product : IProduct
    {
        public int Sku { get; private set; }
        public string Name { get; private set; }

        public Product(int sku, string name)
        {
            Sku = sku;
            Name = name;
        }


        public static bool operator ==(Product p1, Product p2) => (p1?.Sku == p2?.Sku);
        public static bool operator !=(Product p1, Product p2) => !(p1 == p2);

        public override bool Equals(object obj)
        {
            var product = obj as Product;
            return this == product;
        }

        public override int GetHashCode()
        {
            var hashCode = 771519440;
            hashCode = hashCode * -1521134295 + Sku.GetHashCode();
            return hashCode;
        }
    }
}
