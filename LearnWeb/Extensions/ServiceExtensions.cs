using LearnWeb.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Sample.GameManagement.Contracts;

namespace LearnWeb.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(name:"AnyPolicy",
                    configurePolicy:builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });
        }

        public static void ConfigureMySqlContext(this IServiceCollection services,IConfiguration config)
        {
            var connectionString = config.GetConnectionString("GameDb");
            services.AddDbContext<GameManagementDbContext>(
                builder => builder.UseMySql(connectionString,MySqlServerVersion.LatestSupportedServerVersion)
                ) ;
        }

        public static void ConfigureRepositoryWrapper(this IServiceCollection services)
        {
            services.AddScoped<IRepositoryWrapper,RepositoryWrapper>();
        }


    }
}
