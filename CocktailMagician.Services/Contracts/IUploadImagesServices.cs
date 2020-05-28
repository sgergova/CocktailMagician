using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CocktailMagician.Services.Contracts
{
    public interface IUploadImagesServices
    {
        Task<string> UploadImage(IFormFile file);
     }
}
