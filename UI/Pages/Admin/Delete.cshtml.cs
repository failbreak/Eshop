using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ServiceLayer.Service;
using ServiceLayer.Service.Dto;

namespace UI.Pages.Admin
{
    public class DeleteModel : PageModel
    {
        [BindProperty]
        public ProductDto Product { get; set; }

        private readonly IProductService _productService;

        ILogger<DeleteModel> logger;

        public DeleteModel(IProductService produktService, ILogger<DeleteModel> logger)
        {
            _productService = produktService;
            this.logger = logger;
        }

        public async Task<IActionResult> OnGetAsync(int productId)
        {
            Product = _productService.GetProductById(productId);
            if (Product == null)
            {
                return RedirectToPage("./Index");
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int productId)
        {
            try
            {
                _productService.Delete(productId);
                logger.LogDebug("Product Deleted");
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error");
                return Page();
            }
            return RedirectToPage("./Index");
        }
}
