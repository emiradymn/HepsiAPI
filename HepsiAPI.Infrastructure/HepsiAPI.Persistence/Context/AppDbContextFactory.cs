using HepsiAPI.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
{
    public AppDbContext CreateDbContext(string[]? args = null)
    {
        var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
        var mysqlPassword = Environment.GetEnvironmentVariable("MYSQL_PASSWORD");
        var connectionString = $"Server=localhost;Database=HepsiAPIDb;User=root;Password={mysqlPassword};";
        var serverVersion = new MySqlServerVersion(new Version(8, 0, 39));

        optionsBuilder.UseMySql(connectionString, serverVersion);

        return new AppDbContext(optionsBuilder.Options);
    }
}
