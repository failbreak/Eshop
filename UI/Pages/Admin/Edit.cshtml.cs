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
        public async void OnGet(int id)
        {
            products = await _productService.GetProductById(id);
        }
    }
}
