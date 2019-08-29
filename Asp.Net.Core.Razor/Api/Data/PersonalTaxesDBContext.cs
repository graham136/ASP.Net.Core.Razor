using Asp.Net.Core.Razor.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.Net.Core.Razor.Api.Data
{
    public class PersonalTaxesDBContext : DbContext
    {

        public DbSet<PersonalTax> PersonalTaxes { get; set; }

        public PersonalTaxesDBContext(DbContextOptions options)
        : base(options)
        {
        }

    }
}
