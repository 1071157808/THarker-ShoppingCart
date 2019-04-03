Feature: ShoppingCart
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@mytag
Scenario: AddItemsToShoppingCart
	Given the shopping cart is empty
	When I add items to the shopping cart
	| Sku  | Qty |
	| 1000 | 2   |
	Then I should have 1 unique items in my shopping cart
	And I should have 2 total items in my shopping cart

Scenario: AddItemsToShoppingCartThenRemoveThemAll
	Given the shopping cart is empty
	When I add items to the shopping cart
	| Sku  | Qty |
	| 1000 | 2   |
	| 1001 | 1   |
	Then I should have 2 unique items in my shopping cart
	And I should have 3 total items in my shopping cart
