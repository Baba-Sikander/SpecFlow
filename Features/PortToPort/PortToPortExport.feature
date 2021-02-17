Feature: Port to Port export
	Contains scenarios for Port to Port Export Business Cases

Scenario: Create a New Port to Port Export Air Direct Job

	Given I am on Job application
	And go to job setup page
	When I select Business Product as "Freight" and Operational Process as "Port to Port Export"
	And I click on Next
	And I enter the Customer Details
	And I enter the Export instructions for Air Direct
	And I click on Next
	#And I enter the Services and Charges for Port to Port Export
	And I click on Create
	Then the Job should be created with a new Job ID
	And I should be able to click on Job ID to view the summary
	And Verify the Page Label is "Job ID | Port to Port Export"


Scenario: Create a Air direct job and complete all the stages
	Given I am on Job application
	And go to job setup page
	When I select Business Product as "Freight" and Operational Process as "Port to Port Export"
	And I click on Next
	And I enter the Customer Details
	And I enter the Export instructions for Air Direct
	And I click on Next
	#And I enter the Services and Charges for Port to Port Export
	And I click on Create
	And the Job should be created with a new Job ID
	And I should be able to click on Job ID to view the summary
	And Verify the Page Label is "Job ID | Port to Port Export"
	And I complete compliance check



Scenario: Create a New Port to Port Export Air House Job

	Given I am on Job application
	And go to job setup page
	When I select Business Product as "Freight" and Operational Process as "Port to Port Export"
	And I click on Next
	And I enter the Customer Details
	And I enter the Export instructions for Air House
	And I click on Next
	#And I enter the Services and Charges for Port to Port Export
	And I click on Create
	Then the Job should be created with a new Job ID
	And I should be able to click on Job ID to view the summary
	And Verify the Page Label is "Job ID | Port to Port Export"

Scenario: Create a New Port to Port Export Sea Direct Job

	Given I am on Job application
	And go to job setup page
	When I select Business Product as "Freight" and Operational Process as "Port to Port Export"
	And I click on Next
	And I enter the Customer Details
	And I enter the Export instructions for Sea Direct
	And I click on Next
	#And I enter the Services and Charges for Port to Port Export
	And I click on Create
	Then the Job should be created with a new Job ID
	And I should be able to click on Job ID to view the summary
	And Verify the Page Label is "Job ID | Port to Port Export"

Scenario: Create a New Port to Port Export Sea House Job

	Given I am on Job application
	And go to job setup page
	When I select Business Product as "Freight" and Operational Process as "Port to Port Export"
	And I click on Next
	And I enter the Customer Details
	And I enter the Export instructions for Sea House
	And I click on Next
	#And I enter the Services and Charges for Port to Port Export
	And I click on Create
	Then the Job should be created with a new Job ID
	And I should be able to click on Job ID to view the summary
	And Verify the Page Label is "Job ID | Port to Port Export"

