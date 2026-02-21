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
using asugaksharp.Features.TestData;

namespace asugaksharp;

public partial class App : Application
{
    public static IServiceProvider ServiceProvider { get; private set; } = null!;

    public App()
    {
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

    private static void ConfigureServices(IServiceCollection services)
    {
        // Infrastructure
        services.AddDbContext<AppDbContext>(options =>
            options.UseSqlite("Data Source=asugak.db"));

        // Features
        services.AddKafedraFeatures();
        services.AddPersonFeatures();
        services.AddDiplomnikFeatures();
        services.AddGakFeatures();
        services.AddZasedanieFeatures();
        services.AddPeriodZasedaniaFeatures();
        services.AddNapravleniePodgotovkiFeatures();
        services.AddProfilPodgotovkiFeatures();
        services.AddOplataFeatures();
        services.AddDocsFeatures();
        services.AddKomissiyaFeatures();
        services.AddTestDataFeatures();
    }
}
