using System.Windows;

namespace asugaksharp.Features.PeriodZasedania;

public partial class PeriodZasedaniaWindow : Window
{
    private readonly GetPeriodZasedaniasHandler _getHandler;
    private readonly CreatePeriodZasedaniaHandler _createHandler;
    private readonly UpdatePeriodZasedaniaHandler _updateHandler;
    private readonly DeletePeriodZasedaniaHandler _deleteHandler;
    private readonly Kafedra.GetKafedrasHandler _getKafedrasHandler;

    private Guid? _editingId = null;

    public PeriodZasedaniaWindow(
        GetPeriodZasedaniasHandler getHandler,
        CreatePeriodZasedaniaHandler createHandler,
        UpdatePeriodZasedaniaHandler updateHandler,
        DeletePeriodZasedaniaHandler deleteHandler,
        Kafedra.GetKafedrasHandler getKafedrasHandler)
    {
        InitializeComponent();

        _getHandler = getHandler;
        _createHandler = createHandler;
        _updateHandler = updateHandler;
        _deleteHandler = deleteHandler;
        _getKafedrasHandler = getKafedrasHandler;

        Loaded += async (s, e) => await LoadDataAsync();
    }

    private async Task LoadDataAsync()
    {
        try
        {
            var data = await _getHandler.ExecuteAsync() ?? new List<PeriodZasedaniaDto>();
            DataGridPeriodZasedanias.ItemsSource = data;

            var kafedras = await _getKafedrasHandler.ExecuteAsync() ?? new List<Kafedra.KafedraDto>();
            ComboBoxKafedra.ItemsSource = kafedras;
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Ошибка загрузки данных: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }

    private void AddButton_Click(object sender, RoutedEventArgs e)
    {
        _editingId = null;
        ClearForm();
    }

    private void EditButton_Click(object sender, RoutedEventArgs e)
    {
        if (DataGridPeriodZasedanias.SelectedItem is PeriodZasedaniaDto selected)
        {
            _editingId = selected.Id;
            TextBoxName.Text = selected.Name;
            DatePickerDateStart.SelectedDate = selected.DateStart.ToDateTime(TimeOnly.MinValue);
            DatePickerDateEnd.SelectedDate = selected.DateEnd.ToDateTime(TimeOnly.MinValue);
            TextBoxPrimechanie.Text = selected.Primechanie;
            ComboBoxKafedra.SelectedValue = selected.KafedraId;
        }
        else
        {
            MessageBox.Show("Выберите запись для редактирования", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
        }
    }

    private async void DeleteButton_Click(object sender, RoutedEventArgs e)
    {
        if (DataGridPeriodZasedanias.SelectedItem is PeriodZasedaniaDto selected)
        {
            var result = MessageBox.Show($"Удалить период заседания \"{selected.Name}\"?", "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Question);
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
        if (string.IsNullOrWhiteSpace(TextBoxName.Text))
        {
            MessageBox.Show("Введите название", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            return;
        }

        if (!DatePickerDateStart.SelectedDate.HasValue)
        {
            MessageBox.Show("Выберите дату начала", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            return;
        }

        if (!DatePickerDateEnd.SelectedDate.HasValue)
        {
            MessageBox.Show("Выберите дату окончания", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            return;
        }

        if (string.IsNullOrWhiteSpace(TextBoxPrimechanie.Text))
        {
            MessageBox.Show("Введите примечание", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            return;
        }

        if (ComboBoxKafedra.SelectedValue == null)
        {
            MessageBox.Show("Выберите кафедру", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            return;
        }

        var dateStart = DateOnly.FromDateTime(DatePickerDateStart.SelectedDate.Value);
        var dateEnd = DateOnly.FromDateTime(DatePickerDateEnd.SelectedDate.Value);
        var kafedraId = (Guid)ComboBoxKafedra.SelectedValue;

        if (_editingId.HasValue)
        {
            var request = new UpdatePeriodZasedaniaRequest(
                _editingId.Value,
                TextBoxName.Text,
                dateStart,
                dateEnd,
                TextBoxPrimechanie.Text,
                kafedraId);
            await _updateHandler.ExecuteAsync(request);
        }
        else
        {
            var request = new CreatePeriodZasedaniaRequest(
                TextBoxName.Text,
                dateStart,
                dateEnd,
                TextBoxPrimechanie.Text,
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
        TextBoxName.Text = "";
        DatePickerDateStart.SelectedDate = null;
        DatePickerDateEnd.SelectedDate = null;
        TextBoxPrimechanie.Text = "";
        ComboBoxKafedra.SelectedIndex = -1;
    }
}
