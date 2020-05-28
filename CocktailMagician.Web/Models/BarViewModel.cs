using CocktailMagician.Data.Entities;
using CocktailMagician.Services.EntitiesDTO;
using CocktailMagician.Web.Models.WebPagination;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CocktailMagician.Web.Models
{
    public class BarViewModel : IPagination<BarViewModel>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public int Rating { get; set; }
        public string ImageURL { get; set; }
        public Guid CountryId { get; set; }
        public string CountryName { get; set; }
        public IFormFile Image { get; set; }
        public ICollection<BarCocktailDTO> BarCocktails { get; set; }
        public ICollection<BarRating> Stars { get; set; }
        public ICollection<BarCommentDTO> Comments { get; set; }
        public ICollection<BarViewModel> items { get;  set; }
        public int currentPage { get;  set; }
        public int TotalPages { get;  set; }

        public bool hasNext
        {
            get
            {
                return currentPage < TotalPages;
            }
        }
        public bool hasPrev
        {
            get
            {
                return currentPage > 1;
            }
        }

    }
}
