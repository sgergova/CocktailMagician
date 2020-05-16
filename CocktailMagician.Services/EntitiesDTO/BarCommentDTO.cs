using CocktailMagician.Data.Entities;
using System;

namespace CocktailMagician.Services.EntitiesDTO
{
    public class BarCommentDTO 
    {
        public Guid Id { get; set; }
        public string Comments { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
        public Guid BarId { get; set; }
        public Bar Bar { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public DateTime? DeletedOn { get; set; }
        public bool IsDeleted { get; set; }
    }
}
