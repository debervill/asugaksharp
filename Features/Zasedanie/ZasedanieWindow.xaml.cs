using System.Windows;

namespace asugaksharp.Features.Zasedanie;

public partial class ZasedanieWindow : Window
{
    private readonly GetZasedaniesHandler _getHandler;
    private readonly CreateZasedanieHandler _createHandler;
    private readonly UpdateZasedanieHandler _updateHandler;
    private readonly DeleteZasedanieHandler _deleteHandler;
    private readonly Gak.GetGaksHandler _getGaksHandler;

    private Guid? _editingId = null;

    public ZasedanieWindow(
        GetZasedaniesHandler getHandler,
        CreateZasedanieHandler createHandler,
        UpdateZasedanieHandler updateHandler,
        DeleteZasedanieHandler deleteHandler,
        Gak.GetGaksHandler getGaksHandler)
    {
        InitializeComponent();

        _getHandler = getHandler;
        _createHandler = createHandler;
        _updateHandler = updateHandler;
        _deleteHandler = deleteHandler;
        _getGaksHandler = getGaksHandler;

        Loaded += async (s, e) => await LoadDataAsync();
    }

    private async Task LoadDataAsync()
    {
        var data = await _getHandler.ExecuteAsync();
        DataGridZasedanies.ItemsSource = data;

        var gaks = await _getGaksHandler.ExecuteAsync();
        ComboBoxGak.ItemsSource = gaks;
    }

    private void AddButton_Click(object sender, RoutedEventArgs e)
    {
        _editingId = null;
        ClearForm();
    }

    private void EditButton_Click(object sender, RoutedEventArgs e)
    {
        if (DataGridZasedanies.SelectedItem is ZasedanieDto selected)
        {
            _editingId = selected.Id;
            TextBoxNapravleniePodgotovki.Text = selected.NapravleniePodgotovki;
            TextBoxKvalificacia.Text = selected.Kvalificacia;
            DatePickerDate.SelectedDate = selected.Date.ToDateTime(TimeOnly.MinValue);
            ComboBoxGak.SelectedValue = selected.GakId;
        }
        else
        {
            MessageBox.Show("Выберите запись для редактирования", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
        }
    }

    private async void DeleteButton_Click(object sender, RoutedEventArgs e)
    {
        if (DataGridZasedanies.SelectedItem is ZasedanieDto selected)
        {
            var result = MessageBox.Show($"Удалить заседание \"{selected.NapravleniePodgotovki}\"?", "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Question);
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
        if (string.IsNullOrWhiteSpace(TextBoxNapravleniePodgotovki.Text))
        {
            MessageBox.Show("Введите направление подготовки", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            return;
        }

        if (string.IsNullOrWhiteSpace(TextBoxKvalificacia.Text))
        {
            MessageBox.Show("Введите квалификацию", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            return;
        }

        if (!DatePickerDate.SelectedDate.HasValue)
        {
            MessageBox.Show("Выберите дату", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            return;
        }

        if (ComboBoxGak.SelectedValue == null)
        {
            MessageBox.Show("Выберите ГАК", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            return;
        }

        var date = DateOnly.FromDateTime(DatePickerDate.SelectedDate.Value);
        var gakId = (Guid)ComboBoxGak.SelectedValue;

        if (_editingId.HasValue)
        {
            var request = new UpdateZasedanieRequest(
                _editingId.Value,
                TextBoxNapravleniePodgotovki.Text,
                TextBoxKvalificacia.Text,
                date,
                gakId);
            await _updateHandler.ExecuteAsync(request);
        }
        else
        {
            var request = new CreateZasedanieRequest(
                TextBoxNapravleniePodgotovki.Text,
                TextBoxKvalificacia.Text,
                date,
                gakId);
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
        TextBoxNapravleniePodgotovki.Text = "";
        TextBoxKvalificacia.Text = "";
        DatePickerDate.SelectedDate = null;
        ComboBoxGak.SelectedIndex = -1;
    }
}
