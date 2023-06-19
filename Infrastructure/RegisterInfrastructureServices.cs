using Application;
using Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class RegisterInfrastructureServices
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(dbContextOption =>
        dbContextOption.UseNpgsql(configuration.GetConnectionString("AppDbContextConnection")));

        return services;
    }
}