using DomainLayer.Models;
using E_CommerceAPI.Controllers;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
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
        private readonly ProductController _controller;
        private readonly IProductService _productService;

        public ProductTest(ProductController controller,IProductService productService)
        {
            this._controller = controller;
            this._productService = productService;
        }
      
    }
}
