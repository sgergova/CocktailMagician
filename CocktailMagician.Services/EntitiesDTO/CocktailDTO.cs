﻿using CocktailMagician.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CocktailMagician.Services.EntitiesDTO
{
    public class CocktailDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Rating { get; set; }
        public int RatingSum { get; set; }
        public int RatedCount { get; set; }
        public int AverageRating { get; set; }
        public double AlcoholPercentage { get; set; }
        public ICollection<string> IngredientNames { get; set; }
        public ICollection<CocktailIngredientDTO> Ingredients { get; set; }
        public ICollection<BarCocktailDTO> Bars { get; set; }
        public ICollection<BarRating> Stars { get; set; }
        public ICollection<CocktailCommentsDTO> Comments { get; set; }
        public bool IsAlcoholic { get; set; }
        public string ImageURL { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public DateTime? DeletedOn { get; set; }
        public bool IsDeleted { get; set; }
    }
}
