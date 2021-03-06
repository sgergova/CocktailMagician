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
                                    .Where(b => b.IsDeleted == false)
                                    ?? throw new ArgumentNullException(Exceptions.EntityNotFound);

            var topThree = await cocktails.OrderByDescending(b => b.AverageRating).Take(3).ToListAsync();
            var topThreeDTO = topThree.GetDTOs();
            return topThreeDTO;
        }
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
        /// <summary>
        /// By given ID of cocktail, filters all the bars that it is offered
        /// </summary>
        /// <param name="cocktailId">The ID of cocktail</param>
        /// <returns>Sequence of type BarCocktail which contains the information about the bars offered in</returns>
        public async Task<ICollection<BarCocktailDTO>> GetBarsOfCocktail(Guid cocktailId)
        {
            var barCocktails = await this.context.BarCocktails
                                              .Where(b => b.CocktailId == cocktailId && b.IsDeleted == false
                                               && b.IsListed == true)
                                              .Include(b => b.Cocktail)
                                              .Include(b => b.Bar)
                                              .ToListAsync()
                                              ?? throw new ArgumentNullException(Exceptions.EntityNotFound);

            return barCocktails.GetDTOs();
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
                var newIngredient =  Helper(cocktail, ingredient.Id);
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
        /// <summary>
        /// Adds given sequence of ingredients to a cocktail.
        /// </summary>
        /// <param name="cocktailId">The cocktail that should be modified</param>
        /// <param name="ingredientsId">The sequence of ingredients that should be added</param>
        /// <returns>The updated cocktail as DTO</returns>
        public async Task<CocktailDTO> AddIngredientsToCocktail(Guid cocktailId, ICollection<Guid> ingredientsId)
        {
            var cocktail = await this.context.Cocktails
                                             .Include(c=>c.CocktailIngredients)
                                            .FirstOrDefaultAsync(c => c.Id == cocktailId && c.IsDeleted == false)
                                            ?? throw new ArgumentNullException(Exceptions.EntityNotFound);


            if (cocktail == null)
                throw new ArgumentNullException(Exceptions.EntityNotFound);

            var newIngredientsId = ingredientsId.ToList();
            newIngredientsId.ForEach( c => { cocktail.CocktailIngredients.Add( Helper(cocktail, c)); });
           
            this.context.Cocktails.Update(cocktail);
            await this.context.BarCocktails.AddRangeAsync();
            await this.context.SaveChangesAsync();

            return cocktail.GetDTO();
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
        /// <summary>
        /// After the sequence of cocktails is ordered according to given criteria, arrange the cocktails 10 per page. 
        /// </summary>
        /// <param name="currentPage">The page that user has opened</param>
        /// <param name="searchCriteria">The criteria that the bars should be ordered</param>
        /// <returns>Sequence of arranged cocktails as data transfer types</returns>
        public async Task<ICollection<CocktailDTO>> GetIndexPageCocktails(int currentPage, string searchCriteria)
        {
            IQueryable<Cocktail> cocktails = this.context.Cocktails
                                               .Include(b => b.Comments)
                                                   .ThenInclude(c => c.User)
                                               .Where(b => b.IsDeleted == false);
            if (searchCriteria != null)
                cocktails = cocktails.Where(b => b.Name.Contains(searchCriteria));

            cocktails = cocktails.OrderBy(c => c.Name);
            cocktails = currentPage == 1 ? cocktails.Take(10) : cocktails.Skip((currentPage - 1) * 10).Take(10);

            var results = await cocktails.ToListAsync();
            return results.GetDTOs();
        }

        public int GetCount(int itemsPerPage)
        {
            double cocktailsCount = this.context.Cocktails.Count();
            var countInt = (int)cocktailsCount;

            return countInt;
        }

        /// <summary>
        /// Searches in the database how many cocktails are listed in current bar.
        /// </summary>
        /// <param name="cocktalId">The ID of the cocktail</param>
        /// <returns>Sequence of cocktails that are listed as DTOs</returns>
        public async Task<ICollection<BarCocktailDTO>> AvailabilityAtBars(Guid cocktalId)
        {
            var barCocktails = await AvailabilityAtBarsEntities(cocktalId);

            return barCocktails.GetDTOs();
        }
        /// <summary>
        /// Searches in the database how many cocktails are listed in current bar.
        /// </summary>
        /// <param name="cocktalId">The ID of the cocktail</param>
        /// <returns>Sequence of cocktails that are listed </returns>
        private async Task<ICollection<BarCocktail>> AvailabilityAtBarsEntities(Guid cocktalId)
        {
            var barCocktails = await this.context.BarCocktails
                                                 .Where(bc => bc.IsDeleted == false)
                                                 .Where(bc => bc.CocktailId == cocktalId)
                                                 .ToListAsync()
                                                 ?? throw new ArgumentNullException(Exceptions.NullEntityId);

            return barCocktails;
        }
        /// <summary>
        /// <summary>
        /// Filters all the cocktails that are not marked as deleted in the database
        /// </summary>
        /// <returns>Sequence of all cocktails as IQueryable</returns>
        private IQueryable<Cocktail> GetCocktailsQueryable()
        {
            var cocktails = this.context.Cocktails
                                    .Where(c => c.IsDeleted == false)
                                    ?? throw new ArgumentNullException(Exceptions.EntityNotFound);

            return cocktails;
        }
        /// <summary>
        /// Creates new instance of type CocktailIngredient, and adds certain ingredient to given cocktail.
        /// </summary>
        /// <param name="cocktail">The cocktail that contains certain ingredient</param>
        /// <param name="ingredientId">The ID of the ingredient that should be added</param>
        /// <returns>A new instance of type BarCocktail</returns>
        private CocktailIngredient Helper(Cocktail cocktail, Guid ingredientId)
        {
            var ingredient =  this.context.Ingredients
                                       .FirstOrDefault(i => i.Id == ingredientId && i.IsDeleted == false)
                                       ?? throw new ArgumentNullException(Exceptions.EntityNotFound);

            if (this.context.CocktailIngredients.Any(ci => ci.Cocktail.Id == cocktail.Id && ci.Ingredient.Id == ingredientId))
                throw new InvalidOperationException(Exceptions.AlreadyListed);

            return new CocktailIngredient { CocktailId = cocktail.Id, IngredientId = ingredient.Id };
        }
    }
}
