using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ServiceLayer.Service;
using ServiceLayer.Service.Dto;
using UI.SessionHelper;

namespace UI.Pages.Products
{
    public class ProductInfoModel : PageModel
    {
        [BindProperty]
        public ProductDto Product { get; set; }

        [BindProperty]
        public OrderDto Order { get; set; }

        private readonly IProductService _productService;

        public ProductInfoModel(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IActionResult> OnGetAsync(int? productId)
        {
            if (productId != null)
            {
                Product = _productService.GetProductById(productId.Value);
            }

            if (Product == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int productId)
        {
            Product = _productService.GetProductById(productId);

            if (HttpContext.Session.Get("order") != null)
            {
                Order = HttpContext.Session.Get<OrderDto>("order");
                ProductDto order = Order.Products.Find(p => p.ProductId == productId);
                if (order != null)
                {
                    order.Stack += 1;
                }
                else
                {
                    ProductDto product = new ProductDto { ProductId = Product.ProductId, Name = Product.Name, Price = Product.Price, Stack = 1 };
                    Order.Products.Add(product);
                }
                HttpContext.Session.Set("order", Order);
            }
            else
            {
                ProductDto product = new ProductDto { ProductId = Product.ProductId, Name = Product.Name, Price = Product.Price, Stack = 1 };
                Order.Products.Add(product);

                HttpContext.Session.Set("order", Order);
            }
            if (Product == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
