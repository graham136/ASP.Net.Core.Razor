# ASP.Net.Core.Razor

<h1><b>Install instructions</b></h1>
<p> Open ASP.Net.Core.Razor.sln in visual studio</p>
<p>Please ensure your connection string is correct in your app.settings.json</p>
<p>Here is mine</p>
<p>"ConnectionStrings": {</p>
<p>    "PersonalTaxesDB": "Server=(localdb)\\mssqllocaldb;database=PersonalTaxesDB;Trusted_Connection=True;"</p>
<p>  }</p>

<p>Please ensure you have MssqlLocalDB extension installed for mssqlserver.</p>

<p>Please add a migration in nuget package manager console</p>
<p>"Add-Migration Asp.Net.Core.Razor.Models.PersonalTax"</p>

<p>Update your database in nuget package manger. </p>
<p>"update-database"</p>

<p>The local database should be created. Please build and run the app.</p>
