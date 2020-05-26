using CocktailMagician.Data.Configuration;
using CocktailMagician.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using CocktailMagician.Data.Seeder;

namespace CocktailMagician.Data.AppContext
{
    public class CMContext : IdentityDbContext<User,Role,Guid>
    {
        public CMContext(DbContextOptions<CMContext> options) : base(options)
        {
        }
        
        public DbSet<Bar> Bars { get; set; }
        public DbSet<Cocktail> Cocktails { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<BarCocktail> BarCocktails { get; set; }
        public DbSet<BarComment> BarComments { get; set; }
        public DbSet<BarRating> BarStars { get; set; }
        public DbSet<CocktailComment> CocktailComments { get; set; }
        public DbSet<CocktailIngredient> CocktailIngredients { get; set; }
        public DbSet<CocktailRating> CocktailStars { get; set; }
        public DbSet<Country> Countries { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new BarCocktailConfig());
            builder.ApplyConfiguration(new BarCommentConfig());
            builder.ApplyConfiguration(new BarConfig());
            builder.ApplyConfiguration(new CocktailCommentConfig());
            builder.ApplyConfiguration(new CocktailConfig());
            builder.ApplyConfiguration(new IngredientConfig());
            builder.ApplyConfiguration(new BarStarConfig());
            builder.ApplyConfiguration(new CocktailIngredientConfig());
            builder.ApplyConfiguration(new CocktailStarConfig());
            builder.ApplyConfiguration(new CountryConfig());

            builder.Seeder();
            base.OnModelCreating(builder);
        }
    }
}
