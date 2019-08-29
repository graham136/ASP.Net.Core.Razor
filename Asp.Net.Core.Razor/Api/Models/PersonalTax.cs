using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.Net.Core.Razor.Models
{
    public class PersonalTax
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string PostalCode { get; set; }

        [Required] 
        public Double TaxableIncome { get; set; }

        [Required]
        public DateTime LogTime { get; set; }
                
    }
}
