using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Asp.Net.Core.Razor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Asp.Net.Core.Razor.Pages
{
    public class CalculateTaxModel : PageModel
    {
        public List<SelectListItem> taxCodeValues;
        [BindProperty]
        public PersonalTax PersonalTax { get; set; }
                
        public void OnGet()
        {
            taxCodeValues = new List<SelectListItem>()
            {
                new SelectListItem() { Value = TaxCodeTypes.FlatRate, Text = TaxCodeTypes.FlatRate },
                new SelectListItem() { Value = TaxCodeTypes.FlatValue, Text = TaxCodeTypes.FlatValue },
                new SelectListItem() { Value = TaxCodeTypes.ProgressiveA, Text =TaxCodeTypes.ProgressiveA },
                new SelectListItem() { Value = TaxCodeTypes.PorgressiveB, Text = TaxCodeTypes.PorgressiveB }
            };
            
        }
                
    }
}