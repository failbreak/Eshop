using DataLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ServiceLayer.Service;
using ServiceLayer.Service.Dto;

namespace UI.Pages.Admin
{
    public class EditModel : PageModel
    {
        [BindProperty]
        public Product Product { get; set; }

        public IEnumerable<SelectListItem> Categories { get; set; }
        public IEnumerable<SelectListItem> Manufactures { get; set; }

        private readonly IProductService _productService;

        ILogger<EditModel> logger;

        public EditModel(IProductService productService, ILogger<EditModel> logger)
        {
            _productService = productService;
            this.logger = logger;
        }

        public async Task<IActionResult> OnGetAsync(int? productid)
        {
            Categories = _productService.GetCategories().Select(
                categoryname => new SelectListItem
                {
                    Value = categoryname.CategoryId.ToString(),
                    Text = categoryname.Name
                }).ToList();

            Manufactures = _productService.GetManufactuers().Select(
                Manufacturename => new SelectListItem
                {
                    Value = Manufacturename.ManufactureId.ToString(),
                    Text = Manufacturename.Name
                }).ToList();

            if (productid != null)
            {
                Product = (Product)_productService.GetProductById(productid.Value);
            }

            if (Product == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            Categories = _productService.GetCategories().Select(
                categoryname => new SelectListItem
                {
                    Value = categoryname.CategoryId.ToString(),
                    Text = categoryname.Name
                }).ToList();

            Manufactures = _productService.GetManufactuers().Select(
                Manufacturename => new SelectListItem
                {
                    Value = Manufacturename.ManufactureId.ToString(),
                    Text = Manufacturename.Name
                }).ToList();

            //if (!ModelState.IsValid)
            //{
            //    return Page();
            //}

            try
            {
                _productService.Update(Product);
                logger.LogDebug("Produkt er blevet updatetet");
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error");
                return Page();
            }
            return RedirectToPage("./Index");
        }
    }
}
