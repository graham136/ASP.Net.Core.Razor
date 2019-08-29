# ASP.Net.Core.Razor

Install instructions
Please ensure your connection string is correct in your app.settings.json
Here is mine
"ConnectionStrings": {
    "PersonalTaxesDB": "Server=(localdb)\\mssqllocaldb;database=PersonalTaxesDB;Trusted_Connection=True;"
  }

Please add a migration in nuget package manager console
Add-Migration Asp.Net.Core.Razor.Models.PersonalTax

Update your database in nuget package manger. 
update-database

The database should be created.

<h1><b>Requirements</b></h1>
<p>Write a tax calculator using TDD</p>
<p>Use SOLID principals</p>
<p>Preferred testing framework is Nunit using full or core framework</p>
<p>Razor frontend</p>
<p>ORM of choice</p>
<p>Use of Design Patterns preferable</p>
<p>IOC/Dependency Injection</p>
<p>Allow for entering the Postal code and annual income on the front end and submitting</p>
<p>Store the calculated value to SQL Server with date/time and the two fields entered</p>
<p>Security is not required but feel free to show off</p>
<p>Server side should be REST API’s</p>
