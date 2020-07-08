using System;
using System.Collections.Generic;
using System.Text;

namespace lojinha.Core.Domain
{
    public class Client : Generic
    {
        public string Login { get; set; }
        public Address Address { get; set; }
    }
}
