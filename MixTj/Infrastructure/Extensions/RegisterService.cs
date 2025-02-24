using Infrastructure.Data;
using Infrastructure.Seed;
using Infrastructure.Service.AuthService;
using Infrastructure.Service.CategoryService;
using Infrastructure.Service.ChannelService;
using Infrastructure.Service.CommentService;
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
        services.AddScoped<IAuthService,Service.AuthService.AuthService>();
        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<IVideoService, VideoService>();
        services.AddScoped<IChannelService, ChannelService>();
        services.AddScoped<ICommentService, CommentService>();




    }
}