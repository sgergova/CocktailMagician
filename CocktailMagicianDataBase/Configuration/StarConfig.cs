using CocktailMagician.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CocktailMagician.Data.Configuration
{
    //public Guid UserId { get; set; }
    //public User User { get; set; }
    //public Guid CocktailId { get; set; }
    //public Cocktail Cocktail { get; set; }
    //public Guid BarId { get; set; }
    //public Bar Bar { get; set; }
   
    public class StarConfig : IEntityTypeConfiguration<Star>
    {
        public void Configure(EntityTypeBuilder<Star> builder)
        {
            builder.HasOne(s => s.User)
                  .WithMany(u => u.Stars)
                  .HasForeignKey(s => s.UserId);

            builder.HasOne(s => s.Cocktail)
                .WithMany(c => c.Stars)
                .HasForeignKey(s => s.CocktailId);

            builder.HasOne(s => s.Bar)
                .WithMany(b => b.Stars)
                .HasForeignKey(s => s.BarId);
        }
    }
}
