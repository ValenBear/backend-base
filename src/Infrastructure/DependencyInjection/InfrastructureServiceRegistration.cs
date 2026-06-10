using Domain.Interfaces;
using Infrastructure.Persistence;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.DependencyInjection;

public static class InfrastructureServiceRegistration
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        // Cambiamos a InMemory para el template base para evitar depender de un SQL Server
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseInMemoryDatabase("BoletasDepositoDb"));

        services.AddScoped<IItemRepository, ItemRepository>();

        return services;
    }
}
