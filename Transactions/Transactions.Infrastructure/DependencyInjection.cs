using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Transactions.Infrastructure.Interfaces;

namespace Transactions.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistence(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<TransactionsDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("TransactionsDb"),
            b => b.MigrationsAssembly(typeof(TransactionsDbContext).Assembly.FullName)), ServiceLifetime.Transient);

        services.AddScoped<ITransactionsDbContext>(provider => provider.GetService<TransactionsDbContext>());
        return services;
    }
}
