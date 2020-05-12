using CocktailMagician.Data.Entities.Contracts;
using System;

namespace CocktailMagician.Data.Abstract
{
    public class EntitiesDetails : IEntitiesDetails
    {
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
        public DateTime? ModifiedOn { get; set; }
        public DateTime? DeletedOn { get; set; }
        public bool IsDeleted { get; set; }

    }
}
