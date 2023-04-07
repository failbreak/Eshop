using DataLayer.Entities;

namespace ServiceLayer.Service
{
    public interface ICustomerService
    {
        Task CreateCustomer(Customer customer);
        void DeleteCustomer(int CustomerId);
        void EditCustomer(Customer Customer);
        Task<List<Customer>> GetCustomers();
        List<Customer> GetProductById(int CustomerId);
    }
}