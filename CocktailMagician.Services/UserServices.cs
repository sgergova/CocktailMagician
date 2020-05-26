using CocktailMagician.Data.Entities;
using CocktailMagician.Data.AppContext;
using CocktailMagician.Services.Contracts;
using CocktailMagician.Services.EntitiesDTO;
using CocktailMagician.Services.Mappers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CocktailMagician.Services
{
    public class UserServices : IUserServices
    {
        private readonly CMContext context;

        public UserServices(CMContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<UserDTO> UpdateUser(UserDTO userDTO)
        {
            var user = await this.context.Users
                                         .FirstOrDefaultAsync(u=>u.IsDeleted == false && u.Id == userDTO.Id)
                                         ?? throw new ArgumentNullException();

            user.UserName = userDTO.UserName;
            user.PhoneNumber = userDTO.PhoneNumber;
            user.Email = userDTO.Email;
            user.UserPhoto = userDTO.ProfilePicture;
            user.Bars = userDTO.Bars;
            user.BarComments = userDTO.BarComments;
            user.CocktailComments = userDTO.CocktailComments;
            user.Cocktails = userDTO.Cocktails;
            user.ModifiedOn = userDTO.ModifiedOn;
              
            this.context.Users.Update(user);
            await this.context.SaveChangesAsync();

            return user.GetDTO();
        }
       
    }
}
