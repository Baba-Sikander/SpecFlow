@VesselTracking
Feature: Vessel Tracking
	Contains scenarios for Vessel Tracking Business Cases

Background: 
	Given I login to the Pegasus Application
	And I navigate to the Job module

Scenario: Create an End to End Vessel Tracking Process
	Given I create a new Job for "Vessel Tracking"
    When I navigate to the Job Summary Page
	And I convert ETA, ETB and ETC to ATA, ATB and ATC respectively
	And I add all the Events
	And I click on Update
	And I Create SOF
	And I complete the Captain's Approval
	And I complete the Agent's Review
	And I convert the ETD to ATD
	Then The OP status should be moved to Vessel Departed

Scenario: Create a New VT Job
	Given I click on Create a Job
	When I select the Business Product as "Ship Agency" and Operational Process as "Vessel Tracking"
	And I click on Next
	And I enter the Customer and Vessel Details
	And I click on Next
	And I enter the Services and Charges
	And I click on Create
	Then the Job should be created with a new Job ID
	And I should be able to click on Job ID to view the summary

Scenario: Verify the Job Summary for the new Job
	Given  I create a new Job for "Vessel Tracking"
	When I click on the Local Job ID
	Then I should be navigated to the Summary view in a new Tab
	And Verify the Page Label is "Job ID | Vessel Tracking"
	And Verify the Page Sections are Vessel Tracking Details, Services & Charges, Notification Group Settings, Forecasting and Events

Scenario: Create a New Vessel tracking job and add documents to VesselTracking ops
    Given  I create a new Job for "Vessel Tracking"
    When I navigate to the Job Summary Page
    And I click on Documents tab
    Then I should be able to add Vessel Documents

Scenario: Add Events to a Vessel Tracking Jobs
    Given I create a new Job for "Vessel Tracking"
    When I navigate to the Job Summary Page
    And I navigate to the Event section
    Then I should be able to add Events
	And I should be able to add Stoppages and Remarks
	And I should be able to add Stoppages and Remarks
	And I should be able to add Bunkers
	And I should be able to add Draft
	And I should be able to add Tugs
	And I should be able to add Cargo Details

Scenario: Verify and modify forecasting information
    Given I am on Job dashboard
    When I create New Job for Vessel Tracking op process
    Then Local Job Id and Operational Id should be created
    And If I access Summary tab of Vessel Tracking Ops screen
    Then I should be able to update forecasting information(ETA, ETB)
    And I should be able to Convert and update Actual information(ATA, ATB)

Scenario: Verify the Job Summary for the existing Job
	Given I am on Job dashboard
	When I search for Vessel Tracking Jobs
	And I select an open Job created by "Agent_Name"
	And I access operational process summary
	Then I should be navigated to the Summary view in a new Tab
	And I should be able to add Events
	And I should be able to add Tugs
	And I should be able to add Cargo Details

Scenario: Verify Agent's Review after Captain rejects an SOF
	Given I create a new Job
    When I navigate to the Job Summary Page
	And I convert ETA, ETB and ETC to ATA, ATB and ATC respectively
	And I add all the Events
	And I click on Update
	And I Create SOF
	And The Captain Rejects the SOF
	And Sends back to Agent
	Then The Agent's Review screen should be displayed with "SOF REJECTED"
	And I can resend the SOF to the Captain
	And The Captain's Approval button is displayed and enabled

Scenario: Verify Agent can Return an SOF to captain after Captain's Approval
	Given I create a new Job
    When I navigate to the Job Summary Page
	And I convert ETA, ETB and ETC to ATA, ATB and ATC respectively
	And I add all the Events
	And I click on Update
	And I Create SOF
	And I complete the Captain's Approval
	And I return the SOF back to Captain
	Then The Captain's Approval button is displayed and enabled

#Repeat this scenario for ETB, ETC and ETD
Scenario: Verify Events tab after the Estimated Time is changed for ETA
	Given I create a new Job
    When I navigate to the Job Summary Page
	When I change the Estimated date and time
	And I convert it to actual
	And I click on Update
	And I navigate to the Event Tab
	Then An event should be added to the Event List
	And The Event Details remark should be displayed as "ETX updated from [DATE TIME] to [DATE TIME]"