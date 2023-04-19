﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
    public class Page<T>
    {
        public List<T> Items { get; set; }
        public int Total { get; set; }
        public int CurrentPage { get; set; } = 1;
        public int PageSize { get; set; } = 3;
        public int PageCount => (int)Math.Ceiling(decimal.Divide(Total, PageSize));
    }
}
