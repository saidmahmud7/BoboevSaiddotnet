using Microsoft.EntityFrameworkCore;

public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
{
    public DbSet<Order> Users { get; set; }
}