"# LeadTrackerBKM" 
LeadTrackerBKM

Version 1.0
November 24, 2020

Written by Monique Coles, Kyle Whitmore, Brandon Garelli

The LeadTrackerBKM program is used to keep track of associations between Leads and Representatives for companies that are heavily involved in sales and marketing.


----------
DIRECTIONS
----------

After cloning the program to a specified folder, double-click on the LeadTrackerBKM.sln file to open the program in Microsoft Visual Studios (VS). At the top of VS, click the green play arrow to start the program and wait for the api to start in your default browser. In your browser window, copy the address (address) and paste it in the address bar of Postman. This will be the base address used for the /api/Account/Register , /api/Rep , /api/Lead , /api/Interaction objects.

Account Creation
----------------
To create an account, put (address)/api/Account/Register in the address bar of Postman. The following properties must be passed in the body of postman using a post method:
	Email
	Password
	ConfirmPassword
	
To acquire the token for a given user, in the address bar of Postman type in (addresss)/token and select the post method. Under the Headers tab type in Content-Type in the Key column and application/x-www-form-urlencoded in the Value column. In the Body tab type in grant_type, username, password in the Key column and password for the grant_type Value. For the username and password Values type in the email address and the password that was made for a given user during the Account Creation and press Send. Copy the token provided.

Under the Headers tab type Authorization in the Key column and Bearer "token" [no quotes] in the Value column. From this point on, that user will be able to perform the tasks below. To change a user, repeat the steps above for a different account that has been registered. Functional tasks for a user are as followed:

To create a Lead (Lead) object, the following properties must be provided:
	Name
	Company
	Phone
	Email
	Converted (true/false) [not required]

To create a Representative (Rep) object, the following properties must be provided:
	Name
	Email

To create an Interaction (Interaction) object, the following must be provided:
	LeadID
	RepID
	TypeOfContact (Phone, Email, SMS, InPerson)
	Description

To update any of the previous objects, the ID of the object must be passed as an argument in the body, not at the end of the url.
Updates require all arguments that creation requires.
To get an object by ID, the ID will be provided at the end of the url i.e. (address)/api/Lead/1

----------
Resources
----------
Planning documentation: https://docs.google.com/document/d/1Dz27c5xtcuLfnePVHNTGxDhnjUH1LIZoTMQGY2a4al8/edit?usp=sharing

Tables as first drafted: https://docs.google.com/spreadsheets/d/1KMTI0lShM2NRj8Xo-WzI1R67Uh4ft6_L40VwCsGgCVg/edit?usp=sharing

Template: https://elevenfifty.instructure.com/courses/433/pages

References: https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/linq/
	https://docs.microsoft.com/en-us/ef/ef6/fundamentals/relationships
	https://www.csharp-examples.net/linq-aggregation-methods/
	https://stackify.com/n-tier-architecture/
