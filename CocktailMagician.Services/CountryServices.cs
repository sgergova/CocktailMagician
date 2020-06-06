using CocktailMagician.Data.Entities;
using CocktailMagician.Data.AppContext;
using CocktailMagician.Services.CommonMessages;
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
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }
        /// <summary>
        /// Adds new country to the database after checking if it does not exists already.
        /// </summary>
        /// <param name="countryDTO">This is the newly created ingredient object</param>
        /// <returns>CountryDTO</returns>
        public async Task<CountryDTO> CreateCountry(CountryDTO countryDTO)
        {
            if (this.context.Countries.Any(c => c.Name == countryDTO.Name))
                throw new InvalidOperationException(Exceptions.NameExists);

            if (countryDTO.Name == null)
                throw new ArgumentNullException(Exceptions.MissingName);

            var country = countryDTO.GetEntity();

            await this.context.Countries.AddAsync(country);
            await this.context.SaveChangesAsync();

            return country.GetDTO();
        }
        /// <summary>
        /// Checks by given name if country is available in the database.
        /// </summary>
        /// <param name="name">Name of the country that should be found</param>
        /// <returns>CountryDTO</returns>
        public async Task<CountryDTO> GetCountry(string name)
        {
            var country = await GetCountriesQuerable()
                                           .FirstOrDefaultAsync(c => c.Name == name)
                                           ?? throw new ArgumentNullException(Exceptions.EntityNotFound);

            return country.GetDTO();
        }
        /// <summary>
        /// Checks by given id if country is available in the database.
        /// </summary>
        /// <param id="id">Name of the country that should be found</param>
        /// <returns>CountryDTO</returns>
        public async Task<CountryDTO> GetCountry(Guid id)
        {
            var country = await GetCountriesQuerable()
                                           .FirstOrDefaultAsync(c => c.Id == id)
                                           ?? throw new ArgumentNullException(Exceptions.EntityNotFound);

            return country.GetDTO();
        }
        /// <summary>
        /// Checks by given name if country is available in the database.
        /// </summary>
        /// <returns>List of CountryDTO</returns>
        public async Task<ICollection<CountryDTO>> GetAllCountries()
        {
            var countries = await GetCountriesQuerable()
                                              .ToListAsync();

            return countries.GetDTOs();
        }
        /// <summary>
        /// Checks in the database if given country is available and if it exists updates it with given one.
        /// If the param is not valid throws exception. 
        /// </summary>
        /// <param name="id">The ID of the country that should be updated</param>
        /// <param name="countryDTO">The updates that should be done</param>
        /// <returns>The updated CountryDTO</returns>
        public async Task<CountryDTO> UpdateCountry(Guid id, CountryDTO countryDTO)
        {
            var countryToUpdate = await GetCountriesQuerable()
                                               .FirstOrDefaultAsync(c => c.Id == id)
                                               ?? throw new ArgumentNullException(Exceptions.NullEntityId);

            countryToUpdate.Name = countryDTO.Name;
            countryToUpdate.ModifiedOn = countryDTO.ModifiedOn;

            this.context.Countries.Update(countryToUpdate);
            await this.context.SaveChangesAsync();

            return countryToUpdate.GetDTO();
        }
        /// <summary>
        /// Checks by given ID in the database if it's is available and if it exists delete it.
        /// If ID is not valid throws exception. 
        /// </summary>
        /// <param name="id">The ID of the country that should be deleted</param>
        /// <returns>CountryDTO</returns>
        public async Task<CountryDTO> DeleteCountry(Guid id)
        {
            var countryToDelete = await GetCountriesQuerable()
                                               .FirstOrDefaultAsync(c => c.Id == id)
                                               ?? throw new ArgumentNullException(Exceptions.NullEntityId);

            var barsAvailable = (await BarsAvailableEntities(countryToDelete.Id)).ToList();

            countryToDelete.IsDeleted = true;
            countryToDelete.DeletedOn = DateTime.UtcNow;

            if (barsAvailable.Count != 0)
                barsAvailable.ForEach(ba => { ba.IsDeleted = true; ba.DeletedOn = DateTime.UtcNow; });

            context.Countries.Update(countryToDelete);
            await context.SaveChangesAsync();

            return countryToDelete.GetDTO();
        }
        /// <summary>
        /// Checks by given Id of country how many bars are available in the current country.
        /// </summary>
        /// <param name="countryId">Id of the country</param>
        /// <returns>ICollection of the available bars in that country</returns>
        public async Task<ICollection<BarDTO>> BarsAvailable(Guid countryId)
        {
            var bars = await BarsAvailableEntities(countryId);

            return bars.GetDTOs();
        }
        /// <summary>
        /// Adds given bar to certain country.
        /// </summary>
        /// <param name="countryId">Id of the country</param>
        /// <param name="barId">Id of the bar</param>
        /// <returns>CountryDTO</returns>
        public async Task<CountryDTO> AddBarToCountry(Guid countryId, Guid barId)
        {
            var country = await GetCountriesQuerable()
                                            .FirstOrDefaultAsync(c => c.Id == countryId)
                                            ?? throw new ArgumentNullException(Exceptions.NullEntityId);

            var bar = await this.context.Bars
                                         .FirstOrDefaultAsync(c => c.Id == barId)
                                            ?? throw new ArgumentNullException(Exceptions.NullEntityId);

            if (bar.CountryId == countryId)
                throw new InvalidOperationException(Exceptions.AlreadyListed);

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
            var country = await GetCountriesQuerable()
                                            .FirstOrDefaultAsync(c => c.Id == countryId)
                                            ?? throw new ArgumentNullException(Exceptions.NullEntityId);

            var bar = await this.context.Bars
                                   .FirstOrDefaultAsync(c => c.Id == barId)
                                   ?? throw new ArgumentNullException(Exceptions.NullEntityId);

            if (bar.CountryId == countryId)
            {
                country.Bars.Remove(bar);

                this.context.Countries.Update(country);
                await this.context.SaveChangesAsync();
            }
            else
            {
                throw new InvalidOperationException(Exceptions.EntityNotFound);
            }
            return country.GetDTO();
        }
        private IQueryable<Country> GetCountriesQuerable()
        {
            var countries = this.context.Countries
                                        .Where(c => c.IsDeleted == false)
                                        ?? throw new ArgumentNullException(Exceptions.EntityNotFound);

            return countries;
        }
        private async Task<ICollection<Bar>> BarsAvailableEntities(Guid countryId)
        {
            var bars = await this.context.Bars
                                         .Where(b => b.IsDeleted == false)
                                         .Include(b => b.Country)
                                         .Where(b => b.CountryId == countryId)
                                         .ToListAsync()
                                         ?? throw new ArgumentNullException(Exceptions.NullEntityId);

            return bars;
        }
    }
}
