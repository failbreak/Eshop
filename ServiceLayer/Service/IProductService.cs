using DataLayer.Entities;

namespace ServiceLayer.Service
{
    public interface IProductService
    {
        void AddProduct(Product product);
        void EditProduct(Product product);
        List<Product> GetProductById(int id);
        List<Product> GetProducts();
        void RemoveProduct(int productId);
        List<Product> Search(string search);
    }
}