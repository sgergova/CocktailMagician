using CocktailMagician.Services.Contracts;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CocktailMagician.Data.Common.FileFormats;

namespace CocktailMagician.Services
{
    public class UploadImagesServices : IUploadImagesServices
    {
        public ImageFormat GetImageFormat(byte[] bytes)
        {
            var gif = Encoding.ASCII.GetBytes("GIF");    
            var png = new byte[] { 137, 80, 78, 71 };              
            var jpeg = new byte[] { 255, 216, 255, 224 };         
            var jpeg2 = new byte[] { 255, 216, 255, 225 };         

            if (gif.SequenceEqual(bytes.Take(gif.Length)))
                return ImageFormat.gif;

            if (png.SequenceEqual(bytes.Take(png.Length)))
                return ImageFormat.png;

            if (jpeg.SequenceEqual(bytes.Take(jpeg.Length)))
                return ImageFormat.jpeg;

            if (jpeg2.SequenceEqual(bytes.Take(jpeg2.Length)))
                return ImageFormat.jpeg;

            return ImageFormat.unknown;
        }

        private bool CheckFile(IFormFile file)
        {
            byte[] fileBytes;
            using (var memoryStream = new MemoryStream())
            {
                file.CopyTo(memoryStream);
                fileBytes = memoryStream.ToArray();
            }

            return GetImageFormat(fileBytes) != ImageFormat.unknown;
        }
        public async Task<string> UploadImage(IFormFile file)
        {
            if (CheckFile(file))
            {
                return await SaveFile(file);
            }

            return "Invalid image file";
        }

        public async Task<string> SaveFile(IFormFile file)
        {
            string fileName;
            try
            {
                var extension = "." + file.FileName.Split('.')[file.FileName.Split('.').Length - 1];
                var folder = System.IO.Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images");
                fileName = Guid.NewGuid().ToString() + extension; //Create a new Name 
                                                                  //for the file due to security reasons.
                var path = Path.Combine(folder, fileName);
                string location = $"/images/{fileName}";


                using (var bits = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(bits);
                }
                fileName = location;
            }
            catch (Exception e)
            {
                return e.Message;
            }

            return fileName;
        }
    }
}


