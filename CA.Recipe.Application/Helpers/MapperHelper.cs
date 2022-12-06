using AutoMapper;
using CA.Recipe.Application.Services.Port;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.Recipe.Application.Helpers
{
    public class MapperHelper
    {
        internal static IMapper mapper;

        static MapperHelper()
        {
            var config = new MapperConfiguration(x =>
            {
                x.CreateMap<IngredientResponseDB, IngredientResponse>().
                        ForMember(dest => dest.IngredientId, opt => opt.MapFrom(src => src.id)).ReverseMap();

                x.CreateMap<UserResponseDB, UserResponse>().ReverseMap();

                x.CreateMap<UserResponseDB, UserGetResponse>()
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.email));
            });

            mapper = config.CreateMapper();
        }

        public static T Map<T>(object source)
        {
            return mapper.Map<T>(source);
        }
    }
}
