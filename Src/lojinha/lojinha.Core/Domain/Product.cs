using System;
using System.Collections.Generic;
using System.Text;

namespace lojinha.Core.Domain
{
    public class Product : Generic
    {
        public Product()
        {

        }

        public Product(int id, string title, decimal price)
        {
            Id = id;
            Title = title;
            Price = price;
        }

        public string Bio { get; set; }
        public bool Enabled { get; set; }
        public string ImgUrl { get; set; }
        public decimal Price { get; set; }
        public string Title { get; set; }
    }
}
