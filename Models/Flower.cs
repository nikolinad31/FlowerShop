using System;

namespace FlowerShop.Models
{
    public class Flower
    {
        public int Id {get;set;}
        public string Name { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        public string Url { get; set; }
        public int InStock{get;set;}
    }
}
