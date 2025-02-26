using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class DataContext(DbContextOptions<DataContext> options ) : DbContext(options)
{
    public DbSet<Order> Orders { get; set; }
}