using Infrastructure.Data;
using Infrastructure.Seed;
using Infrastructure.Service.AuthServices;
using Infrastructure.Service.CategoryService;
using Infrastructure.Service.ChannelService;
using Infrastructure.Service.CommentService;
using Infrastructure.Service.SubscriptionService;
using Infrastructure.Service.VideoService;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Extensions;

public static class RegisterService
{
    public static void AddServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<Seeder>();
        services.AddDbContext<DataContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("Default")));
        services.AddScoped<IAuthService, Service.AuthServices.AuthService>();
        
    }
}