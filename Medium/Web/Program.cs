using System.Text;
using Microsoft.EntityFrameworkCore;
using auth.Services.AuthServices;
using Microsoft.OpenApi.Models;
using Infrastructore.Data;
using Infrastructore.Profiles;
using Infrastructore.Services.UserServices;
using Infrastructore.Services.CommentServices;
using Infrastructore.Services.ReactionServices;
using Infrastructore.Services.ArticleServices;
using Infrastructore.Services.SubscriptionServices;
using Microsoft.AspNetCore.Identity;
using Infrastructore.Repositories.IRepositories;
using Infrastructore.Repositories.RepositoryServices;
using Domain.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen(c =>
{
    var securityScheme = new OpenApiSecurityScheme()
    {
        BearerFormat = "JWT",
        Scheme = "Bearer",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Description = "JWT Authorization header using the Bearer scheme \r\n\r\n" +
                      "Example:\"Bearer token\" "
    };

    var securityRequirement = new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] { }
        }
    };
    c.AddSecurityDefinition("Bearer", securityScheme);
    c.AddSecurityRequirement(securityRequirement);
});

builder.Services.AddControllers();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ICommentService, CommentService>();
builder.Services.AddScoped<IReactionService, ReactionService>();
builder.Services.AddScoped<IArticleService, ArticleService>();
builder.Services.AddScoped<ISubscriptionService, SubscriptionService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IArticleRepository,ArticleRepository>();
builder.Services.AddScoped<ICommentRepository,CommentRepository>();
builder.Services.AddScoped<IUserRepository<User>,UserRepository>();
builder.Services.AddScoped<IReactionRepository,ReactionRepository>();
builder.Services.AddScoped<ISubscriptionRepository,SubscriptionRepository>();
builder.Services.AddDbContext<DataContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddAutoMapper(typeof(MapperProfile));
builder.Services.AddIdentity<IdentityUser,IdentityRole>()
.AddEntityFrameworkStores<DataContext>()
.AddDefaultTokenProviders();

builder.Services.AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(options =>
    {
        options.RequireHttpsMetadata = true;
        options.SaveToken = true;
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = builder.Configuration["JWT:Issuer"],
            ValidateAudience = true,
            ValidAudience = builder.Configuration["JWT:Audience"],
            ValidateLifetime = true,
            ClockSkew = TimeSpan.Zero,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:key"]!))
        };
    });
builder.Services.AddAuthorization();

var app = builder.Build();

app.MapOpenApi();
app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();