Feature: Create Billing
	
@SmokeTest
Scenario: Create Billing
	Given I am on Billing Dashboard Page
	When I select Jobs for a customer to Bill
	And I enter the Customer and Billing Details
	And I enter the services and charges for the selected Jobs
	And I check the checkbox for the charge
	And I click on View Summary
	Then I should be navigated to Billing Summary screen
	And Print Draft and Final Button should be displayed