using DataLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ServiceLayer.Service;
using ServiceLayer.Service.Dto;
using UI.SessionHelper;

namespace UI.Pages.Products
{
    public class BucketModel : PageModel
    {
        [BindProperty]
        public List<ProductDto> Products { get; set; }

        [BindProperty]
        public OrderDto Order { get; set; }

        public decimal? Total { get; set; } = 0;

        private readonly IProductService _productService;

        public BucketModel(IProductService productService)
        {
            _productService = productService;
        }

        public IActionResult OnGet()
        {
           ProductPicture picture = new ProductPicture();
            picture.PictureUrl = "lol";
            if (HttpContext.Session.Get("order") != null)
            {
                Order = HttpContext.Session.Get<OrderDto>("order");
                Products = Order.Products;
                foreach (ProductDto item in Products)
                {
                    item.pictures = (ICollection<ProductPicture>)picture;
                    if (item.Stack > 1)
                    {
                        Total += item.Price * item.Stack;
                    }
                    else
                    {
                        Total += item.Price;
                    }

                }
            }
            return Page();
        }

        public IActionResult OnPost()
        {
            return Page();
        }
    }
}
