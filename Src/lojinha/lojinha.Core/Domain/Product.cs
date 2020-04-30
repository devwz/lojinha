using System;
using System.Collections.Generic;
using System.Text;

namespace lojinha.Core.Domain
{
    public class Product : Generic
    {
        public string Bio { get; set; }
        public bool Enabled { get; set; }
        public string ImgUrl { get; set; }
        public decimal Price { get; set; }
        public string Title { get; set; }
    }
}
