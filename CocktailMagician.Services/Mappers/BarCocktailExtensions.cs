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
      
        public static BarCocktailDTO GetDTO(this BarCocktail barCocktail)
        {
            if (barCocktail == null)
                throw new ArgumentNullException();

            return new BarCocktailDTO
            {
                BarId = barCocktail.BarId,
                Bar = barCocktail.Bar,
                CocktailId = barCocktail.CocktailId,
                Cocktail = barCocktail.Cocktail,
                IsListed = barCocktail.IsListed,
                IsDeleted = barCocktail.IsDeleted,
                DeletedOn = barCocktail.DeletedOn,
                ListedOn = barCocktail.ListedOn,
                UnlistedOn = barCocktail.UnlistedOn,
                ModifiedOn = barCocktail.ModifiedOn
            };
        }


        public static ICollection<BarCocktailDTO> GetDTOs(this ICollection<BarCocktail> barCocktails)
        {
            return barCocktails.Select(GetDTO).ToList();
        }

        public static BarCocktail GetEntity(this BarCocktailDTO barCocktail)
        {
            if (barCocktail == null)
                throw new ArgumentNullException();

            return new BarCocktail
            {
                BarId = barCocktail.BarId,
                Bar = barCocktail.Bar,
                CocktailId = barCocktail.CocktailId,
                IsListed = barCocktail.IsListed,
                CreatedOn = barCocktail.CreatedOn
            };
        }

        public static ICollection<BarCocktail> GetEntities(this ICollection<BarCocktailDTO> barCocktails)
        {
            return barCocktails.Select(GetEntity).ToList();
        }
    }
}
