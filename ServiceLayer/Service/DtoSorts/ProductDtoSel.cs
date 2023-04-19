using DataLayer.Entities;
using ServiceLayer.Service.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Service.DtoSorts
{
    public static class ProductDtoSel
    {
        public static IQueryable<ProductDto> MapProduct(this IQueryable<Product> products)
        {
            return products.Select(b => new ProductDto
            {
                ProductId = b.ProductId,
                Name = b.Name,
                Price = b.Price,
                pictures = b.ProductPictures,
                CategoryId = b.CategoryId,
                Category = b.Category.Name,
                ManufactureId = b.ManufactureId,
                Manufacture = b.Manufacture.Name
            });
        }
    }
}
