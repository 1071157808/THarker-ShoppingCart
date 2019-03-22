using KLWines.ShoppingCartService.Domain.Aggregates;
using KLWines.ShoppingCartService.Domain.Interfaces;
using KLWines.ShoppingCartService.Domain.ValueObjects;
using System;
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
        public void WhenIAddItemsToTheShoppingCart(Table table)
        {
            foreach(var row in table.Rows)
            {
                var sku = int.Parse(row["Sku"]);
                var qty = int.Parse(row["Qty"]);
                _shoppingCart.AddProductToBasket(new Product(sku, ""), 1);
            }
        }
        
        [Then(@"I should have (.*) unique items in my shopping cart")]
        public void ThenIShouldHaveUniqueItemsInMyShoppingCart(int p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"I should have (.*) total items in my shopping cart")]
        public void ThenIShouldHaveTotalItemsInMyShoppingCart(int p0)
        {
            ScenarioContext.Current.Pending();
        }
    }
}
