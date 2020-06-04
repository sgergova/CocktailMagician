﻿using CocktailMagician.Data.Entities;
using CocktailMagician.Data.AppContext;
using CocktailMagician.Services.Contracts;
using CocktailMagician.Services.EntitiesDTO;
using CocktailMagician.Services.Mappers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CocktailMagician.Services.CommonMessages;

namespace CocktailMagician.Services
{
    public class CocktailServices : ICocktailServices
    {
        private readonly CMContext context;

        public CocktailServices(CMContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }
        /// <summary>
        /// Checks if given ID of cocktail exists in the database and if its not found throws an exception.
        /// </summary>
        /// <param name="id">Id of the Bar</param>
        /// <returns>CocktailDTO</returns>
        public async Task<CocktailDTO> GetCocktail(Guid id)
        {

            var entity = await GetCocktailsQueryable()
                                       .FirstOrDefaultAsync(b => b.Id == id)
                                       ?? throw new ArgumentNullException(Exceptions.EntityNotFound);

            return entity.GetDTO();
        }
        /// <summary>
        /// Orders found sequence of cocktails according to given parameters.
        /// </summary>
        /// <param name="name">Name of the cocktail</param>
        /// <param name="rating">Rating of the cocktail</param>
        /// <param name="ingredients">The ingredients that should search for</param>
        /// <returns>A sequence of all found cocktails</returns>
        public async Task<ICollection<CocktailDTO>> GetAllCocktails(string name, ICollection<CocktailIngredient> ingredients
            , int? rating)
        {
            var cocktails = GetCocktailsQueryable();

            if (name != null)
                cocktails = cocktails.Where(c => c.Name.ToLower().Contains(name.ToLower()));
            if (ingredients != null)
            {
                foreach (var item in ingredients)
                {
                    cocktails = cocktails.Where(c => c.CocktailIngredients.Contains(item));
                }
            }
            if (rating != null)
                cocktails = cocktails.Where(c => c.Rating == rating);

            var returnCocktails = await cocktails.ToListAsync();
            return returnCocktails.GetDTOs();
        }
        public async Task<ICollection<BarCocktailDTO>> GetBarsForCocktail(Guid cocktailId)
        {
            var barCocktails = await this.context.BarCocktails
                                              .Where(b => b.CocktailId == cocktailId)
                                              .Include(b => b.Cocktail)
                                              .Include(b => b.Bar)
                                              .ToListAsync()
                                              ?? throw new ArgumentNullException(Exceptions.MissingName);

            return barCocktails.GetDTOs();
        }

        public async Task<ICollection<CocktailDTO>> GetAllCocktails()
        {
            var cocktails = GetCocktailsQueryable();

            var returnCocktails = await cocktails.ToListAsync();
            return returnCocktails.GetDTOs();
        }
        public async Task<ICollection<CocktailDTO>> GetTopThreeCocktails()
        {
            var cocktails = this.context.Cocktails
                                    .Include(c => c.CocktailRatings)
                                    .Where(b => b.IsDeleted == false);

            var topThree = await cocktails.Take(3).ToListAsync();

            return topThree.GetDTOs();
        }
        /// <summary>
        /// Adds the new cocktail to the database after checking if it does not exists already.
        /// </summary>
        /// <param name="cocktailDTO">This is the newly created Bar object</param>
        /// <returns>Created cocktail as DTO</returns>
        public async Task<CocktailDTO> CreateCocktail(CocktailDTO cocktailDTO)
        {
            if (this.context.Cocktails.Any(c => c.Name == cocktailDTO.Name))
                throw new ArgumentException(Exceptions.NameExists);

            if (cocktailDTO.Name == null)
                throw new ArgumentNullException(Exceptions.MissingName);

            var cocktail = cocktailDTO.GetEntity();
            await context.Cocktails.AddAsync(cocktail);
            await context.SaveChangesAsync();

            if (cocktailDTO.IngredientNames != null)
                cocktailDTO.IngredientNames.Select(async i => { await AddIngredientToCocktail(cocktail.Name, i); });

            return cocktail.GetDTO();
        }

        /// <summary>
        /// Searches by name of ingredient and cocktail and if the ingredient is not existing in that cocktail it adds it.
        /// </summary>
        /// <param name="cocktailName">The cocktail that should be modified</param>
        /// <param name="ingredientName">The name of the ingredient that should be added</param>
        /// <returns>The updated cocktail as DTO</returns>
        public async Task<CocktailDTO> AddIngredientToCocktail(string cocktailName, string ingredientName)
        {
            var cocktail = await this.context.Cocktails
                                             .Where(c => c.IsDeleted == false)
                                             .FirstOrDefaultAsync(c => c.Name == cocktailName)
                                             ?? throw new ArgumentNullException(Exceptions.EntityNotFound);

            var ingredient = await this.context.Ingredients
                                           .Where(c => c.IsDeleted == false)
                                           .FirstOrDefaultAsync(i => i.Name == ingredientName)
                                            ?? throw new ArgumentNullException(Exceptions.EntityNotFound);

            var cocktailIngredient = await this.context.CocktailIngredients
                                                 .FirstOrDefaultAsync(ci => ci.Cocktail.Name == cocktailName
                                                 && ci.Ingredient.Name == ingredientName);
            if (cocktailIngredient == null)
            {
                var newIngredient = await Helper(cocktailName, ingredientName, cocktail.Id);
                this.context.Cocktails.Update(cocktail);
                this.context.Ingredients.Update(ingredient);
                await this.context.CocktailIngredients.AddAsync(newIngredient);
                await this.context.SaveChangesAsync();
            }
            else
            {
                throw new InvalidOperationException(Exceptions.AlreadyListed);
            }
            return cocktail.GetDTO();
        }
        
