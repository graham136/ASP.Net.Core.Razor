using Asp.Net.Core.Razor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.Net.Core.Razor.Api.Interfaces
{
    interface ITaxCalculator
    {
        IEnumerable<PersonalTax> PersonalTaxGetAll();
        PersonalTax PersonalTaxGetById(int Id);
        PersonalTax PersonalTaxUpdateItem(PersonalTax updatedPersonalTax);
        PersonalTax PersonalTaxAddItem(PersonalTax addedPersonalTax);
        PersonalTax PersonalTaxDeleteItem(int Id);
    }
}
