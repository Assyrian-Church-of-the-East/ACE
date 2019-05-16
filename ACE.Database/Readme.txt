
To add a migration (using package manager console):
-------------------------------------------------------------
add-migration "Initialize" -context "AceDbContext"

To update database (using package manager console):
-------------------------------------------------------------
update-database -context "AceDbContext"

To target previous data-migration in the db
-------------------------------------------------------------
Update-Database "Initialize" -context "AceDbContext"

To remove the last migration from the project and NOT from database
-------------------------------------------------------------
Remove-Migration -context "AceDbContext"

