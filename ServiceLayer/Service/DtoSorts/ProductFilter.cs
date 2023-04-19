using Bogus.DataSets;
using Microsoft.EntityFrameworkCore;
using ServiceLayer.Service.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Service.DtoSorts
{
    public enum ProductFilterBy
    {
        [Display(Name = "All")]
        NoFilter = 0,
        [Display(Name = "By Name...")]
        ByName,
        [Display(Name = "By Price...")]
        ByPrice
    }
    public static class ProduktDtoFilter
    {
        public static IQueryable<ProductDto> FilterProductsBy(this IQueryable<ProductDto> produkter, ProductFilterBy filterBy, string filterValue)
        {
            if (string.IsNullOrEmpty(filterValue))
                return produkter;

            switch (filterBy)
            {
                case ProductFilterBy.NoFilter:
                    return produkter;

                case ProductFilterBy.ByName:
                    return produkter.Where(x => EF.Functions.Like(x.Name, $"%{filterValue}%"));

                case ProductFilterBy.ByPrice:
                    return produkter.Where(x => x.Price <= int.Parse(filterValue));

                default:
                    throw new ArgumentOutOfRangeException(nameof(filterBy), filterBy, null);
            }
        }
    }
}
