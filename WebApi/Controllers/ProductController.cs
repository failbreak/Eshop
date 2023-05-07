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
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetProducts()
        {
            return _productService.GetProducts().ToList();
        }

        [HttpPost]
        public async Task<ActionResult<ProductDto>> CreateProduct(ProductDto productDTO)
        {
            return _productService.Create(productDTO);
        }

        // GET: api/Produkt/id
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> GetProduct(int id)
        {
            try
            {
                ProductDto product = _productService.GetProductById(id);

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
        public async Task<IActionResult> EditProduct(int id, ProductDto productDTO)
        {

            try
            {
                if (id != productDTO.ProductId)
                {
                    return BadRequest();
                }

                ProductDto product = _productService.GetProductById(id);
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
