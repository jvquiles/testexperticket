using Microsoft.Extensions.DependencyInjection;
using testexperticket.Persistence.Repositories.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace testexperticket.Persistence.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddUserRepository(this IServiceCollection services, IConfiguration configuration )
        {
            services.AddDbContext<UserContext>(builder =>
            {
                // switch(configuration.GetSection("DatabaseType"))
                // {
                // case InMemory:
                builder.UseInMemoryDatabase("UserDatabase");
                // break;
                // case ...:
                // ...
                // break;
                // }
            });
            
            return services;
        }
    }
}