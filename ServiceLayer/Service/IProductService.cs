using DataLayer.Entities;

namespace ServiceLayer.Service
{
    public interface IProductService
    {
        void EditProduct(Product product);

        /// <summary>
        /// Gets all Products
        /// </summary>
        /// <returns></returns>
        List<Product> GetProducts();
        void RemoveProduct(int productId);
    }
}