using System;
using System.Collections.Generic;
using System.Text;

namespace market.Core.Domain
{
    public class Client : Generic
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public Address Address { get; set; }
    }
}
