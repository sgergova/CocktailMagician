using CocktailMagician.Data.Entities;
using CocktailMagician.Services.EntitiesDTO;
using System;
using System.Collections.Generic;
using System.Linq;
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
        Task<IngredientDTO> UpdateIngredient(Guid id, IngredientDTO ingredientDTO);
        Task<IngredientDTO> DeleteIngredient(Guid id);
        Task<ICollection<CocktailIngredientDTO>> GetCocktailIngredients(Guid cocktailId);
        Task<ICollection<CocktailIngredientDTO>> AvailabilityAtCocktails(Guid ingredientId);
        Task<ICollection<IngredientDTO>> GetIndexPageIngredients(string orderBy, int currentPage, string searchCriteria);
        int GetCount(int itemsPerPage, string searchCriteria);
       
    }
}
