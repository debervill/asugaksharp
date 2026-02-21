using Microsoft.Extensions.DependencyInjection;

namespace asugaksharp.Features.TestData;

public static class TestDataServiceCollectionExtensions
{
    public static IServiceCollection AddTestDataFeatures(this IServiceCollection services)
    {
        services.AddTransient<SeedTestDataHandler>();
        return services;
    }
}
