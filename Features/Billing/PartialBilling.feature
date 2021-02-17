@Partial_Billing


Feature: Partial Billing - Select Service(s) & Charge (s) to invoice

#Scenario 1
Scenario: Verify an operations user is able to Select Services and Charges for the Selected Customer and Single Job
	Given I am on Billing Dashboard Page
	When I Click on Start Billing for any of the Jobs in Ready for Billing Status
	And  I Select a Customer
	And  I select single Job to be billed
	Then I should be able to select checkboxes for different services and charges


#Scenario 2
Scenario: Verify user is able to Save the Billing Invoice for Multiple Job and Services
	Given I am on the Billing Screen
	When I Select a Customer
	And I enter all the mandatory details for the Customer
	And I select multiple  Jobs to be Billed
	And I select Multiple Services and Charges
	And I click on Save
	Then The Invoice should be saved successfully


#Scenario 3
Scenario: Verify user is able to Save the Billing Invoice for Single Job and multiple Services
	Given I am on the Billing Screen
	When I Select a Customer
	And I enter all the mandatory details for the Customer
	And I select single Job to be billed
	And I select Multiple Services and Charges
	And I click on Save
	Then The Invoice should be saved successfully


#Scenario 4
Scenario: Verify All Charges and Services are auto-selected when Selecting a Job
	Given I am on the Billing Screen
	When When I select a Customer
	And And I select single Job to be billed
	Then All the services and charges for the Selected Job should be checked

#Scenario 5
Scenario: Verify the Total Value is automatically calculated after Saving the Selected Services and Charges
	Given I am on the Billing Screen
	When  I Select a Customer
	And I enter all the mandatory details for the Customer
	And I select single Job to be billed
	And I select Multiple Services and Charges
	And I click on Save
	Then Verify the Total Value of the Invoice is automatically calculated

	
#Scenario 6
Scenario: Verify the Status of the Job is Set to "Partially Billed" once the Invoice for the chosen services and charges are finalized
	Given I am on the Billing Screen
	When When I select a Customer
	And I enter all the mandatory details for the Customer
	And I select single Job to be billed
	And I select Multiple Services and Charges
	And I click on Save
	Then The Invoice should be saved successfully
	And I should be navifated to the Billing Dashboard Page
	And The Status of the Job should be set as <Partially Billed>