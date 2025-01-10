using Infrastructure.Data;
using Infrastructure.Profiles;
using Infrastructure.RegisterService;
using Infrastructure.Service.CourierService;
using Infrastructure.Service.MenuService;
using Infrastructure.Service.OrderService;
using Infrastructure.Service.ResturantService;
using Infrastructure.Service.UserService;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

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


