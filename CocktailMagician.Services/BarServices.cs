﻿using CocktailMagician.Data.Entities;
using CocktailMagician.DataBase.AppContext;
using CocktailMagician.Services.Contracts;
using CocktailMagician.Services.EntitiesDTO;
using CocktailMagician.Services.Mappers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
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
                                        ?? throw new ArgumentNullException("The ID of the bar cannot be null");

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
                throw new ArgumentNullException("The name cannot be null.");

            var bar = await GetAllBarsQueryable()
                                         .FirstOrDefaultAsync(b => b.Name.ToLower().Contains(barName.ToLower()))
                                         ?? throw new ArgumentNullException();


            return bar.GetDTO();

        }


        /// <summary>
        /// Sorts the bars of a sequence in according to given parameters.
        /// </summary>
        /// <param name="name">Name of the Bar</param>
        /// <param name="rating">Rating of the Bar</param>
        /// <param name="address">Address of the Bar</param>
        /// <returns>ICollection<BarDTO></BarDTO></returns>
        public async Task<ICollection<BarDTO>> GetAllBars(string name, int? rating, string address)
        {
            var bars = GetAllBarsQueryable();

            if (name != null)
                bars = bars.Where(b => b.Name.ToLower().Contains(name.ToLower()));

            if (address != null)
                bars = bars.Where(b => b.Address.ToLower().Contains(address.ToLower()));

            if (rating != 0)
                bars = bars.Where(b => b.Rating == rating);


            var barsToReturn = await bars.ToListAsync();
            return barsToReturn.GetDTOs();
        }

        public IQueryable<Bar> OrderBeer(IQueryable<Bar> bars, string orderBy)
        {
            return orderBy switch
            {
                "name" => bars.OrderBy(b => b.Name),
                "name_desc" => bars.OrderByDescending(b => b.Name),
                "address" => bars.OrderBy(b => b.Address),
                "cocktail" => bars.OrderBy(b => b.BarCocktails),

                _ => throw new InvalidOperationException("Command does not exist")
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
                throw new ArgumentException("The name is already existing");

            if (barDTO.Name == null)
                throw new ArgumentNullException("The name is mandatory");


            var bar = new Bar
            {
                Name = barDTO.Name,
                Address = barDTO.Address,
                Phone = barDTO.Phone,
                BarCocktails = barDTO.BarCocktails,
                ImageURL = barDTO.ImageURL,
                CreatedOn = DateTime.UtcNow
            };
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
                                 ?? throw new ArgumentNullException();


            var cocktailToAdd = cocktail.GetEntity();

            var barCocktail = await this.context.BarCocktails
                                            .FirstOrDefaultAsync(bc => bc.BarId == barId && bc.CocktailId == cocktail.Id);

            if (barCocktail != null)
                throw new InvalidOperationException($"The cocktail is already listed on {bar}");


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
                throw new InvalidOperationException("This cocktail is already in this bar.");
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
                            .FirstOrDefaultAsync(b => b.Id == barId);

            var cocktail = await this.context.Cocktails
                                             .FirstOrDefaultAsync(c => c.Id == cocktailId);

            var barCocktail = await this.context.BarCocktails
                                                .FirstOrDefaultAsync(bc => bc.BarId == barId && bc.CocktailId == cocktailId)
                                                ?? throw new ArgumentNullException();


            barCocktail.IsListed = false;
            barCocktail.ModifiedOn = DateTime.UtcNow;
            bar.BarCocktails.Remove(barCocktail);
            cocktail.Bars.Remove(barCocktail);


            this.context.Update(barCocktail);
            await this.context.SaveChangesAsync();

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
                                                ?? throw new ArgumentNullException();
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
        /// <param name="id">T|he ID of bar that should be updated</param>
        /// <param name="barDTO">The updates that should be done</param>
        /// <returns>The updated BarDTO</returns>
        public async Task<BarDTO> UpdateBar(Guid id, BarDTO barDTO)
        {
            var barToUpdate = await GetBar(id);

            var bar = barToUpdate.GetEntity();

            bar.Name = barDTO.Name;
            bar.Address = barDTO.Address;
            bar.Phone = barDTO.Phone;
            bar.ImageURL = barDTO.ImageURL;
            bar.ModifiedOn = DateTime.UtcNow;

            this.context.Bars.Update(bar);
            await this.context.SaveChangesAsync();

            return bar.GetDTO();

        }
        /// <summary>
        /// Searchs in the database if given bar is available and if it exists delete it.
        /// If ID is not valid throws exception. 
        /// </summary>
        /// <param name="id">The ID of bar that should be deleted</param>
        /// <returns>BarDTO</returns>
        public async Task<BarDTO> DeleteBar(Guid id)
        {
            var barToDelete = await GetAllBarsQueryable()
                                 .Include(b => b.BarCocktails)
                                 .FirstOrDefaultAsync(b => b.Id == id)
                                 ?? throw new ArgumentNullException();


            if (barToDelete.BarCocktails.Any(c => c.IsDeleted == true))
            {
                barToDelete.IsDeleted = true;
                barToDelete.DeletedOn = DateTime.UtcNow;
                context.Bars.Update(barToDelete);
                await context.SaveChangesAsync();
            }
            else
            {
                throw new InvalidOperationException($"Cannot delete {barToDelete}" +
                    $"There are cocktails available.");
            }

            return barToDelete.GetDTO();
        }



        private IQueryable<Bar> GetAllBarsQueryable()
        {
            var entities = this.context.Bars
                                       .Where(b => b.IsDeleted == false)
                                       ?? throw new ArgumentNullException("The value cannot be null");

            return entities;
        }
    }
}
