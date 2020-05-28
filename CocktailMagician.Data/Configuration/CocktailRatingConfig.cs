using CocktailMagician.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CocktailMagician.Data.Configuration
{
    public class CocktailRatingConfig : IEntityTypeConfiguration<CocktailRating>
    {
        public void Configure(EntityTypeBuilder<CocktailRating> builder)
        {
            builder.HasKey(cs=> new { cs.CocktailId, cs.UserId});

            builder.HasOne(cs => cs.User)
                   .WithMany(u => u.CocktailStars)
                   .HasForeignKey(cs => cs.UserId);

            builder.HasOne(cs => cs.Cocktail)
                   .WithMany(c => c.CocktailRatings)
                   .HasForeignKey(cs => cs.CocktailId);

        }
    }
}
