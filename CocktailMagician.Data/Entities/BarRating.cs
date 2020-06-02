﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CocktailMagician.Data.Entities
{
    public class BarRating
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
        public Guid BarId { get; set; }
        public Bar Bar { get; set; }
        public int Rating { get; set; }
    }
}
