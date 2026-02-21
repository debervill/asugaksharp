using Microsoft.Extensions.DependencyInjection;

namespace asugaksharp.Features.Komissiya;

public static class KomissiyaServiceCollectionExtensions
{
    public static IServiceCollection AddKomissiyaFeatures(this IServiceCollection services)
    {
        services.AddTransient<GetPersonsByKafedraHandler>();
        services.AddTransient<GetGaksByKafedraHandler>();
        services.AddTransient<GetGakKomissiyaHandler>();
        services.AddTransient<SaveGakKomissiyaHandler>();
        services.AddTransient<KomissiyaWindow>();
        return services;
    }
}
