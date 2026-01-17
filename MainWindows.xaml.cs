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
        var window = App.ServiceProvider.GetRequiredService<OplataManagementWindow>();
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
}
