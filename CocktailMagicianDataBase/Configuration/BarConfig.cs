using CocktailMagician.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CocktailMagician.Data.Configuration
{
    public class BarConfig : IEntityTypeConfiguration<Bar>
    {
        public void Configure(EntityTypeBuilder<Bar> builder)
        {
            builder.HasMany(b => b.Comments)
                .WithOne(bc => bc.Bar)
                .HasForeignKey(bc=>bc.BarId);

            builder.HasMany(b => b.BarCocktails)
                .WithOne(bc => bc.Bar)
                .HasForeignKey(bc=>bc.BarId);

            builder.HasMany(b => b.Stars)
                .WithOne(s => s.Bar)
                .HasForeignKey(s => s.BarId);
        }
    }
}
