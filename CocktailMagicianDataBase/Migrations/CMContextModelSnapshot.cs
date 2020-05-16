﻿// <auto-generated />
using System;
using CocktailMagician.DataBase.AppContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CocktailMagician.Data.Migrations
{
    [DbContext(typeof(CMContext))]
    partial class CMContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CocktailMagician.Data.Entities.Bar", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("ImageURL")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Bars");

                    b.HasData(
                        new
                        {
                            Id = new Guid("1fc708ed-edce-415d-9401-9987f4c7cd38"),
                            CreatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsDeleted = false,
                            Name = "American Bar",
                            Rating = 0
                        },
                        new
                        {
                            Id = new Guid("7b2fe070-1bb8-44fc-85d3-a790254cac1e"),
                            CreatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsDeleted = false,
                            Name = "The NoMad",
                            Rating = 0
                        },
                        new
                        {
                            Id = new Guid("6f1ba2d3-eb8d-49d2-b20e-31322f5d5997"),
                            CreatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsDeleted = false,
                            Name = "Drink Kong",
                            Rating = 0
                        },
                        new
                        {
                            Id = new Guid("d07e224e-eb3a-47a3-ada9-42692bdb467d"),
                            CreatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsDeleted = false,
                            Name = "Manhattan",
                            Rating = 0
                        },
                        new
                        {
                            Id = new Guid("6c10e839-351f-4f70-8a5f-147f65a396fa"),
                            CreatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsDeleted = false,
                            Name = "Connaught Bar",
                            Rating = 0
                        },
                        new
                        {
                            Id = new Guid("d0f5eb20-847f-4e98-8f10-a8f4b52f038f"),
                            CreatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsDeleted = false,
                            Name = "The Old Man",
                            Rating = 0
                        },
                        new
                        {
                            Id = new Guid("81bae617-ec16-4d86-aa90-37aa013d1bca"),
                            CreatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsDeleted = false,
                            Name = "Salmon Guru",
                            Rating = 0
                        },
                        new
                        {
                            Id = new Guid("8ef23bc5-7876-4337-84cb-ae69f1e9d38b"),
                            CreatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsDeleted = false,
                            Name = "Katana Kitten",
                            Rating = 0
                        },
                        new
                        {
                            Id = new Guid("bfba4312-00f1-4761-83ad-ae59e1bd5fd4"),
                            CreatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsDeleted = false,
                            Name = "Native",
                            Rating = 0
                        });
                });

            modelBuilder.Entity("CocktailMagician.Data.Entities.BarCocktail", b =>
                {
                    b.Property<Guid>("BarId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CocktailId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedOn")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<bool>("IsListed")
                        .HasColumnType("bit");

                    b.Property<DateTime>("ListedOn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("UnlistedOn")
                        .HasColumnType("datetime2");

                    b.HasKey("BarId", "CocktailId");

                    b.HasIndex("CocktailId");

                    b.ToTable("BarCocktails");
                });

            modelBuilder.Entity("CocktailMagician.Data.Entities.BarComment", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("BarId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Comments")
                        .IsRequired()
                        .HasColumnType("nvarchar(500)")
                        .HasMaxLength(500);

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedOn")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.HasKey("UserId", "BarId");

                    b.HasIndex("BarId");

                    b.ToTable("BarComments");
                });

            modelBuilder.Entity("CocktailMagician.Data.Entities.BarStar", b =>
                {
                    b.Property<Guid>("BarId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Vote")
                        .HasColumnType("bit");

                    b.HasKey("BarId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("BarStars");
                });

            modelBuilder.Entity("CocktailMagician.Data.Entities.Cocktail", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("AlcoholPercentage")
                        .HasColumnType("float");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("ImageURL")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsAlcoholic")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.Property<double>("Rating")
                        .HasColumnType("float");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Cocktails");

                    b.HasData(
                        new
                        {
                            Id = new Guid("619e984a-91ce-4948-bdcb-396e57739e1c"),
                            AlcoholPercentage = 3.3999999999999999,
                            CreatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsAlcoholic = false,
                            IsDeleted = false,
                            Name = "Bacardi",
                            Rating = 0.0
                        },
                        new
                        {
                            Id = new Guid("ea1a896c-c0cb-4767-bd3a-9af687b23e7d"),
                            AlcoholPercentage = 3.3999999999999999,
                            CreatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsAlcoholic = false,
                            IsDeleted = false,
                            Name = "Americano",
                            Rating = 0.0
                        },
                        new
                        {
                            Id = new Guid("ab6d63b7-cfb7-4b72-96e0-0e7d7098949e"),
                            AlcoholPercentage = 3.3999999999999999,
                            CreatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsAlcoholic = false,
                            IsDeleted = false,
                            Name = "Caipiroska",
                            Rating = 0.0
                        },
                        new
                        {
                            Id = new Guid("627dc490-c911-435a-be36-b05ebbc11059"),
                            AlcoholPercentage = 3.3999999999999999,
                            CreatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsAlcoholic = false,
                            IsDeleted = false,
                            Name = "Caipirinha",
                            Rating = 0.0
                        },
                        new
                        {
                            Id = new Guid("879e6c2f-e098-4d89-80ef-42b40207833c"),
                            AlcoholPercentage = 3.3999999999999999,
                            CreatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsAlcoholic = false,
                            IsDeleted = false,
                            Name = "Bramble",
                            Rating = 0.0
                        },
                        new
                        {
                            Id = new Guid("f77e91a0-06dc-42ff-bd13-16581efc8d45"),
                            AlcoholPercentage = 3.3999999999999999,
                            CreatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsAlcoholic = false,
                            IsDeleted = false,
                            Name = "Black Russian",
                            Rating = 0.0
                        },
                        new
                        {
                            Id = new Guid("72180b8c-e04e-4cbc-8b04-d2be913484fd"),
                            AlcoholPercentage = 3.3999999999999999,
                            CreatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsAlcoholic = false,
                            IsDeleted = false,
                            Name = "White Russian",
                            Rating = 0.0
                        },
                        new
                        {
                            Id = new Guid("7f6a0a9d-1bee-4885-84e2-0a3234ff8f54"),
                            AlcoholPercentage = 3.3999999999999999,
                            CreatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsAlcoholic = false,
                            IsDeleted = false,
                            Name = "Barracuda",
                            Rating = 0.0
                        },
                        new
                        {
                            Id = new Guid("d7aeeb26-98d0-4ebd-b521-561d9933f2c1"),
                            AlcoholPercentage = 3.3999999999999999,
                            CreatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsAlcoholic = false,
                            IsDeleted = false,
                            Name = "Bacardi",
                            Rating = 0.0
                        });
                });

            modelBuilder.Entity("CocktailMagician.Data.Entities.CocktailComment", b =>
                {
                    b.Property<Guid>("CocktailId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Comments")
                        .IsRequired()
                        .HasColumnType("nvarchar(500)")
                        .HasMaxLength(500);

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedOn")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.HasKey("CocktailId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("CocktailComments");
                });

            modelBuilder.Entity("CocktailMagician.Data.Entities.CocktailIngredient", b =>
                {
                    b.Property<Guid>("CocktailId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IngredientId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedOn")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.HasKey("CocktailId", "IngredientId");

                    b.HasIndex("IngredientId");

                    b.ToTable("CocktailIngredients");
                });

            modelBuilder.Entity("CocktailMagician.Data.Entities.CocktailStar", b =>
                {
                    b.Property<Guid>("CocktailId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Vote")
                        .HasColumnType("bit");

                    b.HasKey("CocktailId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("CocktailStars");
                });

            modelBuilder.Entity("CocktailMagician.Data.Entities.Ingredient", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<bool>("IsAlcoholic")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(40)")
                        .HasMaxLength(40);

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Ingredients");

                    b.HasData(
                        new
                        {
                            Id = new Guid("12246f7d-078c-4d86-b595-fbc93cf2bcc2"),
                            CreatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsAlcoholic = false,
                            IsDeleted = false,
                            Name = "Banana Daiquiri",
                            Quantity = 0,
                            Rating = 0
                        },
                        new
                        {
                            Id = new Guid("5ce2ef36-a896-40a9-af7d-638ddbf8f247"),
                            CreatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsAlcoholic = false,
                            IsDeleted = false,
                            Name = "Banana Juice",
                            Quantity = 0,
                            Rating = 0
                        },
                        new
                        {
                            Id = new Guid("c5513657-5edc-49d3-a105-99f5d10e6568"),
                            CreatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsAlcoholic = false,
                            IsDeleted = false,
                            Name = "Vodka",
                            Quantity = 0,
                            Rating = 0
                        },
                        new
                        {
                            Id = new Guid("3c1b452e-2201-42f0-af9d-f2666a368ebd"),
                            CreatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsAlcoholic = false,
                            IsDeleted = false,
                            Name = "Orange juice",
                            Quantity = 0,
                            Rating = 0
                        },
                        new
                        {
                            Id = new Guid("139afd66-a073-44cf-8383-2b7dc9c69623"),
                            CreatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsAlcoholic = false,
                            IsDeleted = false,
                            Name = "Whiskey",
                            Quantity = 0,
                            Rating = 0
                        },
                        new
                        {
                            Id = new Guid("476f7e58-9366-4275-97ad-9022cb2e7c19"),
                            CreatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsAlcoholic = false,
                            IsDeleted = false,
                            Name = "Coffee",
                            Quantity = 0,
                            Rating = 0
                        },
                        new
                        {
                            Id = new Guid("cfddb650-6e61-4019-b635-015f8521e832"),
                            CreatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsAlcoholic = false,
                            IsDeleted = false,
                            Name = "Gin",
                            Quantity = 0,
                            Rating = 0
                        },
                        new
                        {
                            Id = new Guid("cda274d2-7b0e-44c0-a145-02cba35ab7fd"),
                            CreatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsAlcoholic = false,
                            IsDeleted = false,
                            Name = "Campari",
                            Quantity = 0,
                            Rating = 0
                        },
                        new
                        {
                            Id = new Guid("4be96a90-1ae9-4403-b69c-d08ea053d3ba"),
                            CreatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsAlcoholic = false,
                            IsDeleted = false,
                            Name = "Rum",
                            Quantity = 0,
                            Rating = 0
                        });
                });

            modelBuilder.Entity("CocktailMagician.Data.Entities.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("CocktailMagician.Data.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("CocktailMagician.Data.Entities.Bar", b =>
                {
                    b.HasOne("CocktailMagician.Data.Entities.User", null)
                        .WithMany("Bars")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("CocktailMagician.Data.Entities.BarCocktail", b =>
                {
                    b.HasOne("CocktailMagician.Data.Entities.Bar", "Bar")
                        .WithMany("BarCocktails")
                        .HasForeignKey("BarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CocktailMagician.Data.Entities.Cocktail", "Cocktail")
                        .WithMany("Bars")
                        .HasForeignKey("CocktailId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CocktailMagician.Data.Entities.BarComment", b =>
                {
                    b.HasOne("CocktailMagician.Data.Entities.Bar", "Bar")
                        .WithMany("Comments")
                        .HasForeignKey("BarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CocktailMagician.Data.Entities.User", "User")
                        .WithMany("BarComments")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CocktailMagician.Data.Entities.BarStar", b =>
                {
                    b.HasOne("CocktailMagician.Data.Entities.Bar", "Bar")
                        .WithMany("Stars")
                        .HasForeignKey("BarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CocktailMagician.Data.Entities.User", "User")
                        .WithMany("BarStars")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CocktailMagician.Data.Entities.Cocktail", b =>
                {
                    b.HasOne("CocktailMagician.Data.Entities.User", null)
                        .WithMany("Cocktails")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("CocktailMagician.Data.Entities.CocktailComment", b =>
                {
                    b.HasOne("CocktailMagician.Data.Entities.Cocktail", "Cocktail")
                        .WithMany("Comments")
                        .HasForeignKey("CocktailId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CocktailMagician.Data.Entities.User", "User")
                        .WithMany("CocktailComments")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CocktailMagician.Data.Entities.CocktailIngredient", b =>
                {
                    b.HasOne("CocktailMagician.Data.Entities.Cocktail", "Cocktail")
                        .WithMany("CocktailIngredients")
                        .HasForeignKey("CocktailId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CocktailMagician.Data.Entities.Ingredient", "Ingredient")
                        .WithMany("CocktailIngredients")
                        .HasForeignKey("IngredientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CocktailMagician.Data.Entities.CocktailStar", b =>
                {
                    b.HasOne("CocktailMagician.Data.Entities.Cocktail", "Cocktail")
                        .WithMany("Stars")
                        .HasForeignKey("CocktailId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CocktailMagician.Data.Entities.User", "User")
                        .WithMany("CocktailStars")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.HasOne("CocktailMagician.Data.Entities.Role", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.HasOne("CocktailMagician.Data.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.HasOne("CocktailMagician.Data.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.HasOne("CocktailMagician.Data.Entities.Role", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CocktailMagician.Data.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.HasOne("CocktailMagician.Data.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
