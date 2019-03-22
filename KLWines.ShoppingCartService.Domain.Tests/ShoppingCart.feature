Feature: ShoppingCart
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@mytag
Scenario: AddItemsToShoppingCart
	Given the shopping cart is empty
	When I add items to the shopping cart
	Then I should have 1 unique items in my shopping cart
	And I should have 4 total items in my shopping cart
