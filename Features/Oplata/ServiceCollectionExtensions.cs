using Microsoft.Extensions.DependencyInjection;

namespace asugaksharp.Features.Oplata;

public static class OplataServiceCollectionExtensions
{
    public static IServiceCollection AddOplataFeatures(this IServiceCollection services)
    {
        services.AddTransient<GetOplatasHandler>();
        services.AddTransient<CreateOplataHandler>();
        services.AddTransient<UpdateOplataHandler>();
        services.AddTransient<DeleteOplataHandler>();
        services.AddTransient<GetGakInfoHandler>();
        services.AddTransient<GetGakExternalMembersHandler>();
        services.AddTransient<GetOplatasByGakHandler>();
        services.AddTransient<SaveOplatasByGakHandler>();
        services.AddTransient<OplataWindow>();
        return services;
    }
}
