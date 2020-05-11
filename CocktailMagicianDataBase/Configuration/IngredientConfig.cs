using CocktailMagician.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CocktailMagician.Data.Configuration
{
    public class IngredientConfig : IEntityTypeConfiguration<Ingredient>
    {
        public void Configure(EntityTypeBuilder<Ingredient> builder)
        {

            //public ICollection<CocktailIngredient> CocktailIngredients { get; set; }

            builder.HasMany(i => i.CocktailIngredients)
                    .WithOne(ci => ci.Ingredient)
                    .HasForeignKey(ci => ci.IngredientId);

        }
    }
}
