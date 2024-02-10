using Microsoft.Extensions.DependencyInjection;

namespace PostgresqlGemini.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(conf =>
            {
                conf.RegisterServicesFromAssemblies(typeof(DependencyInjection).Assembly);
            });
            
            //services.AddTransient(UserService);

            return services;
        }
    }
}