        public async Task<CocktailDTO> AddIngredientsToCocktail(string cocktailName, ICollection<string> ingredientsName)
        {
            var cocktail = await this.context.Cocktails
                                            .FirstOrDefaultAsync(c => c.Name == cocktailName && c.IsDeleted == false)
                                            ?? throw new ArgumentNullException(Exceptions.EntityNotFound);

            var a = ingredientsName.Select(async n => { await Helper(cocktailName, n, cocktail.Id); });

            await this.context.CocktailIngredients.AddRangeAsync();
            await this.context.SaveChangesAsync();

            return cocktail.GetDTO();
        }

        /// <summary>
        /// Filters the cocktails according to user's input and returns alcoholic or non-alcoholic cocktails
        /// </summary>
        /// <param name="criteria">Alcoholic or non-alcoholic cocktails should be found</param>
        /// <param name="ingredientName">The name of the ingredient that should be added</param>
        /// <returns>Sequence of cocktails as DTO</returns>
        public async Task<ICollection<CocktailDTO>> SearchByAlcohol(string criteria)
        {
            if (criteria == null)
                throw new ArgumentNullException(Exceptions.InvalidSearchCriteria);

            var cocktails = this.context.Cocktails
                                            .Where(c => c.IsDeleted == false)
                                            .AsQueryable();

            if (criteria == "non-alcoholic")
                cocktails = cocktails.Where(c => c.IsAlcoholic == false);

            if (criteria == "alcoholic")
                cocktails = cocktails.Where(c => c.IsAlcoholic == true);

            var cocktailsToReturn = await cocktails.ToListAsync();
            return cocktailsToReturn.GetDTOs();
        }
        /// <summary>
        /// Finds from the database the desired cocktail and the ingredient that should be removed and if they exist - 
        /// removes the ingredient.
        /// </summary>
        /// <param name="cocktailName">The name that should be modified</param>
        /// <param name="ingredientName">The ingredient that should be removed</param>
        /// <returns>The updated cocktail as DTO</returns>
        public async Task<CocktailDTO> RemoveIngredientFromCocktail(string cocktailName, string ingredientName)
        {
            var ingredient = await this.context.CocktailIngredients
                                               .Where(i => i.IsDeleted == false)
                                               .FirstOrDefaultAsync(i => i.Ingredient.Name == ingredientName)
                                               ?? throw new ArgumentNullException(Exceptions.EntityNotFound);

            var cocktail = await GetCocktailsQueryable()
                                          .FirstOrDefaultAsync(c => c.Name == cocktailName);

            var cocktailIngredient = await this.context.CocktailIngredients
                                       .FirstOrDefaultAsync(ci => ci.Ingredient.Name == ingredientName
                                       && ci.Cocktail.Name == cocktailName)
                                       ?? throw new ArgumentNullException(Exceptions.EntityNotFound);

            cocktailIngredient.ModifiedOn = DateTime.UtcNow;
            cocktail.CocktailIngredients.Remove(cocktailIngredient);

            this.context.Cocktails.Update(cocktail);
            this.context.CocktailIngredients.Update(cocktailIngredient);
            await this.context.SaveChangesAsync();

            return cocktail.GetDTO();
        }
        /// <summary>
        /// Updates a cocktail by given id.
        /// </summary>
        /// <param name="id">The id of the cocktail that should be updated</param>
        /// <param name="cocktailToUpdate">The changes that should be done</param>
        /// <returns>The updated cocktail as DTO</returns>
        public async Task<CocktailDTO> UpdateCocktail(Guid id, CocktailDTO cocktailToUpdate)
        {
            var cocktail = await GetCocktailsQueryable()
                                       .FirstOrDefaultAsync(c => c.Id == id)
                                       ?? throw new ArgumentNullException(Exceptions.NullEntityId);

            cocktail.Name = cocktailToUpdate.Name;
            cocktail.AlcoholPercentage = cocktailToUpdate.AlcoholPercentage;
            cocktail.IsAlcoholic = cocktailToUpdate.IsAlcoholic;
            cocktail.ImageURL = cocktailToUpdate.ImageURL;
            cocktail.ModifiedOn = DateTime.UtcNow;

            this.context.Cocktails.Update(cocktail);
            await this.context.SaveChangesAsync();

            return cocktail.GetDTO();
        }
        /// <summary>
        /// Delete a cocktail by given id after checking if it's existing
        /// </summary>
        /// <param name="id">The id of the cocktail that should be deleted</param>
        /// <returns>The updated cocktail as DTO</returns>
        public async Task<CocktailDTO> DeleteCocktail(Guid id)
        {
            var cocktailToDelete = await GetCocktailsQueryable()
                                 .FirstOrDefaultAsync(b => b.Id == id)
                                 ?? throw new ArgumentNullException(Exceptions.NullEntityId);

            var barCocktails = (await AvailabilityAtBarsEntities(cocktailToDelete.Id)).ToList();

            if (barCocktails.Count != 0)
                barCocktails.ForEach(bc => { bc.IsDeleted = true; bc.DeletedOn = DateTime.UtcNow; });

            cocktailToDelete.IsDeleted = true;
            cocktailToDelete.DeletedOn = DateTime.UtcNow;

            context.Cocktails.Update(cocktailToDelete);
            context.BarCocktails.UpdateRange(barCocktails);
            await context.SaveChangesAsync();

            return cocktailToDelete.GetDTO();
        }

