using KLWines.ShoppingCartService.Domain.Aggregates;
using KLWines.ShoppingCartService.Domain.Core.ValueObjects;
using KLWines.ShoppingCartService.Domain.Interfaces;
using KLWines.ShoppingCartService.Domain.Tests.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace KLWines.ShoppingCartService.Domain.Tests
{
    [Binding]
    public class ShoppingCartSteps
    {
        [TechTalk.SpecFlow.StepArgumentTransformation]
        public static IEnumerable<ProductRow> Convert(Table table) => table.CreateSet<ProductRow>();


        private IShoppingCart _shoppingCart;
        [Given(@"the shopping cart is empty")]
        public void GivenTheShoppingCartIsEmpty()
        {
            //ScenarioContext.Current.Add();
            _shoppingCart = new ShoppingCart();
        }
        
        [When(@"I add items to the shopping cart")]
        public async Task WhenIAddItemsToTheShoppingCart(IEnumerable<ProductRow> table)
        {
            foreach(var row in table)
            {
                await _shoppingCart.AddProductToBasket(new Product(row.Sku, ""), new ProductQuantity(row.Qty));
            }
        }

        [When(@"I remove items from the shopping cart")]
        public async Task WhenIRemoveItemsFromTheShoppingCart(Table table)
        {
            foreach(var row in table.Rows)
            {
                var sku = uint.Parse(row["Sku"]);
                await _shoppingCart.RemoveProductFromBasket(new Product(sku, ""));
            }
        }


        [Then(@"I should have ([0-9]*) unique items in my shopping cart")]
        public async Task ThenIShouldHaveUniqueItemsInMyShoppingCart(int expectedValue)
        {
            Assert.AreEqual(expectedValue,  _shoppingCart.CountUniqueProducts());
        }
        
        [Then(@"I should have ([0-9]*) total items in my shopping cart")]
        public async Task ThenIShouldHaveTotalItemsInMyShoppingCart(int expectedValue)
        {
            Assert.AreEqual(expectedValue, _shoppingCart.CountTotalProducts());
        }
    }
}
