using Microsoft.Extensions.DependencyInjection;
//using asugaksharp.ApplicationLayer.Interface;
//using asugaksharp.ApplicationLayer.Services;
using asugaksharp.Presentation;



namespace asugaksharp
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            // Регистрируем все сервисы
            //services.AddScoped<IKafedraService, KafedraService>();
            // Добавьте остальные сервисы:
            // services.AddScoped<IFacultyService, FacultyService>();
            // services.AddScoped<IStudentService, StudentService>();
            // services.AddScoped<ITeacherService, TeacherService>();
            // и т.д.

            return services;
        }

        public static IServiceCollection AddPresentationForms(this IServiceCollection services)
        {
            // Регистрируем все формы
            services.AddTransient<MainForm>();
            services.AddTransient<MainWindowForm>();
            //services.AddTransient<KafedraForms>();
           

            return services;
        }
    }
}