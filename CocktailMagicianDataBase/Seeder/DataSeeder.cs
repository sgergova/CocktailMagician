using CocktailMagician.Data.Entities;
using CocktailMagician.DataBase.AppContext;
using CsvHelper;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CocktailMagician.Data.Seeder
{

    public static class DataSeeder
    {
        private const string data = @"data.csv";
        public static void Seeder(this ModelBuilder builder)
        {
            //var rawIngredients = ReadRawData();

            //var ingredients = CreateIngredients(rawIngredients);
            //builder.Entity<Ingredient>().HasData(ingredients);

            //var cocktails = CreateCocktails(rawIngredients);
            //builder.Entity<Cocktail>().HasData(cocktails);

            //var bars = CreateBars(rawIngredients);
            //builder.Entity<Bar>().HasData(bars);
        }

        private static List<Dictionary<string, string>> ReadRawData()
        {
            var ingredients = new List<Dictionary<string, string>>();

            using (TextFieldParser parser = new TextFieldParser(data))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");

                while (!parser.EndOfData)
                {
                    var ingredientRawData = new Dictionary<string, string>();
                    string[] fields = parser.ReadFields();

                    ingredientRawData.Add("Ingredient", fields[0]);
                    ingredientRawData.Add("Cocktail", fields[1]);
                    ingredientRawData.Add("AlcoholPercentage", fields[2]);
                    ingredientRawData.Add("Bar", fields[3]);

                    ingredients.Add(ingredientRawData);
                }
            }

            return ingredients;
        }

        private static List<Ingredient> CreateIngredients(List<Dictionary<string, string>> rawIngredients)
        {
           var ingredientNames = GetUniqueNames(rawIngredients, "Ingredient");
            var ingredients = new List<Ingredient>();
            var counter = 1;

            foreach (var ingredientName in ingredientNames)
            {
                var ingredient = new Ingredient()
                {
                    Id = Guid.NewGuid(),
                    Name = ingredientName,
                };
                counter++;
                ingredients.Add(ingredient);
            }

            return ingredients;
        }

        private static List<Cocktail> CreateCocktails(List<Dictionary<string, string>> rawIngredients)
        {
            //  var cocktailName = GetUniqueNames(rawIngredients, "Cocktail");

            var cocktails = new List<Cocktail>();
            var counter = 1;


            foreach (var item in rawIngredients)
            {
                var alcohol = double.Parse(item["AlcoholPercentage"]);

                var cocktail = new Cocktail()
                {
                    Id = Guid.NewGuid(),
                    Name = item["Cocktail"],
                    AlcoholPercentage = Math.Round(alcohol, 1)
                };
                counter++;
                cocktails.Add(cocktail);
            }

            return cocktails;
        }

        private static List<Bar> CreateBars(List<Dictionary<string, string>> rawIngredients)
        {
            var barNames = GetUniqueNames(rawIngredients, "Bar");
            var bars = new List<Bar>();
            var counter = 1;
            foreach (var name in barNames)
            {
                var bar = new Bar()
                {
                    Id = Guid.NewGuid(),
                    Name = name
                };
                counter++;
                bars.Add(bar);
            };
            return bars;
        }


        private static HashSet<string> GetUniqueNames(List<Dictionary<string, string>> rawIngredients, string nameKey)
        {
            var names = new HashSet<string>();

            foreach (var rawIngredient in rawIngredients)
            {
                names.Add(rawIngredient[nameKey]);
            }

            return names;
        }
    }
}
