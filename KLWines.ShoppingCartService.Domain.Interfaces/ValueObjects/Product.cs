﻿using KLWines.ShoppingCartService.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace KLWines.ShoppingCartService.Interfaces.ValueObjects
{
    public struct Product
    {
        public int Sku { get; private set; }
        public string Name { get; private set; }

        public Product(int sku, string name)
        {
            Sku = sku;
            Name = name;
        }
    }
}