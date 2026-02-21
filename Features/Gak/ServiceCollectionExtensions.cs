using Microsoft.Extensions.DependencyInjection;

namespace asugaksharp.Features.Gak;

public static class GakServiceCollectionExtensions
{
    public static IServiceCollection AddGakFeatures(this IServiceCollection services)
    {
        services.AddTransient<GetGaksHandler>();
        services.AddTransient<CreateGakHandler>();
        services.AddTransient<UpdateGakHandler>();
        services.AddTransient<DeleteGakHandler>();
        services.AddTransient<GakWindow>();
        return services;
    }
}
