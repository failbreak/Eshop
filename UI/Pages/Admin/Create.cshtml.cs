using DataLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Build.Framework;
using ServiceLayer.Service;
using ServiceLayer.Service.Dto;

namespace UI.Pages.Admin
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        public ProductDto Product { get; set; }
        public IEnumerable<SelectListItem> Categories { get; set; }
        public IEnumerable<SelectListItem> Manufactures { get; set; }

        ILogger<CreateModel> logger;

        private readonly IProductService _productService;
        public CreateModel(IProductService produktService, ILogger<CreateModel> logger)
        {
            _productService = produktService;
            this.logger = logger;
        }

        public IActionResult OnGet()
        {
            Categories = _productService.GetCategories().Select(
                    kategorinavn => new SelectListItem
                    {
                        Value = kategorinavn.CategoryId.ToString(),
                        Text = kategorinavn.Name
                    }).ToList();



            Manufactures = _productService.GetManufactuers().Select(
               ManufactureName => new SelectListItem
               {
                   Value = ManufactureName.ManufactureId.ToString(),
                   Text = ManufactureName.Name
               }).ToList();
            return Page();
        }


        public async Task<IActionResult> OnPostAsync()
        {
            Categories = _productService.GetCategories().Select(
                CategoryName => new SelectListItem
                {
                    Value = CategoryName.CategoryId.ToString(),
                    Text = CategoryName.Name
                }).ToList();

            Manufactures = _productService.GetManufactuers().Select(
                ManufactureName => new SelectListItem
                {
                    Value = ManufactureName.ManufactureId.ToString(),
                    Text = ManufactureName.Name
                }).ToList();
            if (!ModelState.IsValid)
            {
                return Page();
            }
            try
            {
                _productService.Create(Product);
                logger.LogDebug("Product created");
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error");
                return Page();
            }


            return RedirectToPage("./AdminIndex");
        }
    }
}
