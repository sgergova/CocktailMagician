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
