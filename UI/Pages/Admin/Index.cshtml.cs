using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ServiceLayer.Service;
using ServiceLayer.Service.Dto;

namespace UI.Pages.Admin
{
    public class IndexModel : PageModel
    {
        public IEnumerable<ProductDto> Products { get; set; }

        private readonly IProductService _productService;


        public IndexModel(IProductService productService)
        {
            _productService = productService;

        }
        public void OnGet()
        {
            Products = (IEnumerable<ProductDto>)_productService.GetProducts().ToList();
        }
    }
}
