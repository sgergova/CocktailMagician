using System;
using System.Collections.Generic;
using System.Text;

namespace CocktailMagician.Data.Entities
{
  public class UserProfilePicture
    {
        public Guid Id { get; set; }
        public byte[] UserCover { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
    }
}
