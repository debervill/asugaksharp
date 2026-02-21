using Microsoft.Extensions.DependencyInjection;

namespace asugaksharp.Features.NapravleniePodgotovki;

public static class NapravleniePodgotovkiServiceCollectionExtensions
{
    public static IServiceCollection AddNapravleniePodgotovkiFeatures(this IServiceCollection services)
    {
        services.AddTransient<GetNapravleniePodgotovkisHandler>();
        services.AddTransient<CreateNapravleniePodgotovkiHandler>();
        services.AddTransient<UpdateNapravleniePodgotovkiHandler>();
        services.AddTransient<DeleteNapravleniePodgotovkiHandler>();
        services.AddTransient<NapravleniePodgotovkiWindow>();
        return services;
    }
}
