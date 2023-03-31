using DataLayer.Entities;

namespace ServiceLayer.Service
{
    public interface IOrderService
    {
        Task CreateOrder(Customer customer);
        List<Order> GetOrders();
        Task UpdateOrder(Order order);
    }
}