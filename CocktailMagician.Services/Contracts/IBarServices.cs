using CocktailMagician.Services.EntitiesDTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CocktailMagician.Services.Contracts
{
    public interface IBarServices
    {
        Task<BarDTO> GetBar(Guid id);
        Task<BarDTO> GetBar(string barName);
        Task<ICollection<BarDTO>> GetAllBars(string name, int? rating, string address, string country);
        Task<BarDTO> CreateBar(BarDTO barDTO);
        Task<BarDTO> UpdateBar(Guid id, BarDTO barDTO);
        Task<ICollection<BarCocktailDTO>> AvailabilityAtBar(Guid barToDeleteId);
        Task<bool> DeleteBar(Guid id);
        Task<BarDTO> AddCocktailToBar(Guid barId, CocktailDTO cocktail);
        Task<BarDTO> RemoveCocktailFromBar(Guid barId, Guid cocktailId);
        Task<BarDTO> RemoveCocktailFromBar(Guid barCocktailId);
        Task<ICollection<BarDTO>> GetIndexPageBeers(string orderBy, int currentPage);
        Task<ICollection<BarDTO>> GetAdminIndexPageBeers(string orderBy, int currentPage);
        int GetTotalPages(int itemsPerPage, string searchCriteria, string type);
    }
}
