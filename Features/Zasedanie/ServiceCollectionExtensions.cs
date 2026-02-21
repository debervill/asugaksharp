using Microsoft.Extensions.DependencyInjection;

namespace asugaksharp.Features.Zasedanie;

public static class ZasedanieServiceCollectionExtensions
{
    public static IServiceCollection AddZasedanieFeatures(this IServiceCollection services)
    {
        services.AddTransient<GetZasedaniesHandler>();
        services.AddTransient<CreateZasedanieHandler>();
        services.AddTransient<UpdateZasedanieHandler>();
        services.AddTransient<DeleteZasedanieHandler>();
        services.AddTransient<ZasedanieWindow>();
        return services;
    }
}
