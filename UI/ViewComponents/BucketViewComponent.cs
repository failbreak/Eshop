using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Service;
using Microsoft.AspNetCore.Http;
using ServiceLayer.Service.Dto;
using UI.SessionHelper;

namespace UI.ViewComponents
{
    public class BucketViewComponent : ViewComponent
    {
        private readonly IProductService _productService;
        public OrderDto Order { get; set; }

        public BucketViewComponent(IProductService productService)
        {
            _productService = productService;
        }

        public IViewComponentResult Invoke()
        {
            if (HttpContext.Session.Get("order") != null)
            {
                Order = HttpContext.Session.Get<OrderDto>("order");
                return View(Order.Products.Count());
            }
            return View(0);
        }
    }
}
