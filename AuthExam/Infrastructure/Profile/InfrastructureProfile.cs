using Domain.DTO_s;
using Domain.Entities;

namespace Infrastructure.Profile;

public class InfrastructureProfile : AutoMapper.Profile
{
    public InfrastructureProfile()
    {
        CreateMap<CreateBookingDto, Booking>();
        CreateMap<Booking, GetBookingDto>();

        CreateMap<CreateWorkoutDto, Workout>();
        CreateMap<Workout, GetWorkoutDto>();

        CreateMap<User, GetUsersDto>();
    }
}