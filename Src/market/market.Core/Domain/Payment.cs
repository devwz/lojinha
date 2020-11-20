using System;
using System.Collections.Generic;
using System.Text;

namespace market.Core.Domain
{
    public class Payment
    {
        public string FullName { get; set; }
        public string CardNumber { get; set; }
        public DateTime Expiration { get; set; }
        public string CVV { get; set; }
    }
}
