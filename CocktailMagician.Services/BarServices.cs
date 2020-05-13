using CocktailMagician.Data.Entities;
using CocktailMagician.DataBase.AppContext;
using CocktailMagician.Services.EntitiesDTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CocktailMagician.Services
{
    public class BarServices 
    {
        private readonly CMContext context;

        public BarServices(CMContext context)
        {
            this.context = context;
        }

        public async Task<Bar> Get(Guid id)
        {
            var entity = await this.context.Bars
                                    .Where(b=>b.IsDeleted == false)
                                    .FirstOrDefaultAsync(b => b.Id == id)
                                    ?? throw new ArgumentNullException("The value cannot be null.");
            
            return entity;

        }

        public async Task<ICollection<Bar>> GetAll()
        {
            var entities = await this.context.Bars
                                    .Where(b => b.IsDeleted == false)
                                    .ToListAsync()
                                    ?? throw new ArgumentNullException("The value cannot be null.");

            return entities;
        }

        public async Task<Bar> Create(BarDTO barDTO)
        {
            if (this.context.Bars.Any(b => b.Name == barDTO.Name))
                    throw new ArgumentException("The name is already existing");
            
            if (barDTO.Name == null)
                throw new ArgumentNullException("The name is mandatory");

            var bar = new Bar
            {
                Name = barDTO.Name,
                Country = barDTO.Country,
                City = barDTO.City,
                Address = barDTO.Address,
                Phone = barDTO.Phone,
                Cocktails = barDTO.Cocktails,
                ImageURL = barDTO.ImageURL,
                CreatedOn = DateTime.UtcNow
            };

            await context.Bars.AddAsync(bar);
            await context.SaveChangesAsync();


            return bar;
        }

        public Task<Bar> Update(BarDTO bar)
        {
            throw new NotImplementedException();
        }
        public async Task<Bar> Delete(Guid? id)
        {
            var barToDelete = await this.context.Bars
                                 .Include(b => b.Cocktails)
                                 .FirstOrDefaultAsync(b => b.Id == id && b.IsDeleted == false) 
                                 ?? throw new ArgumentNullException();

            if (barToDelete.Cocktails.Any(c=>c.IsDeleted == true))
            {
                barToDelete.IsDeleted = true;
                barToDelete.ModifiedOn = DateTime.UtcNow;
                context.Bars.Update(barToDelete);
                await context.SaveChangesAsync();
            }
            else
            {
                throw new InvalidOperationException($"Cannot delete {barToDelete}" +
                    $"There are cocktails available.");
            }

            return barToDelete;
        }
    }
}
