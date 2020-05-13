using CocktailMagician.Data.Entities;
using CocktailMagician.DataBase.AppContext;
using CocktailMagician.Services.EntitiesDTO;
using CocktailMagician.Services.Mappers;
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

        public async Task<BarDTO> Get(Guid id)
        {
            var entity = await GetAllBars()
                                .FirstOrDefaultAsync(e => e.Id == id);

            return entity.GetBarDTO();

        }

        public async Task<ICollection<BarDTO>> GetAll()
        {
            var entities = await GetAllBars().ToListAsync();

            return entities.GetBarDTOs();
        }

        public async Task<BarDTO> Create(BarDTO barDTO)
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

            return bar.GetBarDTO();
        }

        public async Task<BarDTO> Update(BarDTO barDTO)
        {
            if (barDTO.Id == null)
                throw new ArgumentNullException("Value cannot be null.");

            var barToUpdate = await Get(barDTO.Id);
            var bar = barToUpdate.GetBarEntity();

            bar.Name = barDTO.Name;
            bar.Address = barDTO.Address;
            bar.City = barDTO.City;
            bar.Phone = barDTO.Phone;
            bar.ImageURL = barDTO.ImageURL;

            this.context.Update(bar);
            await this.context.SaveChangesAsync();

            return bar.GetBarDTO();

        }
        public async Task<BarDTO> Delete(Guid? id)
        {
            var barToDelete = await this.context.Bars
                                 .Include(b => b.Cocktails)
                                 .FirstOrDefaultAsync(b => b.Id == id && b.IsDeleted == false)
                                 ?? throw new ArgumentNullException();

            if (barToDelete.Cocktails.Any(c => c.IsDeleted == true))
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

            return barToDelete.GetBarDTO();
        }

        private IQueryable<Bar> GetAllBars()
        {
            var entities = this.context.Bars
                                       .Where(b => b.IsDeleted == false)
                                       ?? throw new ArgumentNullException("The value cannot be null");

            return entities;
        }
    }
}
