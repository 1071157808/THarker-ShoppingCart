using System;
using System.Collections.Generic;
using System.Text;

namespace KLWines.ShoppingCartService.Domain.Core.ValueObjects
{
    public struct AnonomousShopperId
    {
        public string Value { get; private set; }
        public AnonomousShopperId(string value)
        {
            Value = value;
        }
    }
}
