using DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Interface
{
    public interface IProductService
    {
        public Task<Product> Add(Product product);
        public Task UpdateAsync(Product product, int Id);
        public Task <string> Delete(int Id);
        public Task<IEnumerable<Product>> GetAllProducts();
        public Task<Product> GetBuyId(int id);
    }
}
