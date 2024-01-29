using DataLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer;
using ServiceLayer.Service;
using ServiceLayer.Service.Dto;

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

        // GET: api/Produkt
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            return _productService.GetProducts().ToList();
        }

        [HttpPost]
        public async Task<ActionResult<Product>> CreateProduct(Product productDTO)
        {
            return await _productService.Create(productDTO);
        }

        // GET: api/Produkt/id
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            try
            {
                Product product = (Product)_productService.GetProductById(id);

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

        [HttpPut("{id}")]
        public async Task<IActionResult> EditProduct(int id, Product productDTO)
        {

            try
            {
                if (id != productDTO.ProductId)
                {
                    return BadRequest();
                }

                Product product = (Product)_productService.GetProductById(id);
                if (product == null)
                {
                    return NotFound();
                }
                return Ok(_productService.Update(productDTO));
                
            }
            catch
            {
                return NotFound();
            }
        }

    }
}
