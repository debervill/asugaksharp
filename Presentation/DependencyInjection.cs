using asugaksharp.Presentation;
using Microsoft.Extensions.DependencyInjection;

namespace asugaksharp.Presentation
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPresentation(this IServiceCollection services)
        {
            // ✅ Регистрация форм
            services.AddTransient<MainForm>();

            // TODO: Добавить остальные формы по мере необходимости
            // services.AddTransient<KafedraListForm>();
            // services.AddTransient<DiplomnikListForm>();

            return services;
        }
    }
}