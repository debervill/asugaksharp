//using asugaksharp.Core.Interfaces;
using asugaksharp.Infrastructure.Persistanse;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace asugaksharp.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            // DbContext уже зарегистрирован в Program.cs

            /*
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IKafedraRepository, KafedraRepository>();
            services.AddScoped<IDiplomnikRepository, DiplomnikRepository>();
            services.AddScoped<IPersonRepository, PersonRepository>();
            services.AddScoped<IGakRepository, GakRepository>();
            services.AddScoped<IDocsRepository, DocsRepository>();
            services.AddScoped<IOplataRepository, OplataRepository>();
            services.AddScoped<IPeriodZasedaniaRepository, PeriodZasedaniaRepository>();
            services.AddScoped<IZasedanieRepository, ZasedanieRepository>();
            services.AddScoped<INapravleniePodgotovkiRepository, NapravleniePodgotovkiRepository>();
            services.AddScoped<IProfilPodgotovkiRepository, ProfilPodgotovkiRepository>();
            */
            return services;
        }
    }
}