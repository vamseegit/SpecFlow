Feature: FlipkartFeature
	As a customer
	I should be able to
	Get product list, sort it, filter it and add to cart

@mytag
Scenario Outline: Sort product on the basis of Price - Low to High
	Given I have logged into  flipkart <Username> <Password> <VerifyName>
	When I search product <ProductName> 
	And Sort Price by Low to High
	Then I should get the product sorted product list
	Examples: 
	| Username   | Password      | VerifyName | ProductName	  |
	|			 |				 | Arjun      | Adidas Shoes  |
	
	