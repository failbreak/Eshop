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
        ServiceLayer.Page<Product> GetPaging(int page, int count, string? search = null, int? categoryId = null, int[]? manufacturerIds = null, OrderByEnum? orderBy = OrderByEnum.NameAsc);
        Task<Product> GetProductById(int id);
        Task<List<Product>> GetProducts();
        Task RemoveProduct(int productId);
        Task<List<Product>> Search(string search);
    }
}