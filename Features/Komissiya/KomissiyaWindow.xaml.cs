using System.Collections.ObjectModel;
using System.Windows;
using asugaksharp.Features.Kafedra;
using asugaksharp.Features.Gak;
using asugaksharp.Features.PeriodZasedania;

namespace asugaksharp.Features.Komissiya;

public partial class KomissiyaWindow : Window
{
    private readonly GetKafedrasHandler _getKafedrasHandler;
    private readonly GetGaksByKafedraHandler _getGaksByKafedraHandler;
    private readonly GetPersonsByKafedraHandler _getPersonsByKafedraHandler;
    private readonly GetPeriodZasedaniasHandler _getPeriodZasedaniasHandler;
    private readonly GetGakKomissiyaHandler _getGakKomissiyaHandler;
    private readonly SaveGakKomissiyaHandler _saveGakKomissiyaHandler;

    // Доступные сотрудники (разделены по ролям)
    private ObservableCollection<KomissiyaPersonDto> _availablePredsedateli = new();
    private ObservableCollection<KomissiyaPersonDto> _availableSecretari = new();
    private ObservableCollection<KomissiyaPersonDto> _availableSotrudniki = new();
    private List<GakDto> _gaksByKafedra = new();

    // Назначенные в комиссию
    private KomissiyaPersonDto? _predsedatel = null;
    private KomissiyaPersonDto? _sekretar = null;
    private ObservableCollection<KomissiyaPersonDto> _chleny = new();

    private bool _hasChanges = false;

    public KomissiyaWindow(
        GetKafedrasHandler getKafedrasHandler,
        GetGaksByKafedraHandler getGaksByKafedraHandler,
        GetPersonsByKafedraHandler getPersonsByKafedraHandler,
        GetPeriodZasedaniasHandler getPeriodZasedaniasHandler,
        GetGakKomissiyaHandler getGakKomissiyaHandler,
        SaveGakKomissiyaHandler saveGakKomissiyaHandler)
    {
        InitializeComponent();

        _getKafedrasHandler = getKafedrasHandler;
        _getGaksByKafedraHandler = getGaksByKafedraHandler;
        _getPersonsByKafedraHandler = getPersonsByKafedraHandler;
        _getPeriodZasedaniasHandler = getPeriodZasedaniasHandler;
        _getGakKomissiyaHandler = getGakKomissiyaHandler;
        _saveGakKomissiyaHandler = saveGakKomissiyaHandler;

        ListBoxPredsedateli.ItemsSource = _availablePredsedateli;
        ListBoxSecretari.ItemsSource = _availableSecretari;
        ListBoxSotrudniki.ItemsSource = _availableSotrudniki;
        ListBoxChleny.ItemsSource = _chleny;

        Loaded += async (s, e) => await LoadKafedrasAsync();
    }

    private async Task LoadKafedrasAsync()
    {
        var kafedras = await _getKafedrasHandler.ExecuteAsync();
        ComboBoxKafedra.ItemsSource = kafedras;
    }

    private async void ComboBoxKafedra_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
    {
        if (ComboBoxKafedra.SelectedItem is KafedraDto kafedra)
        {
            var periods = await _getPeriodZasedaniasHandler.ExecuteAsync();
            ComboBoxPeriodZasedania.ItemsSource = periods.Where(p => p.KafedraId == kafedra.Id).ToList();
            ComboBoxPeriodZasedania.SelectedItem = null;

            _gaksByKafedra = await _getGaksByKafedraHandler.ExecuteAsync(kafedra.Id);
            ComboBoxGak.ItemsSource = _gaksByKafedra;
            ComboBoxGak.SelectedItem = null;
            ClearAll();
        }
    }

    private void ComboBoxPeriodZasedania_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
    {
        if (ComboBoxPeriodZasedania.SelectedItem is PeriodZasedaniaDto period)
        {
            ComboBoxGak.ItemsSource = _gaksByKafedra.Where(g => g.PeriodZasedaniaId == period.Id).ToList();
        }
        else
        {
            ComboBoxGak.ItemsSource = _gaksByKafedra;
        }

        ComboBoxGak.SelectedItem = null;
        ClearAll();
    }

