using Bogus.DataSets;
using ServiceLayer.Service.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Service.DtoSorts
{
    public enum OrderByOptions
    {
        [Display(Name = "Sort by Navn ↓...")]
        ByNameAsc = 0,
        [Display(Name = "Navn ↑")]
        ByNameDesc,
        [Display(Name = "Pris ↓")]
        ByPriceDesc,
        [Display(Name = "Pris ↑")]
        ByPriceAsc
    }
    public static class ProduktDtoSort
    {
        public static IQueryable<ProductDto> OrderProductsBy(this IQueryable<ProductDto> product, OrderByOptions orderByOptions)
        {
            switch (orderByOptions)
            {
                case OrderByOptions.ByNameAsc:
                    return product.OrderBy(x => x.Name);

                case OrderByOptions.ByNameDesc:
                    return product.OrderByDescending(x => x.Name);

                case OrderByOptions.ByPriceDesc:
                    return product.OrderBy(x => x.Price);

                case OrderByOptions.ByPriceAsc:
                    return product.OrderByDescending(x => x.Price);

                default:
                    throw new ArgumentOutOfRangeException(nameof(orderByOptions), orderByOptions, null);
            }
        }
    }
}
