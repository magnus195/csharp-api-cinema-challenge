using AutoMapper;

namespace api_cinema_challenge.Mapper;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<Models.Customer, DTO.CustomerResponse>();
        CreateMap<Models.Movie, DTO.MovieResponse>();

        CreateMap<DTO.CustomerPost, Models.Customer>();
        CreateMap<DTO.MoviePost, Models.Movie>();
    }
}