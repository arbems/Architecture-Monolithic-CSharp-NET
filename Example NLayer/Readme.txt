* Use database (localdb)\v11.0 or SQLEXPRESS or SQL Server
* Update the data connection in App.config and Web.config

1.Enable migrations Entity Framework Code First:
	Enable-Migrations -StartUpProjectName Infrastructure.Data.MainBoundedContext
2.Add migration "Initial":
	Add-Migration -StartUpProjectName Infrastructure.Data.MainBoundedContext
3.Update database:
	Update-database -StartUpProjectName Infrastructure.Data.MainBoundedContext


* Implement Dependency injection (Unity)
* Adapter (AutoMapper)
* SQL Express
* Caching


* To create ASP MVC application, ASP MVC Core & Angular 4