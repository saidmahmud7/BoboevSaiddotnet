using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructore.Data;

public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
{
    public DbSet<User> Users { get; set; }
    public DbSet<Article> Articles { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<Subscription> Subscriptions { get; set; }
    public DbSet<Reaction> Reactions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
        .HasMany(u=>u.Subscriptions)
        .WithOne(s=>s.User);

        modelBuilder.Entity<User>()
        .HasMany(u=>u.Articles)
        .WithOne(a=>a.Author);

        modelBuilder.Entity<User>()
        .HasMany(u=>u.Comments)
        .WithOne(a=>a.User);

        modelBuilder.Entity<User>()
        .HasMany(u=>u.Reactions)
        .WithOne(a=>a.User);

        modelBuilder.Entity<Article>()
        .HasMany(u=>u.Comments)
        .WithOne(a=>a.Article);

        modelBuilder.Entity<Article>()
        .HasMany(u=>u.Reactions)
        .WithOne(a=>a.Article);
    }

}
