﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Service.DtoSorts
{
    public class SortFilterOptions
    {
        #region ORDERING
        public OrderByOptions OrderByOptions { get; set; }
        #endregion

        #region FILTERING
        public ProductFilterBy FilterBy { get; set; }
        public string FilterValue { get; set; }
        #endregion

        #region PAGING
        public const int DefaultPageSize = 10;   //default page size is 10

        public int PageNum { get; set; }

        public int PageSize { get; set; } = DefaultPageSize;

        public int NumPages { get; private set; }

        public void SetupProduct<T>(IQueryable<T> query)
        {
            NumPages = (int)Math.Ceiling((double)query.Count() / PageSize);
            PageNum = Math.Min(Math.Max(1, PageNum), NumPages);
        }
        #endregion
    }
}
