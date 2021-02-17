@Billing
Feature: PJM-1684_BillingSummary
	
Scenario: Verify the Billing Summary Screen for a Customer for Single Job
	Given User is on the Billing Dashboard Screen
	When User Clicks on + icon for any customer
	And Clicks on a checkbox for a Job
	And Enters the Billing Details
	And Enters the Customer Details
	And Selects single Service and multiple Charges fron the Line Items List
	And Enters the Charge Details
	And Clicks on Save
	And Clicks on View Summary
	Then Verify the GAC Company Details and Bank Details are displayed
	And The Billing Header section have following fields - Billing Party, Customer Name, Customer Reference Number, Email Address, Phone Number, Address Line 1, Address Line 2, City/Town, Country
	And The Payment Term and the selected Job Number on the Billing Summary Page
	And The Job Details Table for following columns - Job Number, Operational Process, Services/Charges, Supplier Name, Quantity, UOM, Unit Price, Billing Amount

Scenario: Verify the Billing Summary Screen for a Customer for Multiple Job
	Given User is on the Billing Screen
	When User selects a Customer
	And Clicks on multiple checkboxes to select Jobs
	And Enters the Billing Details
	And Enters the Customer Details
	And Selects single Service and multiple Charges fron the Line Items List
	And Enters the Charge Details
	And Clicks on View Summary
	Then Verify the GAC Company Details and Bank Details are displayed
	And The Billing Header section have following fields - Billing Party, Customer Name, Customer Reference Number, Email Address, Phone Number, Address Line 1, Address Line 2, City/Town, Country
	And The Payment Term and the selected Job Number on the Billing Summary Page
	And The Job Details Table for following columns - Job Number, Operational Process, Services/Charges, Supplier Name, Quantity, UOM, Unit Price, Billing Amount
