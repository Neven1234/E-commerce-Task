using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models
{
    public class Product:BaseEntity<int>
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
