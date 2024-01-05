using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Dto
{
    public class ProductDTO
    {
        public int ProductCode { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public string Category { get; set; }
        public string Image { get; set; }
        public int MinimumQuantity { get; set; }
        public int DiscountRate { get; set; }
    }
}
