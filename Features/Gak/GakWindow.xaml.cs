using System.Windows;

namespace asugaksharp.Features.Gak;

public partial class GakWindow : Window
{
    private readonly GetGaksHandler _getHandler;
    private readonly CreateGakHandler _createHandler;
    private readonly UpdateGakHandler _updateHandler;
    private readonly DeleteGakHandler _deleteHandler;
    private readonly PeriodZasedania.GetPeriodZasedaniasHandler _getPeriodZasedaniasHandler;
    private readonly Kafedra.GetKafedrasHandler _getKafedrasHandler;

    private Guid? _editingId = null;
    private List<PeriodZasedania.PeriodZasedaniaDto> _periods = new();

    public GakWindow(
        GetGaksHandler getHandler,
        CreateGakHandler createHandler,
        UpdateGakHandler updateHandler,
        DeleteGakHandler deleteHandler,
        PeriodZasedania.GetPeriodZasedaniasHandler getPeriodZasedaniasHandler,
        Kafedra.GetKafedrasHandler getKafedrasHandler)
    {
        InitializeComponent();

        _getHandler = getHandler;
        _createHandler = createHandler;
        _updateHandler = updateHandler;
        _deleteHandler = deleteHandler;
        _getPeriodZasedaniasHandler = getPeriodZasedaniasHandler;
        _getKafedrasHandler = getKafedrasHandler;

        Loaded += async (s, e) => await LoadDataAsync();
    }

    private async Task LoadDataAsync()
    {
        var data = await _getHandler.ExecuteAsync();
        DataGridGaks.ItemsSource = data;

        _periods = await _getPeriodZasedaniasHandler.ExecuteAsync();
        ComboBoxPeriodZasedania.ItemsSource = _periods;

        var kafedras = await _getKafedrasHandler.ExecuteAsync();
        ComboBoxKafedra.ItemsSource = kafedras;
    }

    private void AddButton_Click(object sender, RoutedEventArgs e)
    {
        _editingId = null;
        ClearForm();
    }

    private void EditButton_Click(object sender, RoutedEventArgs e)
    {
        if (DataGridGaks.SelectedItem is GakDto selected)
        {
            _editingId = selected.Id;
            TextBoxNomerPrikaza.Text = selected.NomerPrikaza;
            TextBoxKolvoBudget.Text = selected.KolvoBudget.ToString();
            TextBoxKolvoPlatka.Text = selected.KolvoPlatka.ToString();
            ComboBoxKafedra.SelectedValue = selected.KafedraId;
            ApplyPeriodFilter(selected.KafedraId);
            ComboBoxPeriodZasedania.SelectedValue = selected.PeriodZasedaniaId;
        }
        else
        {
            MessageBox.Show("Выберите запись для редактирования", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
        }
    }

    private async void DeleteButton_Click(object sender, RoutedEventArgs e)
    {
        if (DataGridGaks.SelectedItem is GakDto selected)
        {
            var result = MessageBox.Show($"Удалить ГАК \"{selected.NomerPrikaza}\"?", "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                await _deleteHandler.ExecuteAsync(selected.Id);
                await LoadDataAsync();
                ClearForm();
            }
        }
        else
        {
            MessageBox.Show("Выберите запись для удаления", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
        }
    }

    private async void RefreshButton_Click(object sender, RoutedEventArgs e)
    {
        await LoadDataAsync();
    }

    private async void SaveButton_Click(object sender, RoutedEventArgs e)
    {
        if (string.IsNullOrWhiteSpace(TextBoxNomerPrikaza.Text))
        {
            MessageBox.Show("Введите номер приказа", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            return;
        }

        if (!int.TryParse(TextBoxKolvoBudget.Text, out int kolvoBudget))
        {
            MessageBox.Show("Введите корректное количество бюджетных мест", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            return;
        }

        if (!int.TryParse(TextBoxKolvoPlatka.Text, out int kolvoPlatka))
        {
            MessageBox.Show("Введите корректное количество платных мест", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            return;
        }

        if (ComboBoxPeriodZasedania.SelectedValue == null)
        {
            MessageBox.Show("Выберите период заседания", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            return;
        }

        if (ComboBoxKafedra.SelectedValue == null)
        {
            MessageBox.Show("Выберите кафедру", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            return;
        }

        var periodZasedaniaId = (Guid)ComboBoxPeriodZasedania.SelectedValue;
        var kafedraId = (Guid)ComboBoxKafedra.SelectedValue;

        if (_editingId.HasValue)
        {
            var request = new UpdateGakRequest(
                _editingId.Value,
                TextBoxNomerPrikaza.Text,
                kolvoBudget,
                kolvoPlatka,
                periodZasedaniaId,
                kafedraId);
            await _updateHandler.ExecuteAsync(request);
        }
        else
        {
            var request = new CreateGakRequest(
                TextBoxNomerPrikaza.Text,
                kolvoBudget,
                kolvoPlatka,
                periodZasedaniaId,
                kafedraId);
            await _createHandler.ExecuteAsync(request);
        }

        await LoadDataAsync();
        ClearForm();
    }

    private void CancelButton_Click(object sender, RoutedEventArgs e)
    {
        ClearForm();
    }

    private void ClearForm()
    {
        _editingId = null;
        TextBoxNomerPrikaza.Text = "";
        TextBoxKolvoBudget.Text = "";
        TextBoxKolvoPlatka.Text = "";
        ComboBoxPeriodZasedania.SelectedIndex = -1;
        ComboBoxKafedra.SelectedIndex = -1;
        ComboBoxPeriodZasedania.ItemsSource = _periods;
    }

    private void ComboBoxKafedra_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
    {
        if (ComboBoxKafedra.SelectedValue is Guid kafedraId)
            ApplyPeriodFilter(kafedraId);
        else
            ComboBoxPeriodZasedania.ItemsSource = _periods;

        ComboBoxPeriodZasedania.SelectedIndex = -1;
    }

    private void ApplyPeriodFilter(Guid kafedraId)
    {
        ComboBoxPeriodZasedania.ItemsSource = _periods
            .Where(p => p.KafedraId == kafedraId)
            .ToList();
    }
}
