﻿using CocktailMagician.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CocktailMagician.Data.Configuration
{
    
    public class BarRatingConfig : IEntityTypeConfiguration<BarRating>
    {
        public void Configure(EntityTypeBuilder<BarRating> builder)
        {
            builder.HasKey(bs=>new { bs.BarId, bs.UserId, bs.Id });

            builder.HasOne(bs => bs.User)
                  .WithMany(u => u.BarRatings)
                  .HasForeignKey(bs => bs.UserId);


            builder.HasOne(bs => bs.Bar)
                .WithMany(b => b.BarRating)
                .HasForeignKey(bs => bs.BarId);
        }
    }
}
