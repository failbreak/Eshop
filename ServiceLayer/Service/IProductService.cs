using DataLayer.Entities;

namespace ServiceLayer.Service
{
    public interface IProductService
    {
        /// <summary>
        /// Gets all Products
        /// </summary>
        /// <returns></returns>
        List<Product> GetProducts();
    }
}