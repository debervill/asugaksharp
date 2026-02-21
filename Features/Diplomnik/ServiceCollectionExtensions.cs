using Microsoft.Extensions.DependencyInjection;

namespace asugaksharp.Features.Diplomnik;

public static class DiplomnikServiceCollectionExtensions
{
    public static IServiceCollection AddDiplomnikFeatures(this IServiceCollection services)
    {
        services.AddTransient<GetDiplomniksHandler>();
        services.AddTransient<CreateDiplomnikHandler>();
        services.AddTransient<UpdateDiplomnikHandler>();
        services.AddTransient<DeleteDiplomnikHandler>();
        services.AddTransient<DiplomnikWindow>();
        return services;
    }
}
