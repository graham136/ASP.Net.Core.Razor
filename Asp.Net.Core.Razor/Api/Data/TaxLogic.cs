using Asp.Net.Core.Razor.Api.Interfaces;
using Asp.Net.Core.Razor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.Net.Core.Razor.Api.Data
{
    // Implementation of the ICalculate service. Used to implement the tax calculations
    public class TaxLogic : ICalculate
    {
        public decimal calculateTax(string postalCode,decimal income)
        {
           decimal tax = 0;
           
            if (postalCode == TaxCodeTypes.FlatValue)
            {
                tax = calculateFlatValue(income);
                return tax;
            }

            if (postalCode == TaxCodeTypes.FlatRate)
            {
                tax = calculateFlatRate(income);
                return tax;
            }

            if (postalCode == TaxCodeTypes.ProgressiveA || postalCode == TaxCodeTypes.PorgressiveB)
            {
                tax = calculateProgressive(income);
                return tax;
            }

            return tax;
        }

        public decimal calculateFlatRate(decimal income)
        {
            if (income < 0)
            {
                return 0;
            }

            decimal tax = 0;
            tax = income * 17.5m / 100m;
            tax = Math.Round(tax, 2, MidpointRounding.AwayFromZero);
            return tax;
        }

        public decimal calculateFlatValue(decimal income)
        {

            if (income < 0)
            {
                return 0;
            }

            decimal tax = 10000;
            if (income < 200000)
            {
                tax = income * 5 / 100;
                tax = Math.Round(tax, 2, MidpointRounding.AwayFromZero);
            }
            return tax;
        }
        // 10 % 0 - 8350 , 15% 8351 - 33950  (0 - 8350 at 10%), 25% 33951 - 82250 (8351 - 33950 15%) , 28% 82251 - 171550 (33951- 82250.93 25%) , 33% 171551 - 372950 ( 82251 - 171550 28% ), 35% 372951 (171551 - 372950 33%) 

        public decimal calculateProgressive(decimal income)
        {

            if (income < 0)
            {
                return 0;
            }

            var taxBands = new[]
            {
                new { Lower = 0m, Upper = 8350m, Rate = 0.1m },
                new { Lower = 8351m, Upper = 33950m, Rate = 0.15m },
                new { Lower = 33951m, Upper = 82250m, Rate = 0.25m },
                new { Lower = 82251m, Upper = 171550m, Rate = 0.28m },
                new { Lower = 171551m, Upper = 372950m, Rate = 0.33m },
                new { Lower = 372950m, Upper = decimal.MaxValue, Rate = 0.35m },
            };

            var salary = income; 
            var tax = 0m;

            foreach (var band in taxBands)
            {
                if (salary > band.Lower)
                {
                    var taxableAtThisRate = Math.Min(band.Upper - band.Lower, salary - band.Lower);
                    var taxThisBand = taxableAtThisRate * band.Rate;
                    tax += taxThisBand;
                }
            }
                        
            return tax;
        }
    }
}
