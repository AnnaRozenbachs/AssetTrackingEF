using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetTrackingEF.Models
{
    public class Office
    {
        public Office(string country, decimal rate, string currency)
        {
            Country = country;
            Rate = rate;
            Currency = currency;
        }

        public int Id { get; set; }

        public string Country { get; set; }

        public decimal Rate { get; set; }

        public string Currency { get; set; }
    }
}
