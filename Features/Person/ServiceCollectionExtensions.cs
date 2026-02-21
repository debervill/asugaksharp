using Microsoft.Extensions.DependencyInjection;

namespace asugaksharp.Features.Person;

public static class PersonServiceCollectionExtensions
{
    public static IServiceCollection AddPersonFeatures(this IServiceCollection services)
    {
        services.AddTransient<GetPersonsHandler>();
        services.AddTransient<CreatePersonHandler>();
        services.AddTransient<UpdatePersonHandler>();
        services.AddTransient<DeletePersonHandler>();
        services.AddTransient<GetPersonalDataHandler>();
        services.AddTransient<UpdatePersonalDataHandler>();
        services.AddTransient<PersonWindow>();
        return services;
    }
}
