using Microsoft.EntityFrameworkCore;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PostgresqlGemini.Application.Abstraction.Clock;
using PostgresqlGemini.Domain.Abstraction;
using PostgresqlGemini.Domain.Features.User;
using PostgresqlGemini.Infrastructure.Clock;
using PostgresqlGemini.Infrastructure.Repositories;

namespace PostgresqlGemini.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {

            string connectionString = configuration.GetConnectionString("DefaultConnection") ??
                                      throw new ArgumentNullException(nameof(configuration));
            services.AddTransient<IDateTimeProvider, DateTimeProvider>();

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ITestDataRepository, TestDataRepository>();

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseNpgsql(connectionString).UseSnakeCaseNamingConvention());

            services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<ApplicationDbContext>());

            return services;
        }
    }
}
