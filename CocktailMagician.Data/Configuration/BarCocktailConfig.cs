using CocktailMagician.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CocktailMagician.Data.Configuration
{
    public class BarCocktailConfig : IEntityTypeConfiguration<BarCocktail>
    {
        public void Configure(EntityTypeBuilder<BarCocktail> builder)
        {
            builder.HasKey(bc=> new { bc.BarId, bc.CocktailId });

            builder.HasOne(bc => bc.Bar)
                    .WithMany(b => b.BarCocktails)
                    .HasForeignKey(bc => bc.BarId);

            builder.HasOne(bc => bc.Cocktail)
                .WithMany(c => c.Bars)
                .HasForeignKey(bc => bc.BarId);
        }
    }
}
