using DataLayer.Entities;
using ServiceLayer.Service.Dto;
using ServiceLayer.Service.DtoSorts;

namespace ServiceLayer.Service
{
    public interface IProductService
    {
        IQueryable<ProductDto> AddProduct();
        ProductDto Create(ProductDto newProdukt);
        ProductDto Delete(int productId);
        IQueryable<Category> GetCategories();
        IQueryable<Manufacture> GetManufactuers();
        IQueryable<ProductDto> GetProducts();
        ProductDto GetProductById(int productId);
        IQueryable<ProductDto> SortFilterPage(SortFilterOptions options);
        ProductDto Update(ProductDto updateProduct);
    }
}