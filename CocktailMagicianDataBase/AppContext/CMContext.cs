using CocktailMagician.Data.Configuration;
using CocktailMagician.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CocktailMagician.DataBase.AppContext
{
    public class CMContext : IdentityDbContext<User,Role,Guid>
    {
        public CMContext(DbContextOptions<CMContext> options) : base(options)
        {
        }
        
        public DbSet<Bar> Bars { get; set; }
        public DbSet<Cocktail> Cocktails { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }

        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new BarCocktailConfig());
            builder.ApplyConfiguration(new BarCommentConfig());
            builder.ApplyConfiguration(new BarConfig());
            builder.ApplyConfiguration(new CocktailCommentConfig());
            builder.ApplyConfiguration(new CocktailConfig());
            builder.ApplyConfiguration(new IngredientConfig());
            builder.ApplyConfiguration(new StarConfig());
            base.OnModelCreating(builder);
        }
    }
}
