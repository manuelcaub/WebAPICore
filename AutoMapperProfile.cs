namespace WebAPICore
{
    using AutoMapper;
    using Data;
    using Models;

    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserModel>().ReverseMap();
            CreateMap<Product, ProductModel>()
            .ForMember(dest => dest.Type, opts => opts.MapFrom(src => src.Type.Name))
            .ReverseMap()
            .ForMember(dest => dest.Type, opts => opts.Ignore());
        }
    }
}