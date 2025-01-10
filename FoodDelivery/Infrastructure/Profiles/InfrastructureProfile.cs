using AutoMapper;
using Domain.DTO_s.CourierDto;
using Domain.DTO_s.MenuDto;
using Domain.DTO_s.OrderDetailDto;
using Domain.DTO_s.OrderDto;
using Domain.DTO_s.ResturantDto;
using Domain.DTO_s.UserDto;
using Domain.Entities;

namespace Infrastructure.Profiles;

public class InfrastructureProfile : Profile
{
    public InfrastructureProfile()
    {
        CreateMap<CreateResturantDto, Restaurant>();
        CreateMap<Restaurant, GetResturantDto>()
            .ForMember(dest => dest.Menus, opt => opt.MapFrom(src => src.Menus));

        CreateMap<CreateMenuDto, Menu>();
        CreateMap<Menu, GetMenuDto>();

        CreateMap<CreateCourierDto, Courier>();
        CreateMap<Courier, GetCourierDto>();
        CreateMap<Courier, GetFiveTopCourier>();

        CreateMap<CreateUserDto, User>();
        CreateMap<User, GetUserDto>();

        CreateMap<CreateOrderDto, Order>();
        CreateMap<Order, GetOrderDto>();
        CreateMap<Order,GetTotalAmountToday>();
        CreateMap<Order, GetExepensiveOrders>();

        CreateMap<CreateOrderDetailDto, OrderDetail>();
        CreateMap<OrderDetail, GetOrderDetailDto>();
    }
}