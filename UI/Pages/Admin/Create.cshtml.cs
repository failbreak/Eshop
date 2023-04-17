using DataLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Build.Framework;
using ServiceLayer.Service;

namespace UI.Pages.Admin
{
    public class CreateModel : PageModel
    {
        private readonly IProductService _productService;
        public CreateModel(IProductService productService) => _productService = productService;
        public List<Product> products { get; set; }
        public Product? product { get; set; }

        public async void OnGet()
        {
            products = await _productService.GetProducts();
        }

        public async Task<IActionResult> AddOnPost(string name, decimal price, int catId, int manId)
        {
            product.Name = name;
            product.Price = price;
            product.CategoryId = catId;
            product.ManufactureId = manId;

            await _productService.AddProduct(product);
            return Page();
        }
    }
}
