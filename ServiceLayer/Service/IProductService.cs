using DataLayer.Entities;

namespace ServiceLayer.Service
{
    public interface IProductService
    {
        IQueryable<Product> AddProduct();
        Task<Product> Create(Product newProdukt);
        Task<Product> DeleteProduct(int productId);
        IQueryable<Category> GetCategories();
        IQueryable<Manufacture> GetManufactuers();
        Task<Product> GetProductById(int productId);
        Task<Product> GetProducts();
        IQueryable<Product> SortFilterPage(SortFilterOptions options);
        Task<Product> Update(Product updateProduct);
    }
}