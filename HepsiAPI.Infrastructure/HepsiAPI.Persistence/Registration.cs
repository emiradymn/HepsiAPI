using System;
using HepsiAPI.Application.Interfaces.Repositories;
using HepsiAPI.Application.UnitOfWorks;
using HepsiAPI.Persistence.Context;
using HepsiAPI.Persistence.Repositories;
using HepsiAPI.Persistence.UnitOfWorks;
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

        services.AddScoped(typeof(IReadRepository<>), typeof(ReadRepository<>));  // DI yapısı
        services.AddScoped(typeof(IWriteRepository<>), typeof(WriteRepository<>));

        services.AddScoped<IUnitOfWork, UnitOfWork>();
    }
}

