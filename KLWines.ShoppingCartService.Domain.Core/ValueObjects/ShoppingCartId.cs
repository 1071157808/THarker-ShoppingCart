using System;
using System.Collections.Generic;
using System.Text;

namespace KLWines.ShoppingCartService.Domain.Core.ValueObjects
{
    public struct ShoppingCartId
    {
        public Guid Value { get; set; }
        public ShoppingCartId(Guid value)
        {
            Value = value;
        }
    }
}
