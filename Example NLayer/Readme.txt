Start database (Code First):

Enable-Migrations -StartUpProjectName Infrastructure.Data.MainBoundedContext
Add-Migration -StartUpProjectName Infrastructure.Data.MainBoundedContext
Update-database -StartUpProjectName Infrastructure.Data.MainBoundedContext