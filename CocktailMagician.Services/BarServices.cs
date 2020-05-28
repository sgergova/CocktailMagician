using CocktailMagician.Data.Entities;
using CocktailMagician.Data.AppContext;
using CocktailMagician.Services.CommonMessages;
using CocktailMagician.Services.Contracts;
using CocktailMagician.Services.EntitiesDTO;
using CocktailMagician.Services.Mappers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

using System.Threading.Tasks;

namespace CocktailMagician.Services
{
    public class BarServices : IBarServices
    {
        private readonly CMContext context;

        public BarServices(CMContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Searches if given ID of bar exists in the database and if its not found throws an exception.
        /// </summary>
        /// <param name="id">Id of the Bar</param>
        /// <returns>BarDTO</returns>
        public async Task<BarDTO> GetBar(Guid id)
        {
            var entity = await GetAllBarsQueryable()
                                        .FirstOrDefaultAsync(e => e.Id == id)
                                        ?? throw new ArgumentNullException(Exceptions.NullEntityId);

            return entity.GetDTO();

        }
        /// <summary>
        /// Searches if given name of bar exists in the database and if its not found throws an exception.
        /// </summary>
        /// <param name="name">Name of the Bar</param>
        /// <returns>BarDTO</returns>
        public async Task<BarDTO> GetBar(string barName)
        {
            if (barName == null)
                throw new ArgumentNullException(Exceptions.NullEntityId);

            var bar = await GetAllBarsQueryable()
                                     .FirstOrDefaultAsync(b => b.Name.ToLower().Contains(barName.ToLower()))
                                     ?? throw new ArgumentNullException(Exceptions.NullEntityId);


            return bar.GetDTO();

        }
        /// <summary>
        /// Orders found sequence of bars according to given parameters.
        /// </summary>
        /// <param name="name">Name of the Bar</param>
        /// <param name="rating">Rating of the Bar</param>
        /// <param name="address">Address of the Bar</param>
        /// <param name="country">Country of the Bar</param>
        /// <returns>ICollection<BarDTO></returns>
        public async Task<ICollection<BarDTO>> GetAllBars(string name, int? rating, string address, string country)
        {
            var bars = GetAllBarsQueryable();
            var barsToReturn = new List<Bar>();

            if (name != null)
                bars = bars.Where(b => b.Name.ToLower().Contains(name.ToLower()));

            if (address != null)
                bars = bars.Where(b => b.Address.ToLower().Contains(address.ToLower()));

            if (rating != 0)
                bars = bars.Where(b => b.Rating == rating);

            if (country != null)
                bars = bars.Where(b => b.Country.Name == country);

            barsToReturn = await bars.ToListAsync();

            var barsDTO = barsToReturn.GetDTOs();

            return barsDTO;
        }

        public IQueryable<Bar> OrderBar(IQueryable<Bar> bars, string orderBy)
        {
            return orderBy switch
            {
                "name" => bars.OrderBy(b => b.Name),
                "name_desc" => bars.OrderByDescending(b => b.Name),
                "address" => bars.OrderBy(b => b.Address),
                "cocktail" => bars.OrderBy(b => b.BarCocktails),
                "country" => bars.OrderBy(b => b.Country),

                _=> bars.OrderBy(b => b.Name)
            };
        }
        /// <summary>
        /// Adds the new bar to the database after checking if it does not exists already.
        /// </summary>
        /// <param name="barToCreate">This is the newly created Bar object</param>
        /// <returns>BarDTO</returns>
        public async Task<BarDTO> CreateBar(BarDTO barDTO)
        {

            if (this.context.Bars.Any(b => b.Name == barDTO.Name))
                throw new ArgumentException(Exceptions.NameExists);

            if (barDTO.Name == null)
                throw new ArgumentNullException(Exceptions.MissingName);

            var country = await this.context.Countries
                                       .Where(c => c.IsDeleted == false)
                                       .FirstOrDefaultAsync(c => c.Id == barDTO.CountryId || c.Name == barDTO.CountryName)
                                        ?? throw new ArgumentNullException(Exceptions.EntityNotFound);

            var bar = barDTO.GetEntity();

            await context.Bars.AddAsync(bar);
            await context.SaveChangesAsync();

            return bar.GetDTO();
        }
        /// <summary>
        /// Checks in the database if given cocktail's ID and bar's ID are valid and if yes adds current cocktail to the bar.
        /// If some of the params is not valid throws exception.
        /// </summary>
        /// <param name="barId">The ID of the bar</param>
        /// <param name="cocktailId">The ID of the cocktail to add</param>
        /// <param name="cocktail"></param>
        /// <returns>BarDTO</returns>
        public async Task<BarDTO> AddCocktailToBar(Guid barId, CocktailDTO cocktail)
        {
            var bar = await GetAllBarsQueryable()
                                 .FirstOrDefaultAsync(b => b.Id == barId)
                                 ?? throw new ArgumentNullException(Exceptions.NullEntityId);

            var cocktailToAdd = await this.context.Cocktails
                                                   .Where(c => c.IsDeleted == false)
                                                   .FirstOrDefaultAsync(c => c.Id == cocktail.Id)
                                                   ?? throw new ArgumentNullException(Exceptions.NullEntityId);

            var barCocktail = await this.context.BarCocktails
                                            .FirstOrDefaultAsync(bc => bc.BarId == barId && bc.CocktailId == cocktail.Id);

            if (barCocktail != null)
                throw new InvalidOperationException(Exceptions.AlreadyListed);

            if (barCocktail == null)
            {
                var newBarCocktail = new BarCocktail
                {
                    Bar = bar,
                    Cocktail = cocktailToAdd,
                    IsListed = true
                };
                context.Cocktails.Update(cocktailToAdd);
                await context.BarCocktails.AddAsync(newBarCocktail);
                await context.SaveChangesAsync();
            }
            else
            {
                throw new InvalidOperationException(Exceptions.AlreadyListed);
            }

            return bar.GetDTO();
        }
        /// <summary>
        ///Check in the database if given cocktail's ID and bar's ID are valid and if yes removes current cocktail from the bar.
        /// If some of the params is not valid throws exception. 
        /// </summary>
        /// <param name="barId"></param>
        /// <param name="cocktailId"></param>
        /// <returns>BarDTO</returns>
        public async Task<BarDTO> RemoveCocktailFromBar(Guid barId, Guid cocktailId)
        {
            var bar = await GetAllBarsQueryable()
                            .FirstOrDefaultAsync(b => b.Id == barId)
                            ?? throw new ArgumentNullException(Exceptions.NullEntityId);

            var cocktail = await this.context.Cocktails
                                             .FirstOrDefaultAsync(c => c.Id == cocktailId)
                                             ?? throw new ArgumentNullException(Exceptions.NullEntityId);

            var barCocktail = await this.context.BarCocktails
                                                .FirstOrDefaultAsync(bc => bc.BarId == barId && bc.CocktailId == cocktailId);

            if (barCocktail != null)
            {
                barCocktail.IsListed = false;
                barCocktail.ModifiedOn = DateTime.UtcNow;
                bar.BarCocktails.Remove(barCocktail);
                cocktail.Bars.Remove(barCocktail);

                this.context.Update(barCocktail);
                await this.context.SaveChangesAsync();
            }
            else
            {
                throw new InvalidOperationException(Exceptions.AlreadyListed);
            }

            return bar.GetDTO();
        }
        /// <summary>
        ///Searchs in the database if given cocktail's ID and bar's ID are valid and if yes removes current cocktail from the bar.
        /// If some of the params is not valid throws exception. 
        /// </summary>
        /// <param name="barId"></param>
        /// <param name="cocktailId"></param>
        /// <returns>BarDTO</returns>
        public async Task<BarDTO> RemoveCocktailFromBar(Guid barCocktailId)
        {
            var barCocktail = await this.context.BarCocktails
                                                .FirstOrDefaultAsync(bc => bc.Id == barCocktailId)
                                                ?? throw new ArgumentNullException(Exceptions.NullEntityId);
            var bar = barCocktail.Bar;
            var cocktail = barCocktail.Cocktail;

            barCocktail.IsListed = false;
            barCocktail.ModifiedOn = DateTime.UtcNow;
            bar.BarCocktails.Remove(barCocktail);
            cocktail.Bars.Remove(barCocktail);

            this.context.Update(barCocktail);
            await this.context.SaveChangesAsync();

            return bar.GetDTO();
        }


        /// <summary>
        /// Searchs in the database if given bar is available and if it exists updates with given one.
        /// If some of the params is not valid throws exception. 
        /// </summary>
        /// <param name="id">The ID of bar that should be updated</param>
        /// <param name="barDTO">The updates that should be done</param>
        /// <returns>The updated BarDTO</returns>
        public async Task<BarDTO> UpdateBar(Guid id, BarDTO barDTO)
        {
            var barToUpdate = await GetAllBarsQueryable()
                                                .FirstOrDefaultAsync(b => b.Id == id)
                                                ?? throw new ArgumentNullException(Exceptions.AlreadyListed);

            barToUpdate.Name = barDTO.Name;
            barToUpdate.Address = barDTO.Address;
            barToUpdate.Phone = barDTO.Phone;
            barToUpdate.BarImageURL = barDTO.ImageURL;
            barToUpdate.Country.Name = barDTO.CountryName;
            barToUpdate.ModifiedOn = DateTime.UtcNow;

            this.context.Bars.Update(barToUpdate);
            await this.context.SaveChangesAsync();

            return barToUpdate.GetDTO();
        }

        /// <summary>
        /// Checks in the database if given bar is available and if it exists delete it.
        /// If ID is not valid throws exception. 
        /// </summary>
        /// <param name="id">The ID of bar that should be deleted</param>
        /// <returns>BarDTO</returns>
        public async Task<bool> DeleteBar(Guid id)
        {
            var barToDelete = await GetAllBarsQueryable()
                                   .FirstOrDefaultAsync(b => b.Id == id)
                                   ?? throw new ArgumentNullException(Exceptions.AlreadyListed);

            var country = barToDelete.Country;

            var barCocktails = await AvailabilityAtBarEntities(barToDelete.Id);

            barToDelete.IsDeleted = true;
            country.Bars.Remove(barToDelete);
            country.ModifiedOn = DateTime.UtcNow;
            barToDelete.DeletedOn = DateTime.UtcNow;

            if (barCocktails.Count != 0)
            {
                foreach (var barCocktail in barCocktails)
                {
                    barCocktail.IsDeleted = true;
                    barCocktail.DeletedOn = DateTime.UtcNow;
                }
            }
            context.Bars.Update(barToDelete);
            context.Countries.Update(country);
            await context.SaveChangesAsync();

            return true;
        }

        public async Task<ICollection<BarDTO>> GetIndexPageBars(string orderBy, int currentPage, string searchCriteria)
        {

            IQueryable<Bar> bars = this.context.Bars
                                               .Include(b => b.Country)
                                               .Include(b => b.BarCocktails)
                                               .Include(b => b.Comments)
                                                   .ThenInclude(c => c.User)
                                               .Where(b => b.IsDeleted == false);

            bars = OrderBar(bars, orderBy);

            if (currentPage == 1)
            {
                bars = bars.Take(10);
            }
            else if (currentPage > 1)
            {
                bars = bars.Skip((currentPage - 1) * 10)
                           .Take(10);
            }
         
            var results = await bars.ToListAsync();

            return results.GetDTOs();
        }

        public int GetCount(int itemsPerPage, string searchCriteria, string type)
        {
            double barsCount = 0;
            if (searchCriteria != null)
            {
                if (type == "Name")
                {
                    barsCount = Math.Ceiling((double)this.context.Bars.Where(b => b.Name.Contains(searchCriteria)).Count() / itemsPerPage);
                }
                else if (type == "Country")
                {
                    barsCount = Math.Ceiling((double)this.context.Bars.Where(b => b.Country.Name.Contains(searchCriteria)).Count() / itemsPerPage);
                }
            }
            else
            {
                barsCount = this.context.Bars.Count();
            }
            var countInt = (int)barsCount;

            return countInt;
        }
        /// <summary>
        /// Checks by given Id of bar how many cocktails are listed in it.
        /// </summary>
        /// <param name="barToDeleteId">Id of the bar</param>
        /// <returns>ICollection of the available cocktails in that bar</returns>
        public async Task<ICollection<BarCocktailDTO>> AvailabilityAtBar(Guid barToDeleteId)
        {
            var barCocktailsAvailable = await AvailabilityAtBarEntities(barToDeleteId);


            return barCocktailsAvailable.GetDTOs();
        }

        private async Task<ICollection<BarCocktail>> AvailabilityAtBarEntities(Guid barToDeleteId)
        {
            var barCocktailsAvailable = await this.context.BarCocktails
                                                    .Where(bc => bc.BarId == barToDeleteId)
                                                    .Where(bc => bc.IsListed == true)
                                                    .ToListAsync();

            return barCocktailsAvailable;
        }

        private IQueryable<Bar> GetAllBarsQueryable()
        {
            var entities = this.context.Bars
                                        .Include(b => b.Country)
                                       .Where(b => b.IsDeleted == false)
                                       ?? throw new ArgumentNullException(Exceptions.EntityNotFound);

            return entities;
        }
    }
}