    private async void LoadButton_Click(object sender, RoutedEventArgs e)
    {
        if (ComboBoxKafedra.SelectedItem is not KafedraDto kafedra)
        {
            MessageBox.Show("Выберите кафедру", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
            return;
        }

        if (ComboBoxGak.SelectedItem is not GakDto gak)
        {
            MessageBox.Show("Выберите ГАК", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
            return;
        }

        await LoadDataAsync(kafedra.Id, gak.Id);
        SetHasChanges(false);
    }

    private async Task LoadDataAsync(Guid kafedraId, Guid gakId)
    {
        // Загружаем всех сотрудников кафедры
        var allPersons = await _getPersonsByKafedraHandler.ExecuteAsync(kafedraId);

        // Загружаем текущий состав комиссии
        var komissiya = await _getGakKomissiyaHandler.ExecuteAsync(gakId);

        // Собираем ID уже назначенных в комиссию
        var assignedIds = new HashSet<Guid>();
        if (komissiya.Predsedatel != null) assignedIds.Add(komissiya.Predsedatel.Id);
        if (komissiya.Sekretar != null) assignedIds.Add(komissiya.Sekretar.Id);
        foreach (var chlen in komissiya.Chleny) assignedIds.Add(chlen.Id);

        // Заполняем текущий состав комиссии
        _predsedatel = komissiya.Predsedatel;
        _sekretar = komissiya.Sekretar;

        _chleny.Clear();
        foreach (var chlen in komissiya.Chleny)
            _chleny.Add(chlen);

        // Распределяем доступных сотрудников по категориям
        _availablePredsedateli.Clear();
        _availableSecretari.Clear();
        _availableSotrudniki.Clear();

        foreach (var person in allPersons)
        {
            if (assignedIds.Contains(person.Id))
                continue;

            if (person.IsPredsed)
                _availablePredsedateli.Add(person);

            if (person.IsSecretar)
                _availableSecretari.Add(person);

            // Все сотрудники могут быть членами комиссии
            _availableSotrudniki.Add(person);
        }

        UpdateUI();
    }

    private void UpdateUI()
    {
        // Обновляем отображение председателя
        if (_predsedatel != null)
        {
            TextBlockPredsedatel.Text = _predsedatel.Name;
            TextBlockPredsedatel.Foreground = System.Windows.Media.Brushes.Black;
        }
        else
        {
            TextBlockPredsedatel.Text = "(не назначен)";
            TextBlockPredsedatel.Foreground = System.Windows.Media.Brushes.Gray;
        }

        // Обновляем отображение секретаря
        if (_sekretar != null)
        {
            TextBlockSekretar.Text = _sekretar.Name;
            TextBlockSekretar.Foreground = System.Windows.Media.Brushes.Black;
        }
        else
        {
            TextBlockSekretar.Text = "(не назначен)";
            TextBlockSekretar.Foreground = System.Windows.Media.Brushes.Gray;
        }

        // Обновляем счётчик членов комиссии
        var count = _chleny.Count;
        var color = count >= 3 ? System.Windows.Media.Brushes.Green : System.Windows.Media.Brushes.Red;
        TextBlockChlenCount.Text = $" ({count} из 3 минимум)";
        TextBlockChlenCount.Foreground = color;
    }

    #region Председатель

    private void AddPredsedatel_Click(object sender, RoutedEventArgs e)
    {
        if (ListBoxPredsedateli.SelectedItem is not KomissiyaPersonDto person)
        {
            MessageBox.Show("Выберите председателя из списка", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
            return;
        }

        if (_predsedatel != null)
        {
            MessageBox.Show("Председатель уже назначен. Сначала уберите текущего.", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
            return;
        }

        _predsedatel = person;
        _availablePredsedateli.Remove(person);

        // Удаляем из других списков тоже
        if (person.IsSecretar)
        {
            var inSecretari = _availableSecretari.FirstOrDefault(p => p.Id == person.Id);
            if (inSecretari != null) _availableSecretari.Remove(inSecretari);
        }
        var inSotrudniki = _availableSotrudniki.FirstOrDefault(p => p.Id == person.Id);
        if (inSotrudniki != null) _availableSotrudniki.Remove(inSotrudniki);

        UpdateUI();
        SetHasChanges(true);
    }

    private void RemovePredsedatel_Click(object sender, RoutedEventArgs e)
    {
        if (_predsedatel == null)
        {
            MessageBox.Show("Председатель не назначен", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
            return;
        }

        var person = _predsedatel;
        _predsedatel = null;

        // Возвращаем в списки
        _availablePredsedateli.Add(person);
        if (person.IsSecretar) _availableSecretari.Add(person);
        _availableSotrudniki.Add(person);

        UpdateUI();
        SetHasChanges(true);
    }

    #endregion

    #region Секретарь

    private void AddSekretar_Click(object sender, RoutedEventArgs e)
    {
        if (ListBoxSecretari.SelectedItem is not KomissiyaPersonDto person)
        {
            MessageBox.Show("Выберите секретаря из списка", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
            return;
        }

        if (_sekretar != null)
        {
            MessageBox.Show("Секретарь уже назначен. Сначала уберите текущего.", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
            return;
        }

        _sekretar = person;
        _availableSecretari.Remove(person);

        // Удаляем из других списков тоже
        if (person.IsPredsed)
        {
            var inPredsedateli = _availablePredsedateli.FirstOrDefault(p => p.Id == person.Id);
            if (inPredsedateli != null) _availablePredsedateli.Remove(inPredsedateli);
        }
        var inSotrudniki = _availableSotrudniki.FirstOrDefault(p => p.Id == person.Id);
        if (inSotrudniki != null) _availableSotrudniki.Remove(inSotrudniki);

        UpdateUI();
        SetHasChanges(true);
    }

    private void RemoveSekretar_Click(object sender, RoutedEventArgs e)
    {
        if (_sekretar == null)
        {
            MessageBox.Show("Секретарь не назначен", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
            return;
        }

        var person = _sekretar;
        _sekretar = null;

        // Возвращаем в списки
        _availableSecretari.Add(person);
        if (person.IsPredsed) _availablePredsedateli.Add(person);
        _availableSotrudniki.Add(person);

        UpdateUI();
        SetHasChanges(true);
    }

    #endregion

    #region Члены комиссии

    private void AddChlen_Click(object sender, RoutedEventArgs e)
    {
        if (ListBoxSotrudniki.SelectedItem is not KomissiyaPersonDto person)
        {
            MessageBox.Show("Выберите сотрудника из списка", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
            return;
        }

        _chleny.Add(person);
        _availableSotrudniki.Remove(person);

        // Удаляем из других списков тоже
        if (person.IsPredsed)
        {
            var inPredsedateli = _availablePredsedateli.FirstOrDefault(p => p.Id == person.Id);
            if (inPredsedateli != null) _availablePredsedateli.Remove(inPredsedateli);
        }
        if (person.IsSecretar)
        {
            var inSecretari = _availableSecretari.FirstOrDefault(p => p.Id == person.Id);
            if (inSecretari != null) _availableSecretari.Remove(inSecretari);
        }

        UpdateUI();
        SetHasChanges(true);
    }

    private void RemoveChlen_Click(object sender, RoutedEventArgs e)
    {
        if (ListBoxChleny.SelectedItem is not KomissiyaPersonDto person)
        {
            MessageBox.Show("Выберите члена комиссии для удаления", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
            return;
        }

        _chleny.Remove(person);

        // Возвращаем в списки
        _availableSotrudniki.Add(person);
        if (person.IsPredsed) _availablePredsedateli.Add(person);
        if (person.IsSecretar) _availableSecretari.Add(person);

        UpdateUI();
        SetHasChanges(true);
    }

    #endregion

    private async void SaveButton_Click(object sender, RoutedEventArgs e)
    {
        if (ComboBoxGak.SelectedItem is not GakDto gak)
        {
            MessageBox.Show("Выберите ГАК", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
            return;
        }

        // Валидация
        var errors = new List<string>();

        if (_predsedatel == null)
            errors.Add("Не назначен председатель");

        if (_sekretar == null)
            errors.Add("Не назначен секретарь");

        if (_chleny.Count < 3)
            errors.Add($"Недостаточно членов комиссии (назначено {_chleny.Count}, требуется минимум 3)");

        if (errors.Count > 0)
        {
            MessageBox.Show(
                "Невозможно сохранить комиссию:\n\n" + string.Join("\n", errors.Select(e => "• " + e)),
                "Ошибка валидации",
                MessageBoxButton.OK,
                MessageBoxImage.Error);
            return;
        }

        try
        {
            var request = new SaveGakKomissiyaRequest(
                gak.Id,
                _predsedatel!.Id,
                _sekretar!.Id,
                _chleny.Select(c => c.Id).ToList());

            await _saveGakKomissiyaHandler.ExecuteAsync(request);
            SetHasChanges(false);
            MessageBox.Show("Комиссия сохранена", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Ошибка сохранения: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }

    private void SetHasChanges(bool value)
    {
        _hasChanges = value;
        ButtonSave.IsEnabled = value;
    }

    private void ClearAll()
    {
        _predsedatel = null;
        _sekretar = null;
        _chleny.Clear();
        _availablePredsedateli.Clear();
        _availableSecretari.Clear();
        _availableSotrudniki.Clear();
        UpdateUI();
        SetHasChanges(false);
    }
}
