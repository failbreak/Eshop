using DataLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Build.Framework;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ServiceLayer.Service;

namespace UI.Pages.User
{
    public class SignupModel : PageModel
    {
        private readonly ICustomerService _customerService;
        public SignupModel(ICustomerService customerService) => _customerService = customerService;

        [BindProperty, Required]
        public string FirstName { get; set; }
        [BindProperty, Required]
        public string LastName { get; set; }
        [BindProperty, Required]
        public string Address { get; set; }
        public string Password { get; set; }
        [BindProperty, Required]
        public string Email { get; set; }
        public List<Customer> customers { get; set; }
        public async Task OnGetAsync()
        {
            if (await _customerService.GetCustomers() != null)
            {
                customers = await _customerService.GetCustomers();
            }

        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            Customer newCust = new();
            newCust.FirstName = FirstName;
            newCust.LastName = LastName;
            newCust.email = Email;
            newCust.Address = Address;
            await _customerService.CreateCustomer(newCust);
            return RedirectToRoute("index");
        }
    }
}
