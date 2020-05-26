using CocktailMagician.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CocktailMagician.Data.Seeder
{
    public static class RoleUserSeeder
    {
        public static void RoleUserStaticSeeder(this ModelBuilder builder)
        {
            builder.Entity<Role>().HasData(
              new Role { Id = Guid.Parse("c611672d-5da5-43d3-bbbf-e897e4456cb9"), Name = "Admin", NormalizedName = "ADMIN", ConcurrencyStamp = Guid.NewGuid().ToString() },
              new Role { Id = Guid.Parse("f476e48e-0586-4f40-92b2-2279ce6f6db7"), Name = "Magician", NormalizedName = "MEMBER", ConcurrencyStamp = Guid.NewGuid().ToString() },
              new Role { Id = Guid.Parse("01bc7e12-c30b-47d1-a0a0-b146bb93ccdb"), Name = "Crawler", NormalizedName = "CRAWLER", ConcurrencyStamp = Guid.NewGuid().ToString() }
          );
            var hasher = new PasswordHasher<User>();

            var user1 = new User
            {
                Id = Guid.Parse("5874617e-289f-4eb2-94ee-20b52faf67fa"),
                Email = "admin@abv.bg",
                NormalizedEmail = "ADMIN@ABV.BG",
                UserName = "admin@abv.bg",
                NormalizedUserName = "ADMIN@ABV.BG",
                SecurityStamp = "15CLJEKQCTLPRXMVXXNSWXZH6R6KJRRU"
            };
            user1.PasswordHash = hasher.HashPassword(user1, "admin");
            
            var user2 = new User
            {
                Id = Guid.Parse("baf374a9-0e81-4656-b0bb-16fe10985320"),
                NormalizedEmail = "magician@abv.bg",
                NormalizedUserName = "MAGICIAN@ABV.BG",
                Email = "magician@abv.bg",
                UserName = "MAGICIAN@ABV.BG",
                SecurityStamp = "7I5VNHIJTSZNOT3KDWKNFUV5PVYBHGXN"
            };
            user2.PasswordHash = hasher.HashPassword(user2, "magician");

            var user3 = new User
            {
                Id = Guid.Parse("4734cf2f-fcb8-461b-88dc-06152e89bc97"),
                NormalizedEmail = "crawler@abv.bg",
                NormalizedUserName = "CRAWLER@ABV.BG",
                Email = "crawler@abv.bg",
                UserName = "CRAWLER@ABV.BG",
                SecurityStamp = "7I5VNHIJTSZNOT3KDWKNFUV5PVYBHGXN"
            };
            user2.PasswordHash = hasher.HashPassword(user2, "crawler");

            builder.Entity<User>().HasData(user1, user2);

            builder.Entity<IdentityUserRole<Guid>>().HasData(
                new IdentityUserRole<Guid>
                {
                    RoleId = Guid.Parse("c611672d-5da5-43d3-bbbf-e897e4456cb9"),
                    UserId = Guid.Parse("5874617e-289f-4eb2-94ee-20b52faf67fa")
                });
            builder.Entity<IdentityUserRole<Guid>>().HasData(
                new IdentityUserRole<Guid>
                {
                    RoleId = Guid.Parse("f476e48e-0586-4f40-92b2-2279ce6f6db7"),
                    UserId = Guid.Parse("baf374a9-0e81-4656-b0bb-16fe10985320")
                });
            builder.Entity<IdentityUserRole<Guid>>().HasData(
               new IdentityUserRole<Guid>
               {
                   RoleId = Guid.Parse("01bc7e12-c30b-47d1-a0a0-b146bb93ccdb"),
                   UserId = Guid.Parse("4734cf2f-fcb8-461b-88dc-06152e89bc97")
               });
        }
    }
}
