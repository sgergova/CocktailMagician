using CocktailMagician.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CocktailMagician.Data.Configuration
{
    public class CocktailIngredientConfig : IEntityTypeConfiguration<CocktailIngredient>
    {
        public void Configure(EntityTypeBuilder<CocktailIngredient> builder)
        {
           
            builder.HasKey(ci => new { ci.CocktailId, ci.IngredientId });
         
            builder.HasOne(ci => ci.Cocktail)
                .WithMany(c => c.CocktailIngredients)
                .HasForeignKey(ci => ci.CocktailId);

            builder.HasOne(ci => ci.Ingredient)
                .WithMany(i => i.CocktailIngredients)
                .HasForeignKey(ci => ci.IngredientId);
        }
    }
}
