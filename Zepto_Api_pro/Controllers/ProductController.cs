using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;
using Zepto_Api_pro.DTOs;
using Zepto_Api_pro.Services.Interfaces;

namespace Zepto_Api_pro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productservice;

        public ProductController(IProductService productService)
        {
            _productservice = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var products = await _productservice.GetAllProducts();
            return Ok(products);
        }

        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> CreateProduct([FromForm] CreateProductDto dto)
        {

            await _productservice.CreateProduct(dto);
            return Ok("Product Created Sucessfuly");

        }
        [HttpPut]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Update([FromForm] UpdateProductDto dto)
        {

            await _productservice.UpdateProduct(dto);
            return Ok("Product Updated Successfully");

        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _productservice.DeleteProduct(id);
            return Ok("Deleted Successfully");

        }


        [HttpGet("category/{categoryId}")]
        public async Task<IActionResult> GetByCategory(int categoryId)
        {
            var data = await _productservice.GetProductsByCategory(categoryId);
            return Ok(data);
        }

        [HttpGet("categories")]
        public async Task<IActionResult> GetAllCategories()
        {
            var data = await _productservice.GetAllCategories();
            return Ok(data);
        }

    }
}
