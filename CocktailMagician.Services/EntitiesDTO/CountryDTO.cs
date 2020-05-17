using System;
using System.Collections.Generic;
using System.Text;

namespace CocktailMagician.Services.EntitiesDTO
{
   public class CountryDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<BarDTO> Bars { get; set; } = new List<BarDTO>();
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
       
        public DateTime DeletedOn { get; set; }
        public bool IsDeleted { get; set; }
    }
}
