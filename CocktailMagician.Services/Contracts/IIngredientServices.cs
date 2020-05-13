﻿using CocktailMagician.Services.EntitiesDTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CocktailMagician.Services.Contracts
{
   public interface IIngredientServices
    {
        Task<IngredientDTO> GetIngredient(Guid id);
        Task<ICollection<IngredientDTO>> GetAllIngredients();
        Task<IngredientDTO> CreateIngredient(IngredientDTO barDTO);
        Task<IngredientDTO> UpdateIngredient(IngredientDTO barDTO);
        Task<IngredientDTO> DeleteIngredient(Guid id);
    }
}