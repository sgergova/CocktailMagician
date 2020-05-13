﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CocktailMagician.Data.Entities
{
   public  class CocktailStar
    {
        public Guid UserId { get; set; }
        public User User { get; set; }
        public Guid CocktailId { get; set; }
        public Cocktail Cocktail { get; set; }
        public bool Vote { get; set; }

    }
}
