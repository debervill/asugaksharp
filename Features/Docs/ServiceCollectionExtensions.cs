using Microsoft.Extensions.DependencyInjection;

namespace asugaksharp.Features.Docs;

public static class DocsServiceCollectionExtensions
{
    public static IServiceCollection AddDocsFeatures(this IServiceCollection services)
    {
        services.AddTransient<GetDocsHandler>();
        services.AddTransient<CreateDocsHandler>();
        services.AddTransient<UpdateDocsHandler>();
        services.AddTransient<DeleteDocsHandler>();
        services.AddSingleton<DocumentGenerator>();
        services.AddTransient<GenerateDocumentHandler>();
        services.AddTransient<DocsWindow>();
        return services;
    }
}
