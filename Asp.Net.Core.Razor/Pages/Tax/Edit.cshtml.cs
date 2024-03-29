﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Asp.Net.Core.Razor.Api.Data;
using Asp.Net.Core.Razor.Models;

namespace Asp.Net.Core.Razor.Pages.Tax
{
    public class EditModel : PageModel
    {
        private readonly Asp.Net.Core.Razor.Api.Data.PersonalTaxesDBContext _context;
        public List<SelectListItem> taxCodeValues;

        public EditModel(Asp.Net.Core.Razor.Api.Data.PersonalTaxesDBContext context)
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

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(PersonalTax).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonalTaxExists(PersonalTax.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool PersonalTaxExists(int id)
        {
            return _context.PersonalTaxes.Any(e => e.Id == id);
        }
    }
}
