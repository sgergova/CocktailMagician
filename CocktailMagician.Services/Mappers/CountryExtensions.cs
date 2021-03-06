﻿using CocktailMagician.Data.Entities;
using CocktailMagician.Services.EntitiesDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CocktailMagician.Services.Mappers
{
  public static  class CountryExtensions
    {
        public static CountryDTO GetDTO(this Country country)
        {
            if (country == null)
                throw new ArgumentNullException("Entity not found");

            return new CountryDTO
            {
                Id = country.Id,
                Name = country.Name,
                Bars = country.Bars?.GetDTOs(),
                IsDeleted = country.IsDeleted,
                DeletedOn = country.DeletedOn,
                ModifiedOn = country.ModifiedOn
            };
        }

        public static ICollection<CountryDTO> GetDTOs(this ICollection<Country> entities)
        {
            return entities.Select(GetDTO).ToList();
        }

        public static Country GetEntity(this CountryDTO country)
        {
            if (country == null)
                throw new ArgumentNullException("Entity not found");

            return new Country
            {
                Id = country.Id,
                Name = country.Name,
                Bars = country.Bars?.GetEntities(),
                IsDeleted = country.IsDeleted,
                DeletedOn = country.DeletedOn,
                ModifiedOn = country.ModifiedOn
            };
        }

        public static ICollection<Country> GetEntities(this ICollection<CountryDTO> entities)
        {
            return entities.Select(GetEntity).ToList();
        }
    }
}
