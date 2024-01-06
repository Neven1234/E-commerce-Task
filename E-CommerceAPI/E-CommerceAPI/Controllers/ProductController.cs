using DomainLayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Interface;
using System.Net.Http.Headers;

namespace E_CommerceAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _product;

        public ProductController(IProductService product)
        {
            this._product = product;
        }
        [HttpGet("GatAll")]
        public async Task<IActionResult> GetAll()
        {
            var Products=await _product.GetAllProducts();
            return Ok(Products);
        }
        [HttpGet("GetProduct/{Id:int}")]
        public async Task<IActionResult> GetProduct(int Id)
        {
            var product = await _product.GetBuyId(Id);
            return Ok(product);
        }
        [HttpPost]
        public async Task<IActionResult> AddProduct(Product product)
        {
            var result = await _product.Add(product);
            if(result==null)
            {
                return Ok("Product Code must be uniqe");
            }
            return Ok("Product Added Successfully");
        }
        [HttpPut("UpdateAsync/{Id:int}")]
        public async Task<IActionResult> UpdateProduct(Product product, int Id)
        {
            await _product.UpdateAsync(product, Id);
            return Ok("Updated Successfully");
        }
        [HttpDelete("DeleteAsync/{Id:int}")]
        public async Task<IActionResult> Remove(int Id)
        {
             await _product.Delete(Id);
            return Ok("Deleted Successfully");
        }

        //upload image

        [HttpPost("ImageUpload"), DisableRequestSizeLimit]
        public async Task<IActionResult> Upload()
        {
            try
            {
                var formCollection = await Request.ReadFormAsync();
                var file = formCollection.Files.First();

                var folderName = Path.Combine("Resourcess", "images");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
                if (file.Length > 0)
                {
                    var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    var fullPath = Path.Combine(pathToSave, fileName);
                    var dbPath = Path.Combine(folderName, fileName);
                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                    return Ok(new { dbPath });
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }

    }
}
