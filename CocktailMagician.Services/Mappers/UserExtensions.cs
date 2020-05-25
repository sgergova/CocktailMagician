using CocktailMagician.Data.Entities;
using CocktailMagician.Services.EntitiesDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CocktailMagician.Services.Mappers
{
    public static class UserExtensions
    {
        public static UserDTO GetDTO(this User user)
        {
            return new UserDTO
            {
                Id = user.Id,
                UserName = user.UserName,
                PhoneNumber = user.PhoneNumber,
                Email = user.Email,
                ProfilePicture = user.UserPhoto,
                Bars = user.Bars,
                BarComments = user.BarComments,
                CocktailComments = user.CocktailComments,
                Cocktails = user.Cocktails,
                CreatedOn = user.CreatedOn,
                ModifiedOn = user.ModifiedOn,
                IsDeleted = user.IsDeleted, 
                DeletedOn = user.DeletedOn,
            };
        }

        public static ICollection<UserDTO> GetDTOs(this ICollection<User> users)
        {
            return users.Select(GetDTO).ToList();
        }


    }
}
