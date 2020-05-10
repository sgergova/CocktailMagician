using CocktailMagician.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CocktailMagician.DataBase.AppContext
{
    public class CMContext : DbContext
    {
        public CMContext(DbContextOptions<CMContext> options) : base(options)
        {
        }

    }
}
