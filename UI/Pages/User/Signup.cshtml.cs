using DataLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ServiceLayer.Service;

namespace UI.Pages.User
{
    public class SignupModel : PageModel
    {
        private readonly CustomerService _customerService;
        public SignupModel(CustomerService customerService) => _customerService = customerService;


        public Product Product { get; set; }
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            
        }
    }
}
