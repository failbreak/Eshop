using DataLayer.Entities;

namespace ServiceLayer.Service
{
    public interface IProductService
    {
        Task<int> AddProduct(Product product);
        Task<Product> Create(Product newProdukt);
        Task<Product> DeleteProduct(int productId);
        Task<List<Category>> GetCategories();
        Task<List<Manufacture>> GetManufacturers();
        Task<Product> GetProductById(int productId);
        Task<IEnumerable<Product>> GetProducts();
        Task<IEnumerable<Product>> SortFilterPageAsync(SortFilterOptions options);
        Task<bool> UpdateProduct(Product product);
    }
}