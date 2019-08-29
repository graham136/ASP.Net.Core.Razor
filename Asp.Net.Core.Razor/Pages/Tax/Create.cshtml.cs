using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Asp.Net.Core.Razor.Api.Data;
using Asp.Net.Core.Razor.Models;

namespace Asp.Net.Core.Razor.Pages.Tax
{
    public class CreateModel : PageModel
    {
        private readonly Asp.Net.Core.Razor.Api.Data.PersonalTaxesDBContext _context;
        public List<SelectListItem> taxCodeValues;

        public CreateModel(Asp.Net.Core.Razor.Api.Data.PersonalTaxesDBContext context)
        {
            _context = context;
            taxCodeValues = new List<SelectListItem>()
            {
                new SelectListItem() { Value = TaxCodeTypes.FlatRate, Text = TaxCodeTypes.FlatRate },
                new SelectListItem() { Value = TaxCodeTypes.FlatValue, Text = TaxCodeTypes.FlatValue },
                new SelectListItem() { Value = TaxCodeTypes.ProgressiveA, Text =TaxCodeTypes.ProgressiveA },
                new SelectListItem() { Value = TaxCodeTypes.PorgressiveB, Text = TaxCodeTypes.PorgressiveB }
            };
        }

        public IActionResult OnGet()
        {
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