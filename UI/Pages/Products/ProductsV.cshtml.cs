using DataLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ServiceLayer.Service;
using ServiceLayer.Service.Dto;
using ServiceLayer.Service.DtoSorts;

namespace UI.Pages.Products
{
    public class ProductsVModel : PageModel
    {
        private readonly IProductService _productService;
        private IHtmlHelper _htmlHelper;


        public ProductsVModel(IProductService produktService, IHtmlHelper htmlHelper)
        {
            _productService = produktService;
            _htmlHelper = htmlHelper;
        }

        public IEnumerable<Product> Products { get; set; }

        public SortFilterOptions SortFilterPage { get; set; }

        #region Filter
        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }
        #endregion

        #region Order
        [BindProperty(SupportsGet = true)]
        public OrderByOptions OrderBy { get; set; }

        public IEnumerable<SelectListItem> OrderByList { get; set; }
        #endregion

        #region Page
        [BindProperty(SupportsGet = true)]
        public int CurrentPage { get; set; } = 1;
        public int Count { get; set; }
        public int PageSize { get; set; } = 5;

        public int TotalPages { get; set; }
        #endregion

        public void OnGet()
        {
            SortFilterPage = new SortFilterOptions { FilterBy = ProductFilterBy.ByName, FilterValue = SearchTerm, OrderByOptions = OrderBy, PageNum = CurrentPage, PageSize = PageSize };
            Products = _productService.SortFilterPage(SortFilterPage);
            OrderByList = _htmlHelper.GetEnumSelectList<OrderByOptions>();
            TotalPages = SortFilterPage.NumPages;
        }
    }
}
