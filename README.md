# ASP.Net.Core.Razor

<h1><b>Install instructions</b></h1>
<p> Open ASP.Net.Core.Razor.sln in visual studio</p>
<p>Please ensure your connection string is correct in your app.settings.json</p>
<p>Here is mine</p>
<p>"ConnectionStrings": {</p>
<p>    "PersonalTaxesDB": "Server=(localdb)\\mssqllocaldb;database=PersonalTaxesDB;Trusted_Connection=True;"</p>
<p>  }</p>

<p>Please add a migration in nuget package manager console</p>
<p>"Add-Migration Asp.Net.Core.Razor.Models.PersonalTax"</p>

<p>Update your database in nuget package manger. </p>
<p>"update-database"</p>

<p>The database should be created. Please build and run the app.</p>

<h1><b>Requirements</b></h1>
<p>Write a tax calculator using TDD - please checkout my tests project for logic and controller tests</p>
<p>Use SOLID principals - You Bet</p>
<p>Preferred testing framework is Nunit using full or core framework - Testing is done in Nunit</p>
<p>Razor frontend - Definitely</p>
<p>ORM of choice - Entity Framework Core</p>
<p>Use of Design Patterns preferable - Repository Pattern, MCV Pattern</p>
<p>IOC/Dependency Injection - Two services injected ICalculate, IDataRepository</p>
<p>Allow for entering the Postal code and annual income on the front end and submitting - Done, Added dropdown and validation</p>
<p>Store the calculated value to SQL Server with date/time and the two fields entered - Done, Please Check out the git repo readme to setup the database.</p>
<p>Security is not required but feel free to show off - Sorry no security</p>
<p>Server side should be REST API’s - Definitely</p>
