using Hangfire;
using Hangfire.PostgreSql;
using Infrastructure.BackgroundTasks;
using Infrastructure.Data;
using Infrastructure.Repository;
using Infrastructure.Service;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DataContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("Default")));

builder.Services.AddHangfire(config =>
    config.UsePostgreSqlStorage(builder.Configuration.GetConnectionString("Default")));
builder.Services.AddHangfireServer();

builder.Services.AddScoped<MyHangFireService>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IOrderService, OrderService>();

var app = builder.Build();

try
{
    using var scope = app.Services.CreateScope();
    var serviceProvider = scope.ServiceProvider;

    var dataContext = serviceProvider.GetRequiredService<DataContext>();
    await dataContext.Database.MigrateAsync();

    var recurringJobManager = serviceProvider.GetRequiredService<IRecurringJobManager>();
    recurringJobManager.AddOrUpdate<MyHangFireService>(
        "check-time",
        service => service.CheckTime(),
        "0,30 * * * *"
    );
}
catch (Exception e)
{
    Console.WriteLine($"Ошибка при запуске: {e.Message}");
    throw;
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHangfireDashboard();
app.UseRouting();
app.MapControllers();
app.Run();