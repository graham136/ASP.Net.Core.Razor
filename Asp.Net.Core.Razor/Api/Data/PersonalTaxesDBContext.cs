using Asp.Net.Core.Razor.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.Net.Core.Razor.Api.Data
{
    // Entity framework core DBContext connecting to SQL server localdb
    // Type update-database in the nuget package manager to create your local db.
    public class PersonalTaxesDBContext : DbContext
    {

        public DbSet<PersonalTax> PersonalTaxes { get; set; }

        public PersonalTaxesDBContext(DbContextOptions options)
        : base(options)
        {
        }

    }
}
