﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CocktailMagician.Web.Models.WebPagination
{
    public class Pagination<T> where T : class
    {
        public ICollection<T> items { get; set; }
        public int currentPage { get; set; }
        public int TotalPages { get; set; }
        public bool hasNext => currentPage < TotalPages;
        public bool hasPrev => currentPage > 1;

    }
}
