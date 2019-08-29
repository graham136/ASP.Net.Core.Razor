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
    public class DetailsModel : PageModel
    {
        private readonly Asp.Net.Core.Razor.Api.Data.PersonalTaxesDBContext _context;

        public DetailsModel(Asp.Net.Core.Razor.Api.Data.PersonalTaxesDBContext context)
        {
            _context = context;
        }

        public PersonalTax PersonalTax { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            PersonalTax = await _context.PersonalTaxes.FirstOrDefaultAsync(m => m.Id == id);

            if (PersonalTax == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
