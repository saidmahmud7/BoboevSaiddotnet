using Infrastructure.Data;
using Infrastructure.Profiles;
using Infrastructure.RegisterService;
using Infrastructure.Service.CourierService;
using Infrastructure.Service.MenuService;
using Infrastructure.Service.OrderService;
using Infrastructure.Service.ResturantService;
using Infrastructure.Service.UserService;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .WriteTo.File("Loggers/logs.txt", rollingInterval: RollingInterval.Day)
    .Filter.ByExcluding(logEvent =>
    {
        // Исключаем логи с категорией "Microsoft.EntityFrameworkCore.Database.Command"
        if (logEvent.Properties.TryGetValue("SourceContext", out var sourceContext))
        {
            var sourceContextValue = sourceContext.ToString();
            return sourceContextValue.Contains("Microsoft.EntityFrameworkCore.Database.Command");
        }
        return false;
    })
    .CreateLogger();

builder.Host.UseSerilog();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.RegisterServices(builder.Configuration);
builder.Services.AddAutoMapper(typeof(InfrastructureProfile));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();
app.UseHttpsRedirection();
app.Run();


