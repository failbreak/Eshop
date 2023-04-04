using DataLayer.Entities;

namespace ServiceLayer.Service
{
    public interface IProductService
    {
        /// <summary>
        ///  Adds a product
        ///  Name, Price, CategoryId, ManufacturerId
        /// </summary>
        /// <param name="Name, Price, CategoryId, ManufacturerId"> </param>
        /// <returns></returns>
        Task AddProduct(Product product);
        Task EditProduct(Product product);
        Task<List<Product>> GetProductById(int id);
        Task<List<Product>> GetProducts();
        Task RemoveProduct(int productId);
        Task<List<Product>> Search(string search);
    }
}