using CocktailMagician.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CocktailMagician.Data.Configuration
{
    public class CocktailCommentConfig : IEntityTypeConfiguration<CocktailComment>
    {
        public void Configure(EntityTypeBuilder<CocktailComment> builder)
        {
            builder.HasOne(cc => cc.User)
                .WithMany(u => u.CocktailComments)
                .HasForeignKey(cc => cc.UserId);

            builder.HasOne(cc => cc.Cocktail)
                .WithMany(c => c.Comments)
                .HasForeignKey(cc => cc.CocktailId);
        }
    }
}
