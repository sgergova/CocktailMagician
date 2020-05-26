using CocktailMagician.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CocktailMagician.Data.Seeder
{

    public static class DataSeeder
    {
        private const string data = @"data.csv";
        public static void Seeder(this ModelBuilder builder)
        {
            var rawIngredients = ReadRawData();

            var ingredients = CreateIngredients(rawIngredients);
            builder.Entity<Ingredient>().HasData(ingredients);

            var cocktails = CreateCocktails(rawIngredients);
            builder.Entity<Cocktail>().HasData(cocktails);

            var countries = CreateCountries(rawIngredients);
            builder.Entity<Country>().HasData(countries);

            var bars = CreateBars(rawIngredients, countries);
            builder.Entity<Bar>().HasData(bars);
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
                    ingredientRawData.Add("ImageURL", fields[2]);
                    ingredientRawData.Add("AlcoholPercentage", fields[3]);
                    ingredientRawData.Add("Bar", fields[4]);
                    ingredientRawData.Add("BarImageURL", fields[5]);
                    ingredientRawData.Add("Country", fields[6]);


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
                    CreatedOn = DateTime.UtcNow,
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
                var image = item["ImageURL"];

                var cocktail = new Cocktail()
                {
                    Id = Guid.NewGuid(),
                    Name = item["Cocktail"],
                    AlcoholPercentage = Math.Round(alcohol, 1),
                    ImageURL = image,
                    CreatedOn = DateTime.UtcNow,

                };
                counter++;
                cocktails.Add(cocktail);
            }

            return cocktails;
        }


        private static List<Country> CreateCountries(List<Dictionary<string, string>> rawIngredients)
        {
            var countryNames = GetUniqueNames(rawIngredients, "Country");
            var countries = new List<Country>();
            var counter = 1;

            foreach (var countryName in countryNames)
            {
                var country = new Country()
                {
                    Id = Guid.NewGuid(),
                    Name = countryName,
                    CreatedOn = DateTime.UtcNow,
                };
                counter++;
                countries.Add(country);
            }

            return countries;
        }

        private static List<Bar> CreateBars(List<Dictionary<string, string>> rawIngredients, List<Country> countries)
        {
            var barNames = new HashSet<string>();
            var bars = new List<Bar>();
            var counter = 1;
            foreach (var rawIngredient in rawIngredients)
            {

                var country = countries.Where(country => country.Name == rawIngredient["Country"]).First();

                var bar = new Bar()
                {
                    Id = Guid.NewGuid(),
                    Name = rawIngredient["Bar"],
                    BarImageURL = rawIngredient["BarImageURL"],
                    CountryId = country.Id,
                    CreatedOn = DateTime.UtcNow,
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
