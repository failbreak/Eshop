using DataLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ServiceLayer.Service;

namespace UI.Pages.User
{
    public class SignupModel : PageModel
    {
        private readonly ICustomerService _customerService;
        public SignupModel(ICustomerService customerService) => _customerService = customerService;

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Password { get; set; }
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
            Customer newCust = new Customer();
            newCust.FirstName = FirstName;
            newCust.LastName = LastName;
            newCust.email = Email;
            newCust.Address = Address;
            await _customerService.CreateCustomer(newCust);
            return RedirectToRoute("index");
        }
    }
}
