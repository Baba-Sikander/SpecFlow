Feature: Billing_SmokTest
	Contains scenarios for all the Billing Module Page Navigation scenarios

@SmokeSuite
Scenario: Verify Billing Dashboard - Ready for Billing Tab
	Given I am on Billing Dashboard
	When I Navigate to Ready for Billing Tab
	Then I should be able to see following filters - Customer, Job Number, Billing Priority and Business Area
	And I should be able to see the Customers in the Grid

Scenario: Verify the count of Ready for Billing, Billing in Progress and Invoices
	Given I am on Billing Dashboard
	When I Navigate to Ready for Billing Tab
	Then I should be able to see the count of Customers on Ready for Billing and Billing Progress
	And I should be able to see the count of documents on the Invoices tab

Scenario: Verify Billing Dashboard - Billing in Progress Tab
	Given I am on Billing Dashboard
	When I Navigate to Billing in Progress Tab
	Then I should be able to see following filters - Customer, Job Number, Transaction Number, Billing Party and Transaction To and From Date
	And I should be able to see the Customers in the Grid

Scenario: Verify Billing Dashboard - Invoices Tab
	Given I am on Billing Dashboard
	When I Navigate to Invoices Tab
	Then I should be able to see following filters - Customer, Invoice Number, Job Number, Billing Party, Invoice Date To and From, Due Date To and From, Invoice Type and Invoice Status
