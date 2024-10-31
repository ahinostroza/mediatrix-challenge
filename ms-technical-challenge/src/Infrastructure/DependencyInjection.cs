namespace SB.TechnicalChallenge.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("ConnectionEntity");

        _ = services.AddScoped<EntityInterceptor>();

        _ = services.AddDbContext<ApplicationDbContext>(m =>
                m.UseMySQL(connectionString)
                .EnableDetailedErrors()
                .AddInterceptors(new EntityInterceptor())
            );

        _ = services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        _ = services.AddScoped<IUnitOfWork, UnitOfWork>();
        _ = services.AddScoped<IMemoryCacheService, MemoryCacheService>();
        _ = services.AddScoped<IHttpService, HttpService>();

        return services;
    }
}
