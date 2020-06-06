using CocktailMagician.Data.Entities;
using CocktailMagician.Services.EntitiesDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CocktailMagician.Services.Contracts
{
    public interface IBarServices
    {
        Task<BarDTO> GetBar(Guid id);
        Task<BarDTO> GetBar(string barName);
        Task<ICollection<BarDTO>> GetAllBars(string search);
        Task<BarDTO> CreateBar(BarDTO barDTO);
        Task<BarDTO> UpdateBar(Guid id, BarDTO barDTO);
        Task<ICollection<BarCocktailDTO>> AvailabilityAtBar(Guid barToDeleteId);
        Task<BarDTO> DeleteBar(Guid id);
        Task<BarDTO> AddCocktailToBar(Guid barId, string cocktailName);
        Task<BarDTO> AddCocktailsToBar(string barName, ICollection<string> cocktailNames);
        Task<BarDTO> RemoveCocktailFromBar(Guid barId, Guid cocktailId);
        Task<BarDTO> RemoveCocktailFromBar(Guid barCocktailId);
        Task<ICollection<BarDTO>> GetIndexPageBars(int currentPage, string searchCriteria);
        int GetCount(int itemsPerPage);
        Task<ICollection<BarDTO>> GetTopThreeBars();
        Task<ICollection<BarCocktailDTO>> GetCocktailsForBar(Guid barId);


    }
}
