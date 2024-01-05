using DomainLayer.Models;
using RepositoryLayer;
using ServiceLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Implementation
{
    public class ProductServices : IProductService
    {
        private readonly IRepository<Product, int> _repository;

        public ProductServices(IRepository<Product, int> repository)
        {
            this._repository = repository;
        }
        public async Task<Product> Add(Product product)
        {
            var NewProduct = await _repository.Add(product);
            return NewProduct;
        }

        public async Task<string> Delete(int Id)
        {
          await _repository.DeleteAsync(Id);
            return "Deleted Sccessfully";
        }

        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            var AllProducts = await _repository.GetAll();
            return AllProducts;
        }

        public async Task<Product> GetBuyId(int id)
        {
            var product=await _repository.GetById(id);
            return product;
        }

        public async Task UpdateAsync(Product product, int Id)
        {
            await _repository.Update((p) =>
            {
                p.Name = product.Name;
                p.MinimumQuantity = product.MinimumQuantity;
                p.Price = product.Price;
                p.ProductCode = product.ProductCode;
                p.Category = product.Category;
                p.DiscountRate = product.DiscountRate;
                p.Image = product.Image;
            }, Id);
          
        }
    }
}
