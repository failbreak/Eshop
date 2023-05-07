using DataLayer.Entities;
using ServiceLayer.Service.DtoSorts;

namespace ServiceLayer.Service
{
    public interface IProductService
    {
        IQueryable<Product> AddProduct();
        Task<Product> Create(Product newProdukt);
        Task<Product> DeleteProduct(int productId);
        IQueryable<Category> GetCategories();
        IQueryable<Manufacture> GetManufactuers();
        IQueryable<Product> GetProductById(int productId);
        IQueryable<Product> GetProducts();
        IQueryable<Product> SortFilterPage(SortFilterOptions options);
        Task<Product> Update(Product updateProduct);
    }
}