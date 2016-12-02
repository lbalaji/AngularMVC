AngularJS Authentication / MVC Web API  
=======================
 
There are 4 projects included in this repo
1. Web- Api using Mongo as DB -http://localhost/ngauthenticationapi/

2. Web- Api using Sql Server as DB - http://localhost/ngauthenticationapisql/

3. Angular front end works with both databased based on your selection from Login and signup process

4. Test



Pre-requests
 	
o MongoDB and SQL server, IIS installed and configured 
	
o Configure connection string for both API projects
 


Test scenario

-	First Signup by providing username and password for selected database you want to use

<img src='http://lbalaji.github.io/images/pic_log.PNG'>

-	Site automatically takes you to calculations summary page

	
	o	Summary Page you can add/delete/edit existing calculations
	
	o	Able to filter by calculation name 
<img src='http://lbalaji.github.io/images/pic_summary.PNG'>

-	When you click Edit it will take you to detail page where you can  create new calculation
<img src='http://lbalaji.github.io/images/pic_detail.PNG'>
-	When you click Edit it will take you to detail page where you can change existing details and save into DB



Things to do:


- Merge both MVC API projects to provide single endpoint and configure routing


- Filters can be added using watcher to run real time from DB
- Write e2e testing for angular
