using Microsoft.Extensions.DependencyInjection;

namespace Core.Mediator
{
    public static class MediatorConfig
    {
        public static void AddMediatorHandlerConfiguration(this IServiceCollection services)
        {
            services.AddScoped<IMediatorHandler, MediatorHandler>();
        }
    }
}
