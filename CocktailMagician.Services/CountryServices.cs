using CocktailMagician.Data.Entities;
using CocktailMagician.DataBase.AppContext;
using CocktailMagician.Services.Contracts;
using CocktailMagician.Services.EntitiesDTO;
using CocktailMagician.Services.Mappers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace CocktailMagician.Services
{
    public class CountryServices : ICountryServices
    {
        private readonly CMContext context;

        public CountryServices(CMContext context)
        {
            this.context = context;
        }

        public async Task<CountryDTO> CreateCountry(CountryDTO countryDTO)
        {
            if (this.context.Countries.Any(c => c.Name == countryDTO.Name))
                throw new InvalidOperationException("The name of the country must be unique!");

            if (countryDTO.Name == null)
                throw new ArgumentNullException("The name of the country is mandatory!");

            var country = new Country
            {
                Name = countryDTO.Name,
                Bars = countryDTO.Bars.GetEntities(),
                CreatedOn = DateTime.UtcNow,
            };

            await this.context.Countries.AddAsync(country);
            await this.context.SaveChangesAsync();

            return country.GetDTO();

        }

        public async Task<CountryDTO> GetCountry(string name)
        {
            var country = await this.context.Countries
                                           .Where(c => c.IsDeleted == false)
                                           .FirstOrDefaultAsync(c => c.Name == name)
                                           ?? throw new ArgumentNullException("Country was not found");


            return country.GetDTO();
        }

        public async Task<CountryDTO> GetCountry(Guid id)
        {
            var country = await this.context.Countries
                                           .Where(c => c.IsDeleted == false)
                                           .FirstOrDefaultAsync(c => c.Id == id)
                                           ?? throw new ArgumentNullException("Country was not found");


            return country.GetDTO();
        }

        public async Task<ICollection<CountryDTO>> GetAllCountries(string name)
        {
            var countries = this.context.Countries
                                        .Where(c => c.IsDeleted == false).AsQueryable();


            if (name != null)
            {
                countries = countries.Where(c => c.Name.ToLower().Contains(name.ToLower()))
                                        ?? throw new ArgumentNullException("Country was not found");
            }

            var countriesToReturn = await countries.ToListAsync();

            return countriesToReturn.GetDTOs();
        }

        public async Task<CountryDTO> UpdateCountry(Guid id, CountryDTO countryDTO)
        {
            var countryToUpdate = await this.context.Countries.Where(c => c.IsDeleted == false)
                                               .FirstOrDefaultAsync(c => c.Id == id);

            countryToUpdate.Name = countryDTO.Name;
            countryToUpdate.ModifiedOn = countryDTO.ModifiedOn;

            this.context.Countries.Update(countryToUpdate);
            await this.context.SaveChangesAsync();

            return countryToUpdate.GetDTO();
        }

        public async Task<CountryDTO> DeleteCountry(Guid id)
        {
            var countryToDelete = this.context.Countries.Find(id);

            if (countryToDelete.Bars.Count != 0)
            {
                countryToDelete.IsDeleted = true;
                countryToDelete.DeletedOn = DateTime.UtcNow;

                this.context.Countries.Update(countryToDelete);
                await this.context.SaveChangesAsync();
            }
            else
            {
                throw new InvalidOperationException($"Cannot delete {countryToDelete} because there are active bars.");
            }
            

            return countryToDelete.GetDTO();
        }


        public async Task<CountryDTO> AddBarToCountry(Guid countryId, Guid barId)
        {
            var country = await this.context.Countries
                                            .Where(c => c.IsDeleted == false)
                                            .FirstOrDefaultAsync(c => c.Id == countryId);

            var bar = await this.context.Bars
                                   .Include(b => b.CountryId)
                                   .FirstOrDefaultAsync(c => c.Id == barId);

            if (bar.CountryId == countryId)
                throw new InvalidOperationException("This bar is already existing in this country.");

            country.Bars.Add(bar);
            bar.Country = country;
            bar.CountryId = countryId;

            this.context.Bars.Update(bar);
            this.context.Countries.Update(country);
            await this.context.SaveChangesAsync();

            return country.GetDTO();

        }


        //TODO Fix the issue 
        public async Task<CountryDTO> RemoveBarFromCountry(Guid countryId, Guid barId)
        {
            var country = await this.context.Countries
                                            .Where(c => c.IsDeleted == false)
                                            .FirstOrDefaultAsync(c => c.Id == countryId);

            var bar = await this.context.Bars
                                   .Include(b => b.CountryId)
                                   .FirstOrDefaultAsync(c => c.Id == barId);

            if (bar.CountryId == countryId)
            {
                country.Bars.Remove(bar);

                this.context.Countries.Update(country);
                await this.context.SaveChangesAsync();
            }
            else
            {
                throw new InvalidOperationException("The bar or/and the country was not found!"); 
            }


            return country.GetDTO();

        }

    }
}
