using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Dtos
{
    public class ProductDto
    {
        
        public int Code { get; set; }
        
        public string Title { get; set; }
        
        public string Description { get; set; }
        
        public int Stoke { get; set; }
       
        public decimal Price { get; set; }
        
        public string Image { get; set; }
        public int? CustomerId { get; set; }
    }
}
