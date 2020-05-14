using CocktailMagician.Data.Entities;
using CocktailMagician.Services.EntitiesDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CocktailMagician.Services.Mappers
{
    public static class BarCocktailExtensions
    {
        //{
        //    public Guid BarId { get; set; }
        //    public Bar Bar { get; set; }
        //    public Guid CocktailId { get; set; }
        //    public Cocktail Cocktail { get; set; }
        //    public bool IsListed { get; set; }
        //    public DateTime ListedOn { get; set; }
        //    public DateTime UnlistedOn { get; set; }
        public static BarCocktailDTO GetDTO(this BarCocktail barCocktail)
        {
            if (barCocktail == null)
                throw new ArgumentNullException();

            return new BarCocktailDTO
            {
                BarId = barCocktail.BarId,
                Bar = barCocktail.Bar,
                CocktailId = barCocktail.CocktailId,
                IsListed = barCocktail.IsListed,
                IsDeleted = barCocktail.IsDeleted
            };
        }


        public static ICollection<BarCocktailDTO> GetDTOs(this ICollection<BarCocktail> barCocktails)
        {
            return barCocktails.Select(GetDTO).ToList();
        }
        public static BarCocktail GetEntity(this BarCocktailDTO barCocktailDTO)
        {
            if (barCocktailDTO == null)
                throw new ArgumentNullException();

            return new BarCocktail
            {
                BarId = barCocktailDTO.BarId,
                Bar = barCocktailDTO.Bar,
                CocktailId = barCocktailDTO.CocktailId,
                IsListed = barCocktailDTO.IsListed,
                IsDeleted = barCocktailDTO.IsDeleted
            };
        }

        public static ICollection<BarCocktail> GetEntities(this ICollection<BarCocktailDTO> barCocktailDTOs)
        {
            return barCocktailDTOs.Select(GetEntity).ToList();
        }
    }
}
