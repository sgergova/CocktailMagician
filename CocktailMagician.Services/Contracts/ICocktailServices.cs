using CocktailMagician.Data.Entities;
using CocktailMagician.Services.EntitiesDTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CocktailMagician.Services.Contracts
{
    public interface ICocktailServices
    {
        Task<CocktailDTO> GetCocktail(Guid id);
        Task<ICollection<CocktailDTO>> GetAllCocktails(string name, ICollection<CocktailIngredient> ingredients, int? rating);
        Task<CocktailDTO> CreateCocktail(CocktailDTO cocktailDTO);
        Task<CocktailDTO> UpdateCocktail(Guid id, CocktailDTO cocktailDTO);
        Task<CocktailDTO> DeleteCocktail(Guid id);
        Task<CocktailDTO> RemoveIngredientFromCocktail(string cocktailName, string ingredientName);
        Task<CocktailDTO> AddIngredientToCocktail(string cocktailName, string ingredientName);
        Task<ICollection<CocktailDTO>> SearchByAlcohol(string criteria);
        int GetCount(int itemsPerPage, string searchCriteria, string type);
        Task<ICollection<CocktailDTO>> GetTopThreeCocktails();

        Task<ICollection<CocktailDTO>> GetIndexPageCocktails(string orderBy, int currentPage, string searchCriteria);

        Task<ICollection<CocktailDTO>> GetAllCocktails();
    };
}
