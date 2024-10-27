using System;
using System.Reflection;
using HepsiAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HepsiAPI.Persistence.Context;
public class AppDbContext : DbContext
{
    public AppDbContext()
    {

    }
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Brand> Brands { get; set; }
    public DbSet<Detail> Details { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
