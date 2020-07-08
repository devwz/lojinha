using System;
using System.Collections.Generic;
using System.Text;

namespace lojinha.Core.Domain
{
    public class Order : Generic
    {
        public Cart Cart { get; set; }
        public Client Client { get; set; }
    }
}
