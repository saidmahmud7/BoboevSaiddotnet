using Infrastructure.Data;
using Infrastructure.Service.CourierService;
using Infrastructure.Service.MenuService;
using Infrastructure.Service.OrderService;
using Infrastructure.Service.ResturantService;
using Infrastructure.Service.UserService;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.RegisterService;

public static class RegisterServiceClass
{
    public static void RegisterServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IResturantService, ResturantService>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IMenuService, MenuService>();
        services.AddScoped<IOrderService, OrderService>();
        services.AddScoped<ICourierService, CourierService>();
        services.AddDbContext<DataContext>(opt => 
            opt.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));
    }
}