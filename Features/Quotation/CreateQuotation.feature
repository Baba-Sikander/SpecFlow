Feature: CreateQuotation


@SmokeTest
Scenario: Create a Quote for vessel call

	Given I am on my Dashboard
	And I get the last successful quotation number
	When I click on Create New Quote
	And I enter all quotation setup details
	And I select commercial service as vesel call
	And I select assign agents
	And I enter Vessel and Voyage detais
	And I enter crew details of the vessel call
	And I enter cargo details of vessel call
	And I save the quote
	Then I should be able to see the quote in dashboard
	And I should be able open the created quotation search by Quotation Number


Scenario: Create a Quote for Crew Change

	Given I am on my Dashboard
	And I get the last successful quotation number
	When I click on Create New Quote
	And I enter all quotation setup details
	And I select commercial service as Crew Change
	And I select assign agents
	And I enter Vessel and Voyage detais
	And I enter crew details of the vessel call
	And I save the quote
	Then I should be able to see the quote in dashboard
	And I should be able open the created quotation search by Quotation Number

Scenario: Create a Quote for Door To Door

	Given I am on my Dashboard
	And I get the last successful quotation number
	When I click on Create New Quote
	And I enter all quotation setup details
	And I select commercial service as Door to Door
	And I select assign agents
	And I save the quote
	Then I should be able to see the quote in dashboard
	And I should be able open the created quotation search by Quotation Number
