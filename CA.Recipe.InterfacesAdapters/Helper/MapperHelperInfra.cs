using AutoMapper;
using CA.Recipe.Application.Services.Port;
using CA.Recipe.FrameworksDrivers.Data.Recipe;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CA.Recipe.InterfacesAdapters.Helper
{
    public class MapperHelperInfra
    {
        internal static IMapper mapper;

        static MapperHelperInfra()
        {
            var config = new MapperConfiguration(x =>
            {
                x.CreateMap<FrameworksDrivers.Data.Recipe.Recipe, RecipeDetailResponse>()
                .ForMember(dest => dest.Portions, opt => opt.MapFrom(src => src.Portion))
                .ForMember(dest => dest.Steps, opt => opt.MapFrom(src => src.Step))
                .ForMember(dest => dest.Author, opt => opt.MapFrom(src => src.User.UserName))
                .ForMember(dest => dest.Portions, opt => opt.MapFrom(src => src.Portion))
                .ForMember(dest => dest.Score, opt => opt.MapFrom(src => GetScore(src.Score.ToList())))
                .ForMember(dest =>dest.Ingredients, opt => opt.MapFrom(src => MapIngredients(src.Amount.ToList())));

                x.CreateMap<FrameworksDrivers.Data.Recipe.Recipe, RecipeCoverResponse>()
                .ForMember(dest => dest.Score, opt => opt.MapFrom(src => GetScore(src.Score.ToList())))
                .ForMember(dest => dest.Author, opt => opt.MapFrom(src => src.User.UserName));

                x.CreateMap<RecipeRequest, FrameworksDrivers.Data.Recipe.Recipe>()
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Step, opt => opt.MapFrom(src => src.Steps))
                .ForMember(dest => dest.Portion, opt => opt.MapFrom(src => src.Portions))
                .ForMember(dest => dest.ImageUrl, opt => opt.MapFrom(src => src.Image))
                .ForMember(dest => dest.Amount, opt => opt.MapFrom(src => MapIngredientsAmount(src.Ingredients)));

                x.CreateMap<User, UserResponseDB>()
                .ForMember(dest => dest.id, opt => opt.MapFrom(src => src.UserId))
                .ForMember(dest => dest.username, opt => opt.MapFrom(src => src.UserName))
                .ForMember(dest => dest.email, opt => opt.MapFrom(src => src.Email));

                x.CreateMap<UserRequest, User>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.username))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.email))
                .ForMember(dest => dest.UserType, opt => opt.MapFrom(src => 2))
                .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.password))
                .ForMember(dest => dest.Active, opt => opt.MapFrom(src => true));

                x.CreateMap<Ingredient, IngredientResponseDB>()
                .ForMember(dest => dest.id, opt => opt.MapFrom(src => src.IngredientId));

                x.CreateMap<WatchLater, RecipeCoverResponse>()
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Recipe.Title))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Recipe.Description))
                .ForMember(dest => dest.ImageUrl, opt => opt.MapFrom(src => src.Recipe.ImageUrl))
                .ForMember(dest => dest.Author, opt => opt.MapFrom(src => src.Recipe.User.UserName))
                .ForMember(dest => dest.Score, opt => opt.MapFrom(src => GetScore(src.Recipe.Score.ToList())));
            });

            mapper = config.CreateMapper();
        }

        public static T Map<T>(object source)
        {
            return mapper.Map<T>(source);
        }

        private static float GetScore(List<Score> scores)
        {
            int finalScore = 0;
            if (scores.Count == 0)
                return 0;
            foreach (var score in scores)
            {
                finalScore += score.Score1;
            }
            return (float)(Math.Truncate((double)((double)finalScore / (double)scores.Count) * 100.0) / 100.0);
        }

        private static List<IngredientAmount> MapIngredients(List<Amount> ingredients)
        {
            var mapped = new List<IngredientAmount>();
            foreach (var ingredient in ingredients)
            {
                mapped.Add(new IngredientAmount
                {
                    IngredientIdId = ingredient.IngredientId,
                    Name = ingredient.Ingredient.Name,
                    Amount = ingredient.Amount1
                });
            }
            return mapped;
        }

        private static List<Amount> MapIngredientsAmount(List<IngredientRequest> ingredientLst)
        {
            var ingredients = new List<Amount>();
            foreach (var item in ingredientLst)
            {
                ingredients.Add(new Amount
                {
                    Amount1 = item.Amount,
                    IngredientId = item.IngredientId
                });
            }
            return ingredients;
        }
    }
}