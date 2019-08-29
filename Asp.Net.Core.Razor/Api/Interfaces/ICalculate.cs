using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.Net.Core.Razor.Api.Interfaces
{
    /// <summary>
    /// Interface to calculate tax logic
    /// </summary>
    public interface ICalculate
    {
       decimal calculateTax(string PostalCode,decimal Income);
    }
}
