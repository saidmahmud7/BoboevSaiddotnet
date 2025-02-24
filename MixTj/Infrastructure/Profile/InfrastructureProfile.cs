using Domain.Dtos.CategoryDto;
using Domain.Dtos.ChannelDto;
using Domain.Entities;

namespace Infrastructure.Profile;

public class InfrastructureProfile : AutoMapper.Profile
{
    public InfrastructureProfile()
    {
        CreateMap<AddCategoryDto, Category>();
        CreateMap<Category, GetCategoryDto>();
        
        CreateMap<AddChannelDto, Channel>();
        CreateMap<Channel, GetChannelDto>();
    }
}