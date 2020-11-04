"# LeadTrackerBKM" 
LeadTrackerBKM

Version 1.0
November 24, 2020

Written by Monique Coles, Kyle Whitmore, Brandon Garelli

The LeadTrackerBKM program is used to keep track of associations between Leads and Representatives for companies that are heavily involved in sales and marketing.

To create a Lead (Lead) object, the following properties must be provided:
	Name
	Company
	Phone
	Email
	Converted (true/false) [not required]

To create a Representative (Rep) object, the following must be provided:
	Name
	Email

To create an Interaction (Interaction) object, the following must be provided:
	LeadID
	RepID
	TypeOfContact (Phone, Email, SMS, InPerson)
	Description

To update any of the previous objects, the ID of the object must be passed as an argument in the body, not at the end of the url.
Updates require all arguments that creation requires.
To get an object by ID, the ID will be provided at the end of the url.
