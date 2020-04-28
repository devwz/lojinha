using System;
using System.Collections.Generic;
using System.Text;

namespace lojinha.Core.Domain
{
    public class Product : Generic
    {
        public string Title { get; set; }
        public decimal Price { get; set; }
        public string Bio { get; set; }
        public string ImgUrl { get; set; }
    }
}
