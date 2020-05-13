﻿using CocktailMagician.Services.EntitiesDTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CocktailMagician.Services.Contracts
{
   public interface ICocktailServices
    {
        Task<CocktailDTO> GetCocktail(Guid id);
        Task<ICollection<CocktailDTO>> GetAllCocktails();
        Task<CocktailDTO> CreateCocktail(CocktailDTO barDTO);
        Task<CocktailDTO> UpdateCocktail(CocktailDTO barDTO);
        Task<CocktailDTO> DeleteCocktail(Guid id);
    }
}