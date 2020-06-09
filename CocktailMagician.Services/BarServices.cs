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
        /// Orders  found sequence of bars according to given parameters.
        /// </summary>
        /// <param name="search">The criteria to search for</param>
        /// <returns>ICollection<BarDTO></returns>
        public async Task<ICollection<BarDTO>> GetAllBars()
        {
            var bars = GetAllBarsQueryable();
            var barsToReturn = new List<Bar>();

            barsToReturn = await bars.ToListAsync();
            var barsDTO = barsToReturn.GetDTOs();

            return barsDTO;
        }
        /// <summary>
        /// Sorts, by given bar ID, all related cocktails to certain bar.
        /// </summary>
        /// <param name="barId">The ID of bar</param>
        /// <returns>Sequence of all cocktails that the bar offers</returns>
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
                                    .Include(b=>b.Country)
                                    .Include(b => b.BarRating)
                                    .Where(b => b.IsDeleted == false)
                                    ?? throw new ArgumentNullException(Exceptions.EntityNotFound);

            var topThree = await bars.OrderByDescending(b=>b.AverageRating).Take(3).ToListAsync();
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
        public async Task<BarDTO> AddCocktailToBar(Guid barId, Guid cocktailId)
        {
            var bar = await GetAllBarsQueryable()
                                 .FirstOrDefaultAsync(b => b.Id == barId)
                                 ?? throw new ArgumentNullException(Exceptions.NullEntityId);

            var cocktailToAdd = await this.context.Cocktails
                                                   .Where(c => c.IsDeleted == false)
                                                   .FirstOrDefaultAsync(c => c.Id == cocktailId)
                                                   ?? throw new ArgumentNullException(Exceptions.NullEntityId);

            var barCocktail = await this.context.BarCocktails
                                            .FirstOrDefaultAsync(bc => bc.BarId == barId && bc.CocktailId == cocktailToAdd.Id);

            if (barCocktail != null)
                throw new InvalidOperationException(Exceptions.AlreadyListed);

            if (barCocktail == null)
            {
                var newBarCocktail =  Helper(bar, cocktailToAdd.Id);
                context.Cocktails.Update(cocktailToAdd);
                await context.BarCocktails.AddAsync(newBarCocktail);
                await context.SaveChangesAsync();
            }
            return bar.GetDTO();
        }
        /// <summary>
        /// Checks in the database if given cocktail's ID and bar's ID are valid and if yes adds cocktails to the bar.
        /// If some of the params is not valid throws exception.
        /// </summary>
        /// <param name="barId">The ID of the bar</param>
        /// <param name="cocktailsId">The sequence cocktails that should be added</param>
        /// <param name="cocktail"></param>
        /// <returns>The updated bar</returns>
        public async Task<BarDTO> AddCocktailsToBar(Guid barId, ICollection<Guid> cocktailsId)
        {
            var bar = await this.context.Bars
                                        .Include(b => b.Country)
                                        .FirstOrDefaultAsync(b => b.Id == barId && b.IsDeleted == false);

            if (bar == null)
                throw new ArgumentNullException(Exceptions.EntityNotFound);
           
            var newCocktailId = cocktailsId.ToList();
            newCocktailId.ForEach( c => { bar.BarCocktails.Add(Helper(bar, c)); });

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
        ///Searches in the database if given cocktail's ID and bar's ID are valid and if yes removes current cocktail from the bar.
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
        /// Searches in the database if given bar is available and if it exists updates with given one.
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
        /// <summary>
        /// After the sequence of bars is ordered according to given criteria, arrange the bars 10 per page. 
        /// </summary>
        /// <param name="currentPage">The page that user has opened</param>
        /// <param name="searchCriteria">The criteria that the bars should be ordered</param>
        /// <returns>Sequence of arranged bars as data transfer types</returns>
        public async Task<ICollection<BarDTO>> GetIndexPageBars(int currentPage, string searchCriteria)
        {
            var bars = SearchByCriteria(searchCriteria);
            bars = bars.OrderBy(b => b.Name);
            var barsToReturn = currentPage == 1 ? await bars.Take(10).ToListAsync()
                                : await bars.Skip((currentPage - 1) * 10).Take(10).ToListAsync();

            return barsToReturn.GetDTOs();
        }
        /// <summary>
        /// Get the count of all bars 
        /// </summary>
        /// <param name="itemsPerPage">The items that should be placed on a single page</param>
        /// <returns>The number of all bars</returns>
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
        /// <summary>
        /// Checks if in a given bar are offered some cocktails
        /// </summary>
        /// <param name="barToDeleteId">The ID of bar</param>
        /// <returns>Sequence of all found cocktails that are listed in the bar</returns>
        private async Task<ICollection<BarCocktail>> AvailabilityAtBarEntities(Guid barToDeleteId)
        {
            var barCocktailsAvailable = await this.context.BarCocktails
                                                   .Where(bc => bc.BarId == barToDeleteId && bc.IsListed == true)
                                                   .ToListAsync()
                                                   ?? throw new ArgumentNullException(Exceptions.NullEntityId);

            return barCocktailsAvailable;
        }
        /// <summary>
        /// Orders all available bars according to the criteria, as follows: by name, by country and/or by address,
        /// after that combines the result.
        /// </summary>
        /// <param name="searchCriteria"></param>
        /// <returns>Sequence of arranged bars as IQueryable</returns>
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
        /// <summary>
        /// Filters all the bars that are not marked as deleted in the database
        /// </summary>
        /// <returns>Sequence of all bars as IQueryable</returns>
        private IQueryable<Bar> GetAllBarsQueryable()
        {
            var entities = this.context.Bars
                                        .Include(b => b.Country)

                                        .Where(b => b.IsDeleted == false)
                                        ?? throw new ArgumentNullException(Exceptions.EntityNotFound);

            return entities;
        }
        /// <summary>
        /// Creates new instance of type BarCocktail, and lists certain cocktail to given bar.
        /// </summary>
        /// <param name="bar">The bar that should offer a cocktail</param>
        /// <param name="cocktailId">The ID of the cocktail that should be listed</param>
        /// <returns>A new instance of type BarCocktail</returns>
        private BarCocktail Helper(Bar bar, Guid cocktailId)
        {
            var cocktail = this.context.Cocktails
                                       .FirstOrDefault(c => c.Id == cocktailId && c.IsDeleted == false)
                                       ?? throw new ArgumentNullException(Exceptions.EntityNotFound);

            if (this.context.BarCocktails.Any(bc => bc.Bar.Id == bar.Id && bc.Cocktail.Id == cocktailId))
                throw new InvalidOperationException(Exceptions.AlreadyListed);

            return new BarCocktail { CocktailId = cocktailId, BarId = bar.Id, IsListed = true };
        }
    }
}
