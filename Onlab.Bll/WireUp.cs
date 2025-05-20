using Microsoft.Extensions.DependencyInjection;

namespace Onlab.Bll
{
    public static class WireUp
    {

        public static IServiceCollection AddBllServices(this IServiceCollection services)
        {
            services.AddScoped<IBandService, BandService>();
            services.AddScoped<IUserService, UserService>();

            return services;
        }
    }
}