        public async Task<ICollection<CocktailDTO>> GetIndexPageCocktails(string orderBy, int currentPage, string searchCriteria)
        {

            IQueryable<Cocktail> cocktails = this.context.Cocktails
                                               .Include(b => b.Comments)
                                                   .ThenInclude(c => c.User)
                                               .Where(b => b.IsDeleted == false);
            if (searchCriteria != null)
                cocktails = cocktails.Where(b => b.Name.Contains(searchCriteria));

            cocktails = OrderCocktail(cocktails, orderBy);
            cocktails = currentPage == 1 ? cocktails.Take(10) : cocktails.Skip((currentPage - 1) * 10).Take(10);

            var results = await cocktails.ToListAsync();

            return results.GetDTOs();
        }

        public int GetCount(int itemsPerPage, string searchCriteria)
        {
            double cocktailsCount = 0;
            if (searchCriteria != null)
                cocktailsCount = Math.Ceiling((double)this.context.Cocktails.Where(b => b.Name.Contains(searchCriteria)).Count() / itemsPerPage);
            else
            {
                cocktailsCount = this.context.Cocktails.Count();
            }
            var countInt = (int)cocktailsCount;

            return countInt;
        }

        /// <summary>
        /// Seraches in the database how many cocktails are listed in currect bar.
        /// </summary>
        /// <param name="cocktalId">The ID of the cocktail</param>
        /// <returns>Sequence of cocktails that are listed as DTOs</returns>
        public async Task<ICollection<BarCocktailDTO>> AvailabilityAtBars(Guid cocktalId)
        {
            var barCocktails = await AvailabilityAtBarsEntities(cocktalId);

            return barCocktails.GetDTOs();
        }
        private async Task<ICollection<BarCocktail>> AvailabilityAtBarsEntities(Guid cocktalId)
        {
            var barCocktails = await this.context.BarCocktails
                                                 .Where(bc => bc.IsDeleted == false)
                                                 .Where(bc => bc.CocktailId == cocktalId)
                                                 .ToListAsync()
                                                 ?? throw new ArgumentNullException(Exceptions.NullEntityId);

            return barCocktails;
        }
        private IQueryable<Cocktail> OrderCocktail(IQueryable<Cocktail> cocktails, string orderBy)
        {
            return orderBy switch
            {
                "name" => cocktails.OrderBy(c => c.Name),
                "name_desc" => cocktails.OrderByDescending(c => c.Name),
                "bar" => cocktails.OrderBy(c => c.Bars),
                "ingredient" => cocktails.OrderBy(c => c.CocktailIngredients),

                _ => cocktails.OrderBy(c => c.Name)
            };
        }
        private IQueryable<Cocktail> GetCocktailsQueryable()
        {
            var cocktails = this.context.Cocktails
                                    .Where(c => c.IsDeleted == false)
                                    ?? throw new ArgumentNullException(Exceptions.EntityNotFound);

            return cocktails;
        }

        private async Task<CocktailIngredient> Helper(string cocktailName, string ingredientName, Guid cocktailId)
        {
            var ingredient = await this.context.Ingredients
                                       .FirstOrDefaultAsync(i => i.Name == ingredientName && i.IsDeleted == false)
                                       ?? throw new ArgumentNullException(Exceptions.EntityNotFound);

            if (this.context.CocktailIngredients.Any(ci => ci.Cocktail.Name == cocktailName && ci.Ingredient.Name == ingredientName))
                throw new InvalidOperationException(Exceptions.AlreadyListed);

            return new CocktailIngredient { CocktailId = cocktailId, IngredientId = ingredient.Id };
        }
    }
}
