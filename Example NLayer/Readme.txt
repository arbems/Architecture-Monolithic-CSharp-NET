* Use database (localdb)\v11.0 or SQLEXPRESS or SQL Server
* Update the data connection in App.config and Web.config

1.Enable migrations Entity Framework Code First:
	Enable-Migrations -StartUpProjectName Infrastructure.Data.Main
2.Add migration "Initial":
	Add-Migration -StartUpProjectName Infrastructure.Data.Main
3.Update database:
	Update-database -StartUpProjectName Infrastructure.Data.Main


* Implement Dependency injection (Unity)
* Adapter (AutoMapper)
* SQL Express
* Caching


* To create ASP MVC application, ASP MVC Core & Angular 4

Pending:
* Implement Automapper and Automapper Queryable extension
* Implement Caching
* Implement Web API
* Implement Send Email
* Implement Images
* Review Versions projects (.Net Framework 6 or .Net Core)