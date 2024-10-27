using System;
using HepsiAPI.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HepsiAPI.Persistence;

// Registration.cs
public static class Registration
{
    public static void AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        var mysqlPassword = Environment.GetEnvironmentVariable("MYSQL_PASSWORD");
        var connectionString = configuration.GetConnectionString("DefaultConnection") + $"Password={mysqlPassword};";

        services.AddDbContext<AppDbContext>(options =>
        {
            var serverVersion = new MySqlServerVersion(new Version(8, 0, 39));
            options.UseMySql(connectionString, serverVersion);
        });
    }
}

