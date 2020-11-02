using System;
using System.Collections.Generic;
using System.Text;

namespace greengrocer.Core.Domain
{
    public class Item : Generic
    {
        public string ImgUrl { get; set; }
        public decimal Price { get; set; }
        public string Title { get; set; }
        public int Unid { get; set; }
    }
}
