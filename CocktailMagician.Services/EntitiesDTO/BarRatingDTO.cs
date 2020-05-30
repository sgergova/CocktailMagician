using CocktailMagician.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CocktailMagician.Services.EntitiesDTO
{
    public class BarRatingDTO
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
        public Guid BarId { get; set; }
        public Bar Bar { get; set; }
        public int Rating { get; set; }
    }
}
