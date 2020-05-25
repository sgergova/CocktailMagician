using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CocktailMagician.Web.Models
{
    public class CocktailIngredient
    {
       public ICollection<Guid> Id { get; set; }
       public MultiSelectList Ingredients { get; set; }
    }
}
