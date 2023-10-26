using CashFlowAPI.Domain.Interfaces;
using CashFlowAPI.Infrastructure.Context;
using CashFlowAPI.Infrastructure.Data;
using CashFlowAPI.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CashFlowAPI.Infrastructure;
public static class ConfigurationModule
{
    public static IServiceCollection RegisterRepository(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<CashFlowContext>(x =>
        {
            x.UseSqlite(connectionString);
        });

        services.AddScoped(typeof(Repository<>));
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<ISheetRepository, SheetRepository>();
        services.AddScoped<IFinancialEntryRepository, FinancialEntryRepository>();
        services.AddScoped<IFinancialExpenseRepository, FinancialExpenseRepository>();

        return services;
    }
}