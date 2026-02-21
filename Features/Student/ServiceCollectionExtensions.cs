using Microsoft.Extensions.DependencyInjection;

namespace asugaksharp.Features.Student;

public static class StudentServiceCollectionExtensions
{
    public static IServiceCollection AddStudentFeatures(this IServiceCollection services)
    {
        services.AddTransient<GetStudentsHandler>();
        services.AddTransient<CreateStudentHandler>();
        services.AddTransient<UpdateStudentHandler>();
        services.AddTransient<DeleteStudentHandler>();
        services.AddTransient<StudentWindow>();
        return services;
    }
}
