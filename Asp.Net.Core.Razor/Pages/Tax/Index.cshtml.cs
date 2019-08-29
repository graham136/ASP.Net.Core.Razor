using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Asp.Net.Core.Razor.Api.Data;
using Asp.Net.Core.Razor.Models;

namespace Asp.Net.Core.Razor.Pages.Tax
{
    public class IndexModel : PageModel
    {
        private readonly Asp.Net.Core.Razor.Api.Data.PersonalTaxesDBContext _context;

        public IndexModel(Asp.Net.Core.Razor.Api.Data.PersonalTaxesDBContext context)
        {
            _context = context;
        }

        public IList<PersonalTax> PersonalTax { get;set; }

        public async Task OnGetAsync()
        {
            PersonalTax = await _context.PersonalTaxes.ToListAsync();
        }
    }
}
