using CocktailMagician.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CocktailMagician.Data.Configuration
{
    public class CocktailConfig : IEntityTypeConfiguration<Cocktail>
    {
        public void Configure(EntityTypeBuilder<Cocktail> builder)
        {
            builder.HasMany(c => c.Ingredients)
                    .WithOne(i => i.Cocktail)
                    .HasForeignKey(i => i.CocktailId);

            builder.HasMany(c => c.Bars)
                .WithOne(bc => bc.Cocktail)
                .HasForeignKey(bc => bc.CocktailId);

            builder.HasMany(c => c.Stars)
                .WithOne(s => s.Cocktail)
                .HasForeignKey(s => s.CocktailId);

            builder.HasMany(c => c.Comments)
                .WithOne(cc => cc.Cocktail)
                .HasForeignKey(cc => cc.CocktailId);
        }
    }
}
