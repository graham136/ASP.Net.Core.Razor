using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Asp.Net.Core.Razor.Api.Data;
using Asp.Net.Core.Razor.Models;

namespace Asp.Net.Core.Razor.Pages.Taxes
{
    public class CreateModel : PageModel
    {
        private readonly Asp.Net.Core.Razor.Api.Data.PersonalTaxesDBContext _context;
        public IEnumerable<string> taxCodeValues;

        public CreateModel(Asp.Net.Core.Razor.Api.Data.PersonalTaxesDBContext context)
        {
            _context = context;            
        }

        public IActionResult OnGet()
        {
            taxCodeValues =new List<string>()
            {
                TaxCodeTypes.FlatRate,
                TaxCodeTypes.FlatValue,
                TaxCodeTypes.ProgressiveA,
                TaxCodeTypes.PorgressiveB
            };
            return Page();
        }

        [BindProperty]
        public PersonalTax PersonalTax { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.PersonalTaxes.Add(PersonalTax);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}