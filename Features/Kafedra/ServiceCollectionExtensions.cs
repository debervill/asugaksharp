using Microsoft.Extensions.DependencyInjection;

namespace asugaksharp.Features.Kafedra;

public static class KafedraServiceCollectionExtensions
{
    public static IServiceCollection AddKafedraFeatures(this IServiceCollection services)
    {
        services.AddTransient<GetKafedrasHandler>();
        services.AddTransient<CreateKafedraHandler>();
        services.AddTransient<UpdateKafedraHandler>();
        services.AddTransient<DeleteKafedraHandler>();
        services.AddTransient<KafedraWindow>();
        return services;
    }
}
