using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using asugaksharp.Features.Kafedra;
using asugaksharp.Features.NapravleniePodgotovki;
using asugaksharp.Features.Person;
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
}
