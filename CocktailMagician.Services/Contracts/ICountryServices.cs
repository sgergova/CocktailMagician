using CocktailMagician.Services.EntitiesDTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CocktailMagician.Services.Contracts
{
    public interface ICountryServices
    {
        Task<CountryDTO> CreateCountry(CountryDTO countryDTO);
        Task<CountryDTO> GetCountry(string name);
        Task<CountryDTO> GetCountry(Guid id);
        Task<ICollection<CountryDTO>> GetAllCountries();
        Task<CountryDTO> UpdateCountry(Guid id, CountryDTO countryDTO);
        Task<ICollection<BarDTO>> BarsAvailable(Guid countryId);
        Task<CountryDTO> DeleteCountry(Guid id);
        Task<CountryDTO> AddBarToCountry(Guid countryId, Guid barId);
        Task<CountryDTO> RemoveBarFromCountry(Guid countryId, Guid barId);
    }
}
