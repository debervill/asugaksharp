using Microsoft.Extensions.DependencyInjection;

namespace asugaksharp.Features.ProfilPodgotovki;

public static class ProfilPodgotovkiServiceCollectionExtensions
{
    public static IServiceCollection AddProfilPodgotovkiFeatures(this IServiceCollection services)
    {
        services.AddTransient<GetProfilPodgotovkisHandler>();
        services.AddTransient<CreateProfilPodgotovkiHandler>();
        services.AddTransient<UpdateProfilPodgotovkiHandler>();
        services.AddTransient<DeleteProfilPodgotovkiHandler>();
        services.AddTransient<ProfilPodgotovkiWindow>();
        return services;
    }
}
