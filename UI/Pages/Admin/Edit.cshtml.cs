using DataLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ServiceLayer.Service;

namespace UI.Pages.Admin
{
    public class EditModel : PageModel
    {
        private readonly IProductService _productService;
        public EditModel(IProductService productService) => _productService = productService;
        public List<Product> products { get; set; }
        public Product product { get; set; }
        public async Task OnGet()
        {
            products = _productService.GetProducts().Result;
        }
        public async Task<IActionResult> DeleteOnPost(int id)
        {
            await _productService.RemoveProduct(id);
            return Page();
        }        
        public async Task<IActionResult> EditOnPost(int id, string name, decimal price, bool delete, int catId, int manId)
        {
            
            product = _productService.GetProductById(id).Result;
            product.Name = name;
            product.Price = price;
            product.ManufactureId = manId;
            product.CategoryId = catId;
            product.IsDeleted = delete;

            await _productService.EditProduct(product);
            return Page();
        }
    }
}
