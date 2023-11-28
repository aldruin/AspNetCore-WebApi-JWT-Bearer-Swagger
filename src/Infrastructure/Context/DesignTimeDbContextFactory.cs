using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace CashFlowAPI.Infrastructure.Context;
public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<CashFlowContext>
{
    public CashFlowContext CreateDbContext(string[] args)
    {
        var config = new ConfigurationBuilder()
            .AddEnvironmentVariables()
            .Build();

        var builder = new DbContextOptionsBuilder<CashFlowContext>();
        var connectionString = config.GetConnectionString("CashFlow");
        builder.UseSqlite("Data Source=CashFlowDb.db");
        Console.WriteLine(connectionString);
        return new CashFlowContext(builder.Options);
    }
}
