using System.Data.Common;
using Microsoft.EntityFrameworkCore;
using MVC1.Models;

namespace MVC1.Data;

public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
{
    public DbSet<UserModel> Users {get;set;}
}
