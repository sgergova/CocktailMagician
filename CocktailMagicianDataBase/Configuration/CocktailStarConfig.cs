using CocktailMagician.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CocktailMagician.Data.Configuration
{
    public class CocktailStarConfig : IEntityTypeConfiguration<CocktailStar>
    {
        public void Configure(EntityTypeBuilder<CocktailStar> builder)
        {
            builder.HasKey(cs=> new { cs.CocktailId, cs.UserId});

            builder.HasOne(cs => cs.User)
                   .WithMany(u => u.CocktailStars)
                   .HasForeignKey(cs => cs.UserId);

            builder.HasOne(cs => cs.Cocktail)
                   .WithMany(c => c.Stars)
                   .HasForeignKey(cs => cs.CocktailId);

        }
    }
}
