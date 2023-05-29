using Microsoft.Extensions.DependencyInjection;
using NorthWind.Sales.UseCases.CreateOrder;

namespace NorthWind.Sales.UseCases
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddUseCasesServices(this IServiceCollection services)
        {
            services.AddScoped<ICreateOrderInputPort, CreateOrderInteractor>();
            return services;
        }
    }
}
