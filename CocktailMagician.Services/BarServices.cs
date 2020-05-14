using CocktailMagician.Data.Entities;
using CocktailMagician.DataBase.AppContext;
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
    public class BarServices: IBarServices
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
                                .Include(b => b.BarCocktails)
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
                                         .Include(b=>b.BarCocktails)
                                         .FirstOrDefaultAsync(b => b.Name.ToLower().Contains(barName.ToLower())) 
                                         ?? throw new ArgumentNullException();

           
            return bar.GetDTO();

        }
        /// <summary>
        /// Sorts the bars of a sequence in ascending order according to names.
        /// </summary>
        /// <returns>ICollection<BarDTO></BarDTO></returns>
        public async Task<ICollection<BarDTO>> GetAllBars()
        {
            var bars = await GetAllBarsQueryable()
                                        .OrderBy(b=>b.Name)
                                        .ToListAsync();

                                    

            return bars.GetDTOs();
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

            var bar = barDTO.GetEntity();
            await context.Bars.AddAsync(bar);
            await context.SaveChangesAsync();

            return bar.GetDTO();
            //var bar = new Bar
            //{
            //    Name = barDTO.Name,
            //    Address = barDTO.Address,
            //    Phone = barDTO.Phone,
            //    BarCocktails = barDTO.BarCocktails,
            //    ImageURL = barDTO.ImageURL,
            //    CreatedOn = DateTime.UtcNow
            //};
        }

       
        public async Task<BarDTO> UpdateBar(BarDTO barDTO)
        {
            if (barDTO.Id == null)
                throw new ArgumentNullException("Value cannot be null.");

            var barToUpdate = await GetBar(barDTO.Id);
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
