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
            this.context = context ?? throw new ArgumentNullException(nameof(context));
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
        /// <param name="search">The criteria to search for</param>
        /// <returns>ICollection<BarDTO></returns>
        public async Task<ICollection<BarDTO>> GetAllBars(string search)
        {
            var bars = GetAllBarsQueryable();
            var barsToReturn = new List<Bar>();

            if (search != null)
                bars = bars.Where(b => b.Name.ToLower().Contains(search.ToLower()) || b.Address.ToLower().Contains(search.ToLower()));

            barsToReturn = await bars.ToListAsync();
            var barsDTO = barsToReturn.GetDTOs();

            return barsDTO;
        }
        public async Task<ICollection<BarCocktailDTO>> GetCocktailsForBar(Guid barId)
        {

            var barCocktails = await this.context.BarCocktails
                                              .Where(b => b.BarId == barId)
                                              .Include(b => b.Cocktail)
                                              .Include(b => b.Bar)
                                              .ToListAsync()
                                              ?? throw new ArgumentNullException(Exceptions.EntityNotFound);

            return barCocktails.GetDTOs();
        }

        public async Task<ICollection<BarDTO>> GetTopThreeBars()
        {
            var bars = this.context.Bars
                                    .Include(b => b.BarRating)
                                    .Where(b => b.IsDeleted == false)
                                    ?? throw new ArgumentNullException(Exceptions.EntityNotFound);

            var topThree = await bars.Take(3).ToListAsync();
            var topThreeDTO = topThree.GetDTOs();
            return topThreeDTO;
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
        public async Task<BarDTO> AddCocktailToBar(Guid barId, string cocktailName)
        {
            var bar = await GetAllBarsQueryable()
                                 .FirstOrDefaultAsync(b => b.Id == barId)
                                 ?? throw new ArgumentNullException(Exceptions.NullEntityId);

            var cocktailToAdd = await this.context.Cocktails
                                                   .Where(c => c.IsDeleted == false)
                                                   .FirstOrDefaultAsync(c => c.Name == cocktailName)
                                                   ?? throw new ArgumentNullException(Exceptions.NullEntityId);

            var barCocktail = await this.context.BarCocktails
                                            .FirstOrDefaultAsync(bc => bc.BarId == barId && bc.CocktailId == cocktailToAdd.Id);

            if (barCocktail != null)
                throw new InvalidOperationException(Exceptions.AlreadyListed);

            if (barCocktail == null)
            {
                var newBarCocktail = await Helper(bar.Name, cocktailName, cocktailToAdd.Id);
                context.Cocktails.Update(cocktailToAdd);
                await context.BarCocktails.AddAsync(newBarCocktail);
                await context.SaveChangesAsync();
            }
            return bar.GetDTO();
        }
        public async Task<BarDTO> AddCocktailsToBar(string barName, ICollection<string> cocktailNames)
        {
            var bar = await this.context.Bars
                                        .Include(b => b.Country)
                                        .FirstOrDefaultAsync(c => c.Name == barName && c.IsDeleted == false);

            if (bar == null)
                throw new ArgumentNullException(Exceptions.EntityNotFound);

            var a = cocktailNames.Select(async n => { await Helper(bar.Name, n, bar.Id); });

            this.context.Bars.Update(bar);
            await this.context.BarCocktails.AddRangeAsync();
            await this.context.SaveChangesAsync();

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

                this.context.Update(barCocktail);
                await this.context.SaveChangesAsync();
            }
            else
            {
                throw new InvalidOperationException(Exceptions.EntityNotFound);
            }

            return bar.GetDTO();
        }
        /// <summary>
        ///Searchs in the database if given cocktail's ID and bar's ID are valid and if yes removes current cocktail from the bar.
        /// If some of the params is not valid throws exception. 
        /// </summary>
        /// <param name="barCocktailId">The ID of bar that should be removed</param>
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
                                                ?? throw new ArgumentNullException(Exceptions.EntityNotFound);

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
        public async Task<BarDTO> DeleteBar(Guid id)
        {
            var barToDelete = await GetAllBarsQueryable()
                                   .FirstOrDefaultAsync(b => b.Id == id)
                                   ?? throw new ArgumentNullException(Exceptions.EntityNotFound);

            var country = barToDelete.Country;

            var barCocktails = (await AvailabilityAtBarEntities(barToDelete.Id)).ToList();

            barToDelete.IsDeleted = true;
            country.ModifiedOn = DateTime.UtcNow;
            barToDelete.DeletedOn = DateTime.UtcNow;

            if (barCocktails.Count != 0)
            {
                barCocktails.ForEach(bc => { bc.IsDeleted = true; bc.DeletedOn = DateTime.UtcNow; });
                context.BarCocktails.UpdateRange(barCocktails);
            }
            context.Bars.Update(barToDelete);
            context.Countries.Update(country);
            await context.SaveChangesAsync();

            return barToDelete.GetDTO();
        }

        public async Task<ICollection<BarDTO>> GetIndexPageBars(int currentPage, string searchCriteria)
        {
            var bars = SearchByCriteria(searchCriteria);
            bars.OrderBy(b => b.Name);
            var barsToReturn = currentPage == 1 ? await bars.Take(10).ToListAsync()
                                : await bars.Skip((currentPage - 1) * 10).Take(10).ToListAsync();

            return barsToReturn.GetDTOs();
        }

        public int GetCount(int itemsPerPage)
        {
            double barsCount = this.context.Bars.Count();
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
                                                   .Where(bc => bc.BarId == barToDeleteId && bc.IsListed == true)
                                                   .ToListAsync()
                                                   ?? throw new ArgumentNullException(Exceptions.NullEntityId);

            return barCocktailsAvailable;
        }

        private IQueryable<Bar> SearchByCriteria(string searchCriteria)
        {
            IQueryable<Bar> bars = this.context.Bars
                                             .Include(b => b.Country)
                                             .Include(b => b.BarCocktails)
                                             .Include(b => b.Comments)
                                                 .ThenInclude(c => c.User)
                                             .Where(b => b.IsDeleted == false);
            if (searchCriteria != null)
            {
                var name = bars.Where(b => b.Name.Contains(searchCriteria));
                var country = bars.Where(b => b.Country.Name.Contains(searchCriteria));
                var address = bars.Where(b => b.Address.Contains(searchCriteria));
                bars = name.Union(country).Union(address);
            }

            return bars;
        }

        private IQueryable<Bar> GetAllBarsQueryable()
        {
            var entities = this.context.Bars
                                        .Include(b => b.Country)

                                       .Where(b => b.IsDeleted == false)
                                       ?? throw new ArgumentNullException(Exceptions.EntityNotFound);

            return entities;
        }

        private async Task<BarCocktail> Helper(string barName, string cocktailName, Guid cocktailId)
        {
            var bar = await this.context.Bars
                                        .FirstOrDefaultAsync(b => b.Name == barName && b.IsDeleted == false)
                                        ?? throw new ArgumentNullException(Exceptions.EntityNotFound);

            if (this.context.BarCocktails.Any(bc => bc.Bar.Name == barName && bc.Cocktail.Name == cocktailName))
                throw new InvalidOperationException(Exceptions.AlreadyListed);

            return new BarCocktail { CocktailId = cocktailId, BarId = bar.Id, IsListed = true };
        }
    }
}
