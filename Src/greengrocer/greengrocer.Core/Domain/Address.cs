using System;
using System.Collections.Generic;
using System.Text;

namespace greengrocer.Core.Domain
{
    public class Address : Generic
    {
        public string AddressLine { get; set; }
        public string CountryRegion { get; set; }
        public string PostalCode { get; set; }
        public string StateProvince { get; set; }
    }
}
