using System;
using System.Collections.Generic;
using System.Text;

namespace KLWines.ShoppingCartService.Domain.Core.ValueObjects
{
    public struct ShopperId
    {
        public string Value { get; }
        public ShopperId(string value)
        {
            Value = value;
        }
    }
}
