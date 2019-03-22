using KLWines.ShoppingCartService.Domain.Interfaces;
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

            ScenarioContext.Current.Pending();
        }
        
        [When(@"I add items to the shopping cart")]
        public void WhenIAddItemsToTheShoppingCart()
        {
            ScenarioContext.Current.Pending();
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
