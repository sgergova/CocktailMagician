using System;
using System.Collections.Generic;
using System.Text;

namespace CocktailMagician.Data.Entities.Contracts
{
    public interface IEntitiesDetails
    {
        DateTime CreatedOn { get; set; }
        DateTime? ModifiedOn { get; set; }
        DateTime? DeletedOn { get; set; }
        bool IsDeleted { get; set; }
    }
}
