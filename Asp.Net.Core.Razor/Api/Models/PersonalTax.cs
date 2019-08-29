using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.Net.Core.Razor.Models
{
    /// <summary>
    /// Model that is used to save to the database
    /// </summary>
    public class PersonalTax
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string PostalCode { get; set; }

        [Required]
        [Range(0.0, Double.MaxValue)]
        public Decimal TaxableIncome { get; set; }

        [Required]
        public DateTime LogTime { get; set; }
        public Decimal Tax { get; set; }
                
    }
}
