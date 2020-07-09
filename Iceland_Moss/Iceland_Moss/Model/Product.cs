using System;
using System.Collections.Generic;
using System.Text;

namespace Iceland_Moss.Model
{
    public class Product
    {
        public int Sort { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public decimal Price { get; set; }
        public string HeroColor { get; set; }
        public bool IsFeatured { get; set; }
        public double Height { get; set; }

        //todo - 
    }
}
