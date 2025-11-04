
//using asugaksharp.ApplicationLayer.Services;
using Microsoft.Extensions.DependencyInjection;

namespace asugaksharp.ApplicationLayer
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            // ✅ Сервисы
            //services.AddScoped<IKafedraService, KafedraService>();
            /*
            services.AddScoped<IDiplomnikService, DiplomnikService>();
            services.AddScoped<IPersonService, PersonService>();
            services.AddScoped<IGakService, GakService>();
            services.AddScoped<IOplataService, OplataService>();
            services.AddScoped<IPeriodZasedaniaService, PeriodZasedaniaService>();
            services.AddScoped<IZasedanieService, ZasedanieService>();
            services.AddScoped<INapravleniePodgotovkiService, NapravleniePodgotovkiService>();
            services.AddScoped<IProfilPodgotovkiService, ProfilPodgotovkiService>();

            // ✅ Генерация документов
            services.AddScoped<IDocumentGenerationService, DocumentGenerationService>();
            */
            return services;
        }
    }
}