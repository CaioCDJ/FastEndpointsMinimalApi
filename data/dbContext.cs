
using Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.data;


public class AppDbContext : DbContext{

    public DbSet<User> users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite("DataSource=app.db;Cache=Shared");

}