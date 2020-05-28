using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CocktailMagician.Web.Models.WebPagination
{
    public interface IPagination<T>
    {
        ICollection<T> items { get;  set; }
        int currentPage { get;  set; }
        int TotalPages { get;  set; }

        bool hasNext
        {
            get
            {
                return currentPage < TotalPages;
            }
        }
        bool hasPrev
        {
            get
            {
                return currentPage > 1;
            }
        }

    }
}
