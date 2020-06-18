using Microsoft.Extensions.DependencyInjection;
using MediatR;
using testexperticket.Core.Messages;
using testexperticket.Persistence.Extensions;
using testexperticket.Core.Services;
using Microsoft.Extensions.Configuration;

namespace testexperticket.Core.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddMessageManager(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediatR(typeof(MessageBroker));
            services.AddUserRepository(configuration);
            services.AddScoped<IUserService, UserService>();

            return services;
        }
    }
}