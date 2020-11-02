using System;
using System.Collections.Generic;
using System.Text;

namespace greengrocer.Core.Domain
{
    public class Order : Generic
    {
        public string OrderKey { get; set; }
        public Cart Cart { get; set; }
        public Client Client { get; set; }
    }
}
