using System.Data.Common;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using OrderDetail = Infrastructure.Service.OrderDetail;

namespace Infrastructure.Data;

public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
{
    public DbSet<Restaurant> Resturants { get; set; }
    public DbSet<Menu> Menus { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Domain.Entities.OrderDetail> OrderDetails { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Courier> Couriers { get; set; }
}

