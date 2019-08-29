using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.Net.Core.Razor.Models
{
    /// <summary>
    /// Kind of a enum with two string values to keep the bugs at bay with taxcodes.
    /// </summary>
    public class TaxCodeTypes
    {
        public const string ProgressiveA = "7441";
        public const string PorgressiveB = "1000";
        public const string FlatValue = "A100";
        public const string FlatRate = "700";
    }
}
