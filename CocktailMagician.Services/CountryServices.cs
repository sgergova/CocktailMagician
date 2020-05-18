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

        /// <summary>
        /// Adds new country to the database after checking if it does not exists already.
        /// </summary>
        /// <param name="countryDTO">This is the newly created ingredient object</param>
        /// <returns>CountryDTO</returns>
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

        /// <summary>
        /// Checks by given name if country is available in the database.
        /// </summary>
        /// <param name="name">Name of the country that should be found</param>
        /// <returns>CountryDTO</returns>
        public async Task<CountryDTO> GetCountry(string name)
        {
            var country = await this.context.Countries
                                           .Where(c => c.IsDeleted == false)
                                           .FirstOrDefaultAsync(c => c.Name == name)
                                           ?? throw new ArgumentNullException("Country was not found");


            return country.GetDTO();
        }

        /// <summary>
        /// Checks by given ID if country is available in the database.
        /// </summary>
        /// <param name="Id">Id of the country that should be found</param>
        /// <returns>CountryDTO</returns>
        public async Task<CountryDTO> GetCountry(Guid id)
        {
            var country = await this.context.Countries
                                           .Where(c => c.IsDeleted == false)
                                           .FirstOrDefaultAsync(c => c.Id == id)
                                           ?? throw new ArgumentNullException("Country was not found");


            return country.GetDTO();
        }


        /// <summary>
        /// Checks by given name if country is available in the database.
        /// </summary>
        /// <param name="name">Name of the countries that should be found</param>
        /// <returns>List of CountryDTO</returns>
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
        public async Task<ICollection<CountryDTO>> GetAllCountries()
        {
            var countries = this.context.Countries
                                        .Where(c => c.IsDeleted == false).AsQueryable();


          

            var countriesToReturn = await countries.ToListAsync();

            return countriesToReturn.GetDTOs();
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
            var countryToUpdate = await this.context.Countries.Where(c => c.IsDeleted == false)
                                               .FirstOrDefaultAsync(c => c.Id == id);

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
            var countryToDelete = this.context.Countries.Find(id)
                                                         ?? throw new ArgumentNullException();

            var barsAvailable = BarsAvailable(countryToDelete.Id).Result.GetEntities();

            countryToDelete.IsDeleted = true;
            countryToDelete.DeletedOn = DateTime.UtcNow;

            if (barsAvailable.Count != 0)
            {
                foreach (var bar in barsAvailable)
                {
                    countryToDelete.Bars.Remove(bar);
                }
            }

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
            var bars = await this.context.Bars
                                         .Where(b => b.IsDeleted == false)
                                         .Where(b => b.CountryId == countryId)
                                         .ToListAsync();

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
