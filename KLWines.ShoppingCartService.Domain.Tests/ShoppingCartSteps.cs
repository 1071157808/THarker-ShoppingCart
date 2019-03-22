using KLWines.ShoppingCartService.Domain.Aggregates;
using KLWines.ShoppingCartService.Domain.Interfaces;
using KLWines.ShoppingCartService.Domain.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace KLWines.ShoppingCartService.Domain.Tests
{
    [Binding]
    public class ShoppingCartSteps
    {
        private IShoppingCart _shoppingCart;
        [Given(@"the shopping cart is empty")]
        public void GivenTheShoppingCartIsEmpty()
        {
            _shoppingCart = new ShoppingCart();
        }
        
        [When(@"I add items to the shopping cart")]
        public async Task WhenIAddItemsToTheShoppingCart(Table table)
        {
            foreach(var row in table.Rows)
            {
                var sku = int.Parse(row["Sku"]);
                var qty = int.Parse(row["Qty"]);
                await _shoppingCart.AddProductToBasket(new Product(sku, ""), 1);
            }
        }

        [When(@"I remove items from the shopping cart")]
        public async Task WhenIRemoveItemsFromTheShoppingCart(Table table)
        {
            foreach(var row in table.Rows)
            {
                var sku = int.Parse(row["Sku"]);
                await _shoppingCart.RemoveProductFromBasket(new Product(sku, ""));
            }
        }


        [Then(@"I should have ([0-9]*) unique items in my shopping cart")]
        public async Task ThenIShouldHaveUniqueItemsInMyShoppingCart(int expectedValue)
        {
            Assert.AreEqual(expectedValue, await _shoppingCart.CountUniqueProducts());
        }
        
        [Then(@"I should have ([0-9]*) total items in my shopping cart")]
        public async Task ThenIShouldHaveTotalItemsInMyShoppingCart(int expectedValue)
        {
            Assert.AreEqual(expectedValue, await _shoppingCart.CountTotalProducts());
        }
    }
}
