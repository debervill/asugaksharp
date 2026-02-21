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

    private readonly KomissiyaViewModel _viewModel = new();
    private List<GakDto> _gaksByKafedra = new();

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

        ListBoxPredsedateli.ItemsSource = _viewModel.AvailablePredsedateli;
        ListBoxSecretari.ItemsSource = _viewModel.AvailableSecretari;
        ListBoxSotrudniki.ItemsSource = _viewModel.AvailableSotrudniki;
        ListBoxChleny.ItemsSource = _viewModel.Chleny;

        _viewModel.StateChanged += UpdateUI;

        Loaded += async (s, e) => await LoadKafedrasAsync();
    }

    private async Task LoadKafedrasAsync()
    {
        try
        {
            var kafedras = await _getKafedrasHandler.ExecuteAsync() ?? new List<KafedraDto>();
            ComboBoxKafedra.ItemsSource = kafedras;
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Ошибка загрузки кафедр: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }
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
            _viewModel.Clear();
        }
    }

    private void ComboBoxPeriodZasedania_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
    {
        if (ComboBoxPeriodZasedania.SelectedItem is PeriodZasedaniaDto period)
            ComboBoxGak.ItemsSource = _gaksByKafedra.Where(g => g.PeriodZasedaniaId == period.Id).ToList();
        else
            ComboBoxGak.ItemsSource = _gaksByKafedra;

        ComboBoxGak.SelectedItem = null;
        _viewModel.Clear();
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

        var allPersons = await _getPersonsByKafedraHandler.ExecuteAsync(kafedra.Id);
        var komissiya = await _getGakKomissiyaHandler.ExecuteAsync(gak.Id);
        _viewModel.LoadKomissiya(allPersons, komissiya);
    }

    private void AddPredsedatel_Click(object sender, RoutedEventArgs e)
    {
        if (ListBoxPredsedateli.SelectedItem is not KomissiyaPersonDto person)
        {
            MessageBox.Show("Выберите председателя из списка", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
            return;
        }

        var error = _viewModel.AssignPredsedatel(person);
        if (error != null)
            MessageBox.Show(error, "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
    }

    private void RemovePredsedatel_Click(object sender, RoutedEventArgs e)
    {
        var error = _viewModel.UnassignPredsedatel();
        if (error != null)
            MessageBox.Show(error, "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
    }

    private void AddSekretar_Click(object sender, RoutedEventArgs e)
    {
        if (ListBoxSecretari.SelectedItem is not KomissiyaPersonDto person)
        {
            MessageBox.Show("Выберите секретаря из списка", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
            return;
        }

        var error = _viewModel.AssignSekretar(person);
        if (error != null)
            MessageBox.Show(error, "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
    }

    private void RemoveSekretar_Click(object sender, RoutedEventArgs e)
    {
        var error = _viewModel.UnassignSekretar();
        if (error != null)
            MessageBox.Show(error, "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
    }

    private void AddChlen_Click(object sender, RoutedEventArgs e)
    {
        if (ListBoxSotrudniki.SelectedItem is not KomissiyaPersonDto person)
        {
            MessageBox.Show("Выберите сотрудника из списка", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
            return;
        }

        _viewModel.AddChlen(person);
    }

    private void RemoveChlen_Click(object sender, RoutedEventArgs e)
    {
        if (ListBoxChleny.SelectedItem is not KomissiyaPersonDto person)
        {
            MessageBox.Show("Выберите члена комиссии для удаления", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
            return;
        }

        _viewModel.RemoveChlen(person);
    }

    private async void SaveButton_Click(object sender, RoutedEventArgs e)
    {
        if (ComboBoxGak.SelectedItem is not GakDto gak)
        {
            MessageBox.Show("Выберите ГАК", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
            return;
        }

        var errors = _viewModel.Validate();
        if (errors.Count > 0)
        {
            MessageBox.Show(
                "Невозможно сохранить комиссию:\n\n" + string.Join("\n", errors.Select(err => "• " + err)),
                "Ошибка валидации",
                MessageBoxButton.OK,
                MessageBoxImage.Error);
            return;
        }

        ButtonSave.IsEnabled = false;
        try
        {
            var request = _viewModel.CreateSaveRequest(gak.Id);
            await _saveGakKomissiyaHandler.ExecuteAsync(request);
            _viewModel.MarkSaved();
            MessageBox.Show("Комиссия сохранена", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Ошибка сохранения: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }
        finally
        {
            ButtonSave.IsEnabled = _viewModel.HasChanges;
        }
    }

    private void UpdateUI()
    {
        // Председатель
        if (_viewModel.Predsedatel != null)
        {
            TextBlockPredsedatel.Text = _viewModel.Predsedatel.Name;
            TextBlockPredsedatel.Foreground = System.Windows.Media.Brushes.Black;
        }
        else
        {
            TextBlockPredsedatel.Text = "(не назначен)";
            TextBlockPredsedatel.Foreground = System.Windows.Media.Brushes.Gray;
        }

        // Секретарь
        if (_viewModel.Sekretar != null)
        {
            TextBlockSekretar.Text = _viewModel.Sekretar.Name;
            TextBlockSekretar.Foreground = System.Windows.Media.Brushes.Black;
        }
        else
        {
            TextBlockSekretar.Text = "(не назначен)";
            TextBlockSekretar.Foreground = System.Windows.Media.Brushes.Gray;
        }

        // Счётчик членов комиссии
        var count = _viewModel.Chleny.Count;
        var color = count >= 3 ? System.Windows.Media.Brushes.Green : System.Windows.Media.Brushes.Red;
        TextBlockChlenCount.Text = $" ({count} из 3 минимум)";
        TextBlockChlenCount.Foreground = color;

        ButtonSave.IsEnabled = _viewModel.HasChanges;
    }
}
