using Microsoft.Extensions.DependencyInjection;

namespace asugaksharp.Features.PeriodZasedania;

public static class PeriodZasedaniaServiceCollectionExtensions
{
    public static IServiceCollection AddPeriodZasedaniaFeatures(this IServiceCollection services)
    {
        services.AddTransient<GetPeriodZasedaniasHandler>();
        services.AddTransient<CreatePeriodZasedaniaHandler>();
        services.AddTransient<UpdatePeriodZasedaniaHandler>();
        services.AddTransient<DeletePeriodZasedaniaHandler>();
        services.AddTransient<PeriodZasedaniaWindow>();
        return services;
    }
}
