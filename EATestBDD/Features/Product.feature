Feature: Product
	Testing the product page functionalities.

Background: 
	Given I cleanup the following data
		| Name       | Description        | Price | ProductType |
		| Headphones | Noise cancellation | 300   | PERIPHARALS |
		| Monitor    | HD monitor         | 400   | MONITOR     |

@mytag @retry(2)
Scenario: Create product and verify the details
	Given I click the Product menu
	And I click the "Create New" link
	And I create a product with the following details
		| Name       | Description        | Price | ProductType |
		| Headphones | Noise cancellation | 300   | PERIPHARALS |
	When I click the Details link of the newly created product
	Then I see all the product details are created as expected
	And I delete the product Headphones for cleanup

@mytag @retry(2)
Scenario: Edit Product and verify its updated
	Given I ensure the following product is created
		| Name    | Description | Price | ProductType |
		| Monitor | HD monitor  | 400   | MONITOR     |
	And I click the Product menu
	When I click the Edit link of the newly created product
	And I edit the product details with the following
		| Name    | Description           | Price | ProductType |
		| Monitor | HD Resolution monitor | 500   | MONITOR     |
	And I click the Details link of the newly created product
	Then I see all the product details are created as expected
	And I delete the product Monitor for cleanup