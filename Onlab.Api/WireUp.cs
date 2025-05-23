using Microsoft.Extensions.DependencyInjection;

namespace Onlab.Api
{
    public static class WireUp
    {

        public static void AddApiClientServices(this IServiceCollection services)
        {
            services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("MyApi"));

            services.AddHttpClient<IBandsClient, BandsClient>("MyApi");
            
            services.AddHttpClient<IUsersClient, UsersClient>("MyApi");

            services.AddHttpClient<ISetlistsClient, SetlistsClient>("MyApi");

            services.AddHttpClient<IConcertsClient, ConcertsClient>("MyApi");

            services.AddHttpClient<ITaskItemsClient, TaskItemsClient>("MyApi");
        }
    }
}