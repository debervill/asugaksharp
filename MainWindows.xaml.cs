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

namespace asugaksharp;

public partial class MainWindows : Window
{
    private const string DogovorTagsHelpText =
        "Метки для шаблона договора (используйте в docx как {{Метка}}):\n" +
        "{{НомерДоговора}}\n" +
        "{{ДатаДень}}\n" +
        "{{ДатаМесяц}}\n" +
        "{{ДатаГод}}\n" +
        "{{ДатаДоговора}}\n" +
        "{{ФИО}}\n" +
        "{{ПаспортСерия}}\n" +
        "{{ПаспортНомер}}\n" +
        "{{ПаспортКемВыдан}}\n" +
        "{{АдресРегистрации}}\n" +
        "{{СНИЛС}}\n" +
        "{{ИНН}}\n" +
        "{{Email}}\n" +
        "{{Телефон}}\n" +
        "{{Степень}}\n" +
        "{{Звание}}\n" +
        "{{Должность}}\n" +
        "{{РольВГЭК}}\n" +
        "{{НомерПриказа}}\n" +
        "{{ДатаПриказа}}\n" +
        "{{Основание}}\n" +
        "{{КоличествоБюджет}}\n" +
        "{{КоличествоПлатка}}\n" +
        "{{КоличествоВсего}}\n" +
        "{{Коэффициент}}\n" +
        "{{СтоимостьЧаса}}\n" +
        "{{АкадемЧасов}}\n" +
        "{{АстрономЧасов}}\n" +
        "{{СуммаБезНалогов}}\n" +
        "{{СуммаБезНалоговПрописью}}\n" +
        "{{НДФЛ}}\n" +
        "{{НДФЛПроцент}}\n" +
        "{{ЕНП}}\n" +
        "{{ЕНПпроцент}}\n" +
        "{{СуммаКВыплате}}\n" +
        "{{СуммаКВыплатеПрописью}}\n" +
        "{{СуммаСНалогами}}";

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

    private void MenuDogovorTags_Click(object sender, RoutedEventArgs e)
    {
        MessageBox.Show(
            DogovorTagsHelpText,
            "Справка: метки договора",
            MessageBoxButton.OK,
            MessageBoxImage.Information);
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
