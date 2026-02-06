using System.Globalization;
using System.Windows;
using System.Windows.Markup;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using asugaksharp.Infrastructure.Persistence;
using asugaksharp.Features.Kafedra;
using asugaksharp.Features.Person;
using asugaksharp.Features.Diplomnik;
using asugaksharp.Features.Gak;
using asugaksharp.Features.Zasedanie;
using asugaksharp.Features.PeriodZasedania;
using asugaksharp.Features.NapravleniePodgotovki;
using asugaksharp.Features.ProfilPodgotovki;
using asugaksharp.Features.Oplata;
using asugaksharp.Features.Docs;
using asugaksharp.Features.Komissiya;

namespace asugaksharp;

public partial class App : Application
{
    public static IServiceProvider ServiceProvider { get; private set; } = null!;

    public App()
    {
        // Устанавливаем русскую культуру (запятая как разделитель дробной части)
        var culture = new CultureInfo("ru-RU");
        CultureInfo.DefaultThreadCurrentCulture = culture;
        CultureInfo.DefaultThreadCurrentUICulture = culture;
        FrameworkElement.LanguageProperty.OverrideMetadata(
            typeof(FrameworkElement),
            new FrameworkPropertyMetadata(XmlLanguage.GetLanguage(culture.IetfLanguageTag)));

        var services = new ServiceCollection();
        ConfigureServices(services);
        ServiceProvider = services.BuildServiceProvider();
    }

    private void ConfigureServices(IServiceCollection services)
    {
        services.AddDbContext<AppDbContext>(options =>
            options.UseSqlite("Data Source=asugak.db"));

        // Kafedra
        services.AddTransient<GetKafedrasHandler>();
        services.AddTransient<CreateKafedraHandler>();
        services.AddTransient<UpdateKafedraHandler>();
        services.AddTransient<DeleteKafedraHandler>();

        // Person
        services.AddTransient<GetPersonsHandler>();
        services.AddTransient<CreatePersonHandler>();
        services.AddTransient<UpdatePersonHandler>();
        services.AddTransient<DeletePersonHandler>();
        services.AddTransient<GetPersonalDataHandler>();
        services.AddTransient<UpdatePersonalDataHandler>();

        // Diplomnik
        services.AddTransient<GetDiplomniksHandler>();
        services.AddTransient<CreateDiplomnikHandler>();
        services.AddTransient<UpdateDiplomnikHandler>();
        services.AddTransient<DeleteDiplomnikHandler>();

        // Gak
        services.AddTransient<GetGaksHandler>();
        services.AddTransient<CreateGakHandler>();
        services.AddTransient<UpdateGakHandler>();
        services.AddTransient<DeleteGakHandler>();

        // Zasedanie
        services.AddTransient<GetZasedaniesHandler>();
        services.AddTransient<CreateZasedanieHandler>();
        services.AddTransient<UpdateZasedanieHandler>();
        services.AddTransient<DeleteZasedanieHandler>();

        // PeriodZasedania
        services.AddTransient<GetPeriodZasedaniasHandler>();
        services.AddTransient<CreatePeriodZasedaniaHandler>();
        services.AddTransient<UpdatePeriodZasedaniaHandler>();
        services.AddTransient<DeletePeriodZasedaniaHandler>();

        // NapravleniePodgotovki
        services.AddTransient<GetNapravleniePodgotovkisHandler>();
        services.AddTransient<CreateNapravleniePodgotovkiHandler>();
        services.AddTransient<UpdateNapravleniePodgotovkiHandler>();
        services.AddTransient<DeleteNapravleniePodgotovkiHandler>();

        // ProfilPodgotovki
        services.AddTransient<GetProfilPodgotovkisHandler>();
        services.AddTransient<CreateProfilPodgotovkiHandler>();
        services.AddTransient<UpdateProfilPodgotovkiHandler>();
        services.AddTransient<DeleteProfilPodgotovkiHandler>();

        // Oplata
        services.AddTransient<GetOplatasHandler>();
        services.AddTransient<CreateOplataHandler>();
        services.AddTransient<UpdateOplataHandler>();
        services.AddTransient<DeleteOplataHandler>();
        services.AddTransient<GetGakInfoHandler>();
        services.AddTransient<GetGakExternalMembersHandler>();
        services.AddTransient<GetOplatasByGakHandler>();
        services.AddTransient<SaveOplatasByGakHandler>();

        // Docs
        services.AddTransient<GetDocsHandler>();
        services.AddTransient<CreateDocsHandler>();
        services.AddTransient<UpdateDocsHandler>();
        services.AddTransient<DeleteDocsHandler>();
        services.AddSingleton<DocumentGenerator>();
        services.AddTransient<GenerateDocumentHandler>();

        // Komissiya
        services.AddTransient<GetPersonsByKafedraHandler>();
        services.AddTransient<GetGaksByKafedraHandler>();
        services.AddTransient<GetGakKomissiyaHandler>();
        services.AddTransient<SaveGakKomissiyaHandler>();

        // Windows
        services.AddTransient<Features.Kafedra.KafedraWindow>();
        services.AddTransient<Features.Person.PersonWindow>();
        services.AddTransient<Features.Diplomnik.DiplomnikWindow>();
        services.AddTransient<Features.Gak.GakWindow>();
        services.AddTransient<Features.Zasedanie.ZasedanieWindow>();
        services.AddTransient<Features.PeriodZasedania.PeriodZasedaniaWindow>();
        services.AddTransient<Features.NapravleniePodgotovki.NapravleniePodgotovkiWindow>();
        services.AddTransient<Features.ProfilPodgotovki.ProfilPodgotovkiWindow>();
        services.AddTransient<Features.Oplata.OplataWindow>();
        services.AddTransient<Features.Oplata.OplataManagementWindow>();
        services.AddTransient<Features.Docs.DocsWindow>();
        services.AddTransient<Features.Komissiya.KomissiyaWindow>();
    }
}