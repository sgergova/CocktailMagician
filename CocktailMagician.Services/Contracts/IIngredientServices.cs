using CocktailMagician.Services.EntitiesDTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CocktailMagician.Services.Contracts
{
   public interface IIngredientServices
    {
        Task<IngredientDTO> GetIngredient(Guid id);
        Task<IngredientDTO> GetIngredient(string name);
        Task<ICollection<IngredientDTO>> GetAllIngredients(string name);
        Task<IngredientDTO> CreateIngredient(IngredientDTO barDTO);
        Task<IngredientDTO> UpdateIngredient(IngredientDTO barDTO);
        Task<IngredientDTO> DeleteIngredient(Guid id);
        Task<ICollection<CocktailIngredientDTO>> SearchCocktailByIngredient(string cocktailName);
        Task<ICollection<CocktailIngredientDTO>> SearchCocktailByIngredient(Guid cocktailId);
    }
}
