using asugaksharp.Presentation.Forms;
using Microsoft.Extensions.DependencyInjection;

namespace asugaksharp.Presentation
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPresentation(this IServiceCollection services)
        {
            // ✅ Регистрация главной формы - ВАЖНО: Transient, чтобы каждый раз создавалась новая
            services.AddTransient<MainForm>();

            // ✅ Регистрация других форм
            services.AddTransient<KafedraForm>();

            // TODO: Добавить другие формы по мере необходимости
            // services.AddTransient<PersonForm>();
            // services.AddTransient<DiplomnikForm>();

            return services;
        }
    }
}