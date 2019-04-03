using System;
using System.Collections.Generic;
using System.Text;

namespace KLWines.ShoppingCartService.Domain.Core.ValueObjects
{
    public class ProductQuantity : ValueObject<uint>
    {
        public ProductQuantity(uint val) : base(val)
        {
        }
    }
}
