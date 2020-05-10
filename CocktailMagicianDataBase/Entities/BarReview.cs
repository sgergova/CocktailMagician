using System;
using System.Collections.Generic;
using System.Text;

namespace CocktailMagician.Data.Entities
{
    public class BarReview
    {
        public  Guid Id { get; set; }
        public User UserName { get; set; }
        public  Guid UserId { get; set; }
        public  Guid BarId { get; set; }
        public Bar BarName { get; set; }
    }
}
