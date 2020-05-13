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
        Task<ICollection<BarDTO>> GetAllBars();
        Task<BarDTO> CreateBar(BarDTO barDTO);
        Task<BarDTO> UpdateBar(BarDTO barDTO);
        Task<BarDTO> DeleteBar(Guid id);

    }
}
