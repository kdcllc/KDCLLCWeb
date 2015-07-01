#Database Migrations

update-database -ConfigurationTypeName KDCLLC.Identity.Services.Data.Migrations.Configuration -Verbose

add-migration -ConfigurationTypeName KDCLLC.Identity.Services.Data.Migrations.Configuration -name Profilev1

Add-Migration InitialProfileMigrations -IgnoreChanges -ConfigurationTypeName KDCLLC.Identity.Services.Data.Migrations.Configuration 
