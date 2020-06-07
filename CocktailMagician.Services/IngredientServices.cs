using CocktailMagician.Data.Entities;
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
    public class IngredientServices : IIngredientServices
    {
        private readonly CMContext context;

        public IngredientServices(CMContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        /// <summary>
        /// Checks by given ID if ingredient is available in the database.
        /// </summary>
        /// <param name="id">Id of the ingredient</param>
        /// <returns>IngredientDTO</returns>
        public async Task<IngredientDTO> GetIngredient(Guid id)
        {
            if (id == null)
                throw new ArgumentNullException(Exceptions.NullEntityId);


            var entity = await GetAllQueryable()
                                        .FirstOrDefaultAsync(b => b.Id == id);

            return entity.GetDTO();
        }
        /// <summary>
        /// Checks by given name if ingredient is available in the database.
        /// </summary>
        /// <param name="name">The name of the ingredient</param>
        /// <returns>IngredientDTO</returns>
        public async Task<IngredientDTO> GetIngredient(string name)
        {
            if (name == null)
                throw new ArgumentNullException(Exceptions.MissingName);

            var entity = await GetAllQueryable()
                                        .FirstOrDefaultAsync(b => b.Name == name);

            return entity.GetDTO();
        }
        /// <summary>
        /// Checks by given name and returns all the ingredient that contains the search criteria.
        /// </summary>
        /// <param name="name">The name of the ingredient</param>
        /// <returns><ICollection<IngredientDTO>></returns>
        public async Task<ICollection<IngredientDTO>> GetAllIngredients(string name)
        {
            var entities = GetAllQueryable();

            if (name != null)
                entities = entities.Where(i => i.Name.ToLower().Contains(name.ToLower()));

            var ingredients = await entities.ToListAsync();

            return ingredients.GetDTOs();
        }

        /// <summary>
        /// Adds new ingredient to the database after checking if it does not exists already.
        /// </summary>
        /// <param name="ingredientDTO">This is the newly created ingredient object</param>
        /// <returns>IngredientDTO</returns>
        public async Task<IngredientDTO> CreateIngredient(IngredientDTO ingredientDTO)
        {
            if (this.context.Ingredients.Any(b => b.Name == ingredientDTO.Name))
                throw new ArgumentException(Exceptions.NameExists);

            if (ingredientDTO.Name == null)
                throw new ArgumentNullException(Exceptions.MissingName);

            var ingredient = ingredientDTO.GetEntity();

            await context.Ingredients.AddAsync(ingredient);
            await context.SaveChangesAsync();

            return ingredient.GetDTO();
        }
        /// <summary>
        /// Checks in the database if given ingredient is available and if it exists updates it with given one.
        /// If the param is not valid throws exception. 
        /// </summary>
        /// <param name="ingredientDTO">The updates that should be done</param>
        /// <returns>The updated IngredientDTO</returns>
        public async Task<IngredientDTO> UpdateIngredient(Guid id, IngredientDTO ingredientDTO)
        {
            var ingredientToUpdate = await GetAllQueryable()
                                               .FirstOrDefaultAsync(i => i.Id == id)
                                               ?? throw new ArgumentNullException(Exceptions.NullEntityId);

            ingredientToUpdate.Name = ingredientDTO.Name;
            ingredientToUpdate.Quantity = ingredientDTO.Quantity;
            ingredientToUpdate.Description = ingredientDTO.Description;
            ingredientToUpdate.ModifiedOn = DateTime.UtcNow;

            this.context.Ingredients.Update(ingredientToUpdate);
            await this.context.SaveChangesAsync();

            return ingredientToUpdate.GetDTO();
        }

        /// <summary>
        /// Checks in the database if given ingredient is available and if it exists delete it.
        /// If ID is not valid throws exception. 
        /// </summary>
        /// <param name="id">The ID of the ingredient that should be deleted</param>
        /// <returns>IngredientDTO</returns>
        public async Task<IngredientDTO> DeleteIngredient(Guid id)
        {
            var ingredientToDelete = await GetAllQueryable()
                                                    .FirstOrDefaultAsync(i => i.Id == id)
                                                    ?? throw new ArgumentNullException(Exceptions.NullEntityId);

            var cocktailsIngredients = (await AvailabilityAtCocktailsEntities(ingredientToDelete.Id)).ToList();

            if (cocktailsIngredients.Count != 0)
                cocktailsIngredients.ForEach(ci => { ci.IsDeleted = true; ci.DeletedOn = DateTime.UtcNow; });

            ingredientToDelete.IsDeleted = true;
            ingredientToDelete.DeletedOn = DateTime.UtcNow;
            context.Ingredients.Update(ingredientToDelete);
            await context.SaveChangesAsync();

            return ingredientToDelete.GetDTO();
        }
        /// <summary>
        /// Checks in the database for given cocktail's ID.
        /// </summary>
        /// <param name="cocktailId">The cocktail that should search for</param>
        /// <returns>A list of cocktails that contain the ingredient</returns>
        public async Task<ICollection<CocktailIngredientDTO>> GetCocktailIngredients(Guid cocktailId)
        {
            var cocktailIngr = await this.context.CocktailIngredients
                                              .Where(i => i.Cocktail.Id == cocktailId && i.IsDeleted == false)
                                              .Include(i => i.Cocktail)
                                              .Include(i => i.Ingredient)
                                              .ToListAsync()
                                              ?? throw new ArgumentNullException(Exceptions.EntityNotFound);

            return cocktailIngr.GetDTOs();
        }

        public async Task<ICollection<IngredientDTO>> GetIndexPageIngredients(int currentPage, string searchCriteria)
        {
            IQueryable<Ingredient> ingredients = this.context.Ingredients
                                               .Where(i => i.IsDeleted == false);
            if (searchCriteria != null)
                ingredients = ingredients.Where(b => b.Name.Contains(searchCriteria));

            ingredients = ingredients.OrderBy(i => i.Name);
            ingredients = currentPage == 1 ? ingredients.Take(10) : ingredients.Skip((currentPage - 1) * 10).Take(10);

            var results = await ingredients.ToListAsync();
            return results.GetDTOs();
        }
        public int GetCount(int itemsPerPage)
        {
            double ingredientsCount = this.context.Ingredients.Count();
            var countInt = (int)ingredientsCount;

            return countInt;
        }
        /// <summary>
        /// Finds all the ingredients included in given cocktail.
        /// </summary>
        /// <param name="ingredientId">The ID of ingredient that should be found</param>
        /// <returns>Sequence of all cocktails that include the ingredient</returns>
        public async Task<ICollection<CocktailIngredientDTO>> AvailabilityAtCocktails(Guid ingredientId)
        {
            var cocktailIngredients = await AvailabilityAtCocktailsEntities(ingredientId);

            return cocktailIngredients.GetDTOs();
        }
        private async Task<ICollection<CocktailIngredient>> AvailabilityAtCocktailsEntities(Guid ingredientId)
        {
            var cocktailIngredients = await this.context.CocktailIngredients
                                                        .Where(b => b.IsDeleted == false)
                                                        .Where(b => b.IngredientId == ingredientId)
                                                        .ToListAsync()
                                                        ?? throw new ArgumentNullException(Exceptions.NullEntityId);

            return cocktailIngredients;
        }

        private IQueryable<Ingredient> GetAllQueryable()
        {
            var entities = this.context.Ingredients
                                       .Where(b => b.IsDeleted == false)
                                       ?? throw new ArgumentNullException(Exceptions.EntityNotFound);

            return entities;
        }
    }
}
