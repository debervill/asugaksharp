using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using asugaksharp.Features.Kafedra;
using asugaksharp.Features.NapravleniePodgotovki;
using asugaksharp.Features.ProfilPodgotovki;
using asugaksharp.Features.Person;
using asugaksharp.Features.Diplomnik;
using asugaksharp.Features.Student;
using asugaksharp.Features.PeriodZasedania;
using asugaksharp.Features.Gak;
using asugaksharp.Features.Zasedanie;
using asugaksharp.Features.Oplata;
using asugaksharp.Features.Docs;
using asugaksharp.Features.Komissiya;
using asugaksharp.Features.TestData;
using asugaksharp.Features.Help;

namespace asugaksharp;

public partial class MainWindows : Window
{
    public MainWindows()
    {
        InitializeComponent();
    }

    // Feature windows
    private void MenuKafedra_Click(object sender, RoutedEventArgs e) => ShowWindow<KafedraWindow>();
    private void MenuNapravlenie_Click(object sender, RoutedEventArgs e) => ShowWindow<NapravleniePodgotovkiWindow>();
    private void MenuPerson_Click(object sender, RoutedEventArgs e) => ShowWindow<PersonWindow>();
    private void MenuOplata_Click(object sender, RoutedEventArgs e) => ShowWindow<OplataWindow>();
    private void MenuDocs_Click(object sender, RoutedEventArgs e) => ShowWindow<DocsWindow>();
    private void MenuProfilPodgotovki_Click(object sender, RoutedEventArgs e) => ShowWindow<ProfilPodgotovkiWindow>();
    private void MenuDiplomnik_Click(object sender, RoutedEventArgs e) => ShowWindow<DiplomnikWindow>();
    private void MenuStudent_Click(object sender, RoutedEventArgs e) => ShowWindow<StudentWindow>();
    private void MenuPeriodZasedania_Click(object sender, RoutedEventArgs e) => ShowWindow<PeriodZasedaniaWindow>();
    private void MenuGak_Click(object sender, RoutedEventArgs e) => ShowWindow<GakWindow>();
    private void MenuZasedanie_Click(object sender, RoutedEventArgs e) => ShowWindow<ZasedanieWindow>();
    private void MenuKomissiya_Click(object sender, RoutedEventArgs e) => ShowWindow<KomissiyaWindow>();

    // Help windows
    private void MenuHelpLabels_Click(object sender, RoutedEventArgs e) => ShowHelpWindow("TEMPLATE_LABELS.md");
    private void MenuHelpTemplates_Click(object sender, RoutedEventArgs e) => ShowHelpWindow("TEMPLATE_HOWTO.md");
    private void MenuHelpArchitecture_Click(object sender, RoutedEventArgs e) => ShowHelpWindow("ARCHITECTURE.md");
    private void MenuHelpDatabase_Click(object sender, RoutedEventArgs e) => ShowHelpWindow("DATABASE.md");
    private void MenuHelpDevelopment_Click(object sender, RoutedEventArgs e) => ShowHelpWindow("DEVELOPMENT.md");

    // Test data
    private async void MenuAddTestData_Click(object sender, RoutedEventArgs e)
    {
        var handler = App.ServiceProvider.GetRequiredService<SeedTestDataHandler>();
        var result = await handler.ExecuteAsync();

        var message = result.AlreadyExists
            ? "Тестовые данные уже добавлены."
            : $"Добавлено кафедр: {result.KafedraAdded}\nДобавлено сотрудников: {result.PersonsAdded}";

        MessageBox.Show(message, "Справка: тестовые данные", MessageBoxButton.OK, MessageBoxImage.Information);
    }

    private void ShowWindow<T>() where T : Window
    {
        var window = App.ServiceProvider.GetRequiredService<T>();
        window.Owner = this;
        window.ShowDialog();
    }

    private void ShowHelpWindow(string fileName)
    {
        var window = HelpWindow.FromDocsFile(fileName);
        window.Owner = this;
        window.ShowDialog();
    }
}
