using System;
using System.Collections.Generic;
using System.Text;

namespace greengrocer.Core.Domain
{
    public class Product : Generic
    {
        public string Bio { get; set; }
        public bool Enabled { get; set; }
        public string ImgUrl { get; set; }
        public decimal Price { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }
    }
}
