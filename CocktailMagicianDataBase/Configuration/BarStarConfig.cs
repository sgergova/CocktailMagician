using CocktailMagician.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CocktailMagician.Data.Configuration
{
    
    public class BarStarConfig : IEntityTypeConfiguration<BarStar>
    {
        public void Configure(EntityTypeBuilder<BarStar> builder)
        {
            builder.HasKey(bs=>new { bs.BarId, bs.UserId});

            builder.HasOne(bs => bs.User)
                  .WithMany(u => u.BarStars)
                  .HasForeignKey(bs => bs.UserId);


            builder.HasOne(bs => bs.Bar)
                .WithMany(b => b.Stars)
                .HasForeignKey(bs => bs.BarId);
        }
    }
}
