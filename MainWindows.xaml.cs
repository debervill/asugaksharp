using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using asugaksharp.Features.Kafedra;
using asugaksharp.Features.NapravleniePodgotovki;
using asugaksharp.Features.ProfilPodgotovki;
using asugaksharp.Features.Person;
using asugaksharp.Features.Diplomnik;
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

    private void MenuKafedra_Click(object sender, RoutedEventArgs e)
    {
        var window = App.ServiceProvider.GetRequiredService<KafedraWindow>();
        window.Owner = this;
        window.ShowDialog();
    }

    private void MenuNapravlenie_Click(object sender, RoutedEventArgs e)
    {
        var window = App.ServiceProvider.GetRequiredService<NapravleniePodgotovkiWindow>();
        window.Owner = this;
        window.ShowDialog();
    }

    private void MenuPerson_Click(object sender, RoutedEventArgs e)
    {
        var window = App.ServiceProvider.GetRequiredService<PersonWindow>();
        window.Owner = this;
        window.ShowDialog();
    }

    private void MenuOplata_Click(object sender, RoutedEventArgs e)
    {
        var window = App.ServiceProvider.GetRequiredService<OplataWindow>();
        window.Owner = this;
        window.ShowDialog();
    }

    private void MenuDocs_Click(object sender, RoutedEventArgs e)
    {
        var window = App.ServiceProvider.GetRequiredService<DocsWindow>();
        window.Owner = this;
        window.ShowDialog();
    }

    private void MenuProfilPodgotovki_Click(object sender, RoutedEventArgs e)
    {
        var window = App.ServiceProvider.GetRequiredService<ProfilPodgotovkiWindow>();
        window.Owner = this;
        window.ShowDialog();
    }

    private void MenuDiplomnik_Click(object sender, RoutedEventArgs e)
    {
        var window = App.ServiceProvider.GetRequiredService<DiplomnikWindow>();
        window.Owner = this;
        window.ShowDialog();
    }

    private void MenuPeriodZasedania_Click(object sender, RoutedEventArgs e)
    {
        var window = App.ServiceProvider.GetRequiredService<PeriodZasedaniaWindow>();
        window.Owner = this;
        window.ShowDialog();
    }

    private void MenuGak_Click(object sender, RoutedEventArgs e)
    {
        var window = App.ServiceProvider.GetRequiredService<GakWindow>();
        window.Owner = this;
        window.ShowDialog();
    }

    private void MenuZasedanie_Click(object sender, RoutedEventArgs e)
    {
        var window = App.ServiceProvider.GetRequiredService<ZasedanieWindow>();
        window.Owner = this;
        window.ShowDialog();
    }

    private void MenuKomissiya_Click(object sender, RoutedEventArgs e)
    {
        var window = App.ServiceProvider.GetRequiredService<KomissiyaWindow>();
        window.Owner = this;
        window.ShowDialog();
    }

    private void MenuHelpLabels_Click(object sender, RoutedEventArgs e)
    {
        var window = HelpWindow.FromDocsFile("TEMPLATE_LABELS.md");
        window.Owner = this;
        window.ShowDialog();
    }

    private void MenuHelpTemplates_Click(object sender, RoutedEventArgs e)
    {
        var window = HelpWindow.FromDocsFile("TEMPLATE_HOWTO.md");
        window.Owner = this;
        window.ShowDialog();
    }

    private void MenuHelpArchitecture_Click(object sender, RoutedEventArgs e)
    {
        var window = HelpWindow.FromDocsFile("ARCHITECTURE.md");
        window.Owner = this;
        window.ShowDialog();
    }

    private void MenuHelpDatabase_Click(object sender, RoutedEventArgs e)
    {
        var window = HelpWindow.FromDocsFile("DATABASE.md");
        window.Owner = this;
        window.ShowDialog();
    }

    private void MenuHelpDevelopment_Click(object sender, RoutedEventArgs e)
    {
        var window = HelpWindow.FromDocsFile("DEVELOPMENT.md");
        window.Owner = this;
        window.ShowDialog();
    }

    private async void MenuAddTestData_Click(object sender, RoutedEventArgs e)
    {
        var handler = App.ServiceProvider.GetRequiredService<SeedTestDataHandler>();
        var result = await handler.ExecuteAsync();

        if (result.AlreadyExists)
        {
            MessageBox.Show(
                "Тестовые данные уже добавлены.",
                "Справка: тестовые данные",
                MessageBoxButton.OK,
                MessageBoxImage.Information);
            return;
        }

        MessageBox.Show(
            $"Добавлено кафедр: {result.KafedraAdded}\nДобавлено сотрудников: {result.PersonsAdded}",
            "Справка: тестовые данные",
            MessageBoxButton.OK,
            MessageBoxImage.Information);
    }
}
