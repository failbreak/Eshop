using DataLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServiceLayer;
using ServiceLayer.Service;
using ServiceLayer.Service.Dto;
using System;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        // GET: api/Product
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            var products = await _productService.GetProducts();
            if (products == null)
            {
                return NotFound();
            }
            return Ok(products);
        }

        [HttpPost]
        public async Task<ActionResult<Product>> CreateProduct(Product product)
        {
            var vsbullshit = await _productService.Create(product);
            return vsbullshit;
        }

        // GET: api/Product/id
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProductbyid(int id)
        {
            try
            {
                var product = await _productService.GetProductById(id);

                if (product == null)
                {
                    return NotFound();
                }

                return product;
            }
            catch (Exception e)
            {
                return NotFound(e);
            }

        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var result = await _productService.DeleteProduct(id);

            if (result == null)
                return NotFound();

            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Product updateProduct)
        {
            if (id != updateProduct.ProductId)
            {
                return BadRequest();
            }

            var product = await _productService.GetProductById(id);

            if (product == null)
            {
                return NotFound();
            }

            product.Name = updateProduct.Name;
            product.Price = updateProduct.Price;
            product.CategoryId = updateProduct.CategoryId;
            product.ManufactureId = updateProduct.ManufactureId;

            await _productService.UpdateProduct(product);

            return NoContent();
        }

        [HttpGet("sortedfiltered")]
        public async Task<ActionResult<IEnumerable<Product>>> GetSortedFilteredProducts([FromQuery] SortFilterOptions options)
        {
            var products = await _productService.SortFilterPageAsync(options);

            if (!products.Any())
            {
                return NotFound();
            }

            return Ok(products);
        }

        [HttpGet("manufactures")]
        public async Task<ActionResult<IEnumerable<Manufacture>>> GetManufacturers()
        {
            var manufacturers = await _productService.GetManufacturers();
            return Ok(manufacturers);
        }
    }
}
