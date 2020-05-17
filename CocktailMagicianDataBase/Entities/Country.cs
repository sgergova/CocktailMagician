using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CocktailMagician.Data.Entities
{
    public class Country
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        [Required]
        [StringLength(30, ErrorMessage = "The 'country's name cannot be more than 30 characters")]
        public string Name { get; set; }
        public ICollection<Bar> Bars { get; set; } = new List<Bar>();
        [DataType(DataType.Date)]
        public DateTime CreatedOn { get; set; }
        [DataType(DataType.Date)]
        public DateTime ModifiedOn { get; set; }
        [DataType(DataType.Date)]
        public DateTime DeletedOn { get; set; }
        public bool IsDeleted { get; set; }
    }
}
