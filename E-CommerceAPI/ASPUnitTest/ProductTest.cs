using DomainLayer.Models;
using E_CommerceAPI.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer;
using ServiceLayer.Implementation;
using ServiceLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPUnitTest
{
    public class ProductTest
    {
        
       
        [Fact]
        public async void GetProductById_WithInValidId_ShouldReturnNull()
        {
            //Arrange
            DbContextOptionsBuilder<DbContext> optionsBuilder = new DbContextOptionsBuilder<DbContext>();
            optionsBuilder.UseInMemoryDatabase("TestDb");
            AppDbContext dbContext = new AppDbContext(optionsBuilder.Options);
            Repository<Product, int> repository = new Repository<Product, int>(dbContext);
            ProductServices productService = new  ProductServices(repository);

            Product product = new Product
            {
                Id = 1,
                Name = "Test",
                MinimumQuantity = 1,
                Image="dd",
                Price = 1,
                ProductCode = 1,    
                Category="dd",
                DiscountRate=1,
            };
            productService.Add(product);
            var id = 0;

            //Act
            var result = await productService.GetBuyId(id);

            //Assert
            Assert.Null(result);


        }
        [Fact]
        public async void GetProductById_WithValidId_ShouldReturnProduct()
        {
            //Arrange
            DbContextOptionsBuilder<DbContext> optionsBuilder = new DbContextOptionsBuilder<DbContext>();
            optionsBuilder.UseInMemoryDatabase("TestDb");
            AppDbContext dbContext = new AppDbContext(optionsBuilder.Options);
            Repository<Product, int> repository = new Repository<Product, int>(dbContext);
            ProductServices productService = new ProductServices(repository);

            Product product = new Product
            {
                Id = 1,
                Name = "Test",
                MinimumQuantity = 1,
                Image = "dd",
                Price = 1,
                ProductCode = 1,
                Category = "dd",
                DiscountRate = 1,
            };
            productService.Add(product);
           

            //Act
            var result = await productService.GetBuyId(product.Id);

            //Assert
            Assert.Equal("Test",result.Name);


        }
        [Fact]
        public async void AddProduct_withRepetedProductCode_ShouldNotCreateProduct()
        {
            //Arrange
            DbContextOptionsBuilder<DbContext> optionsBuilder = new DbContextOptionsBuilder<DbContext>();
            optionsBuilder.UseInMemoryDatabase("TestDb");
            AppDbContext dbContext = new AppDbContext(optionsBuilder.Options);
            Repository<Product, int> repository = new Repository<Product, int>(dbContext);
            ProductServices productService = new ProductServices(repository);

            Product product1 = new Product
            {
                Id = 1,
                Name = "Test",
                MinimumQuantity = 1,
                Image = "dd",
                Price = 1,
                ProductCode = 1,
                Category = "dd",
                DiscountRate = 1,
            };
            await productService.Add(product1);
            
            Product product2 = new Product
            {
                Id = 2,
                Name = "Test2",
                MinimumQuantity = 1,
                Image = "dd",
                Price = 1,
                ProductCode = 1,
                Category = "dd",
                DiscountRate = 1,
            };
            //Act
            var result = await productService.Add(product2);

            //Assert
            Assert.Null(result);
        }
    }
}
