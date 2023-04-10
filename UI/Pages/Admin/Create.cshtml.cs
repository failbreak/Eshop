using DataLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ServiceLayer.Service;

namespace UI.Pages.Admin
{
    public class CreateModel : PageModel
    {
        private readonly IProductService _productService;
        public CreateModel(IProductService productService) => _productService = productService;
        public List<Product> products { get; set; }
        public Product product { get; set; }

        public async void OnGet()
        {
           products = await _productService.GetProducts();
        }

        public async void OnPost()
        {

        }
    }
}
