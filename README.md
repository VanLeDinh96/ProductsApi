# Applying Migrations in EF Core
## Create Migrations
	1. Windows command prompt: "Add-Migration MigrationName [options]"
	2. dotnet CLI: "dotnet ef migrations add MigrationName [options]"
	=>> EX-PMC: "Add-Migration InitialMigrationDb"
	=>> EX-CLI: "dotnet ef migrations add InitialMigration --output-dir Your/Directory"

## Applying Created Migration
	1. Windows command prompt: "Update-Database [options]"
	2. dotnet CLI: "dotnet ef database update [options]"
	=>> EX-PMC: "Update-Database"

## Removing a Migration
	1. Windows command prompt: "Remove-Migration [options]"
	2. dotnet CLI: "dotnet ef migrations remove [options]"
	=>> EX-PMC: "Remove-Migration"

### Want to use RawQuery with EF to handle sort on multi columns with flexible sort strategy
=> Break up Clean Architecture Rule (Application have to reference to Persistence layer)

# Strategy for Execution Strategy

## SQL-SERVER-STRATEGY-1
 - Use ApplicationDbContext for entire source code => Handler global Transaction
	- Advantage:
		+ Can use pair with retry execution strategy
	- Downside:
		+ Break up Clean Architecture Rule (Application have to reference to Persistence layer)

## SQL-SERVER-STRATEGY-2
 - Use UnitOfWork for entire source code => Handler global Transaction
	- Advantage:
		+ Keep up Clean Architecture Rule (Application does not reference to Persistence layer)
	- Downside:
		+ Can not use pair with retry execution strategy