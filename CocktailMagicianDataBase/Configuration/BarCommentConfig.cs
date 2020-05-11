using CocktailMagician.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CocktailMagician.Data.Configuration
{
    class BarCommentConfig : IEntityTypeConfiguration<BarComment>
    {
        
        public void Configure(EntityTypeBuilder<BarComment> builder)
        {
            builder.HasOne(bc => bc.User)
                 .WithMany(u => u.BarComments)
                 .HasForeignKey(bc => bc.UserId);

            builder.HasOne(bc => bc.Bar)
                .WithMany(b => b.Comments)
                .HasForeignKey(bc => bc.BarId);
        }
    }
}
