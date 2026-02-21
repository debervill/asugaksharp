using System.Windows;

namespace asugaksharp.Features.NapravleniePodgotovki;

public partial class NapravleniePodgotovkiWindow : Window
{
    private readonly GetNapravleniePodgotovkisHandler _getHandler;
    private readonly CreateNapravleniePodgotovkiHandler _createHandler;
    private readonly UpdateNapravleniePodgotovkiHandler _updateHandler;
    private readonly DeleteNapravleniePodgotovkiHandler _deleteHandler;

    private Guid? _editingId = null;

    public NapravleniePodgotovkiWindow(
        GetNapravleniePodgotovkisHandler getHandler,
        CreateNapravleniePodgotovkiHandler createHandler,
        UpdateNapravleniePodgotovkiHandler updateHandler,
        DeleteNapravleniePodgotovkiHandler deleteHandler)
    {
        InitializeComponent();

        _getHandler = getHandler;
        _createHandler = createHandler;
        _updateHandler = updateHandler;
        _deleteHandler = deleteHandler;

        Loaded += async (s, e) => await LoadDataAsync();
    }

    private async Task LoadDataAsync()
    {
        try
        {
            var data = await _getHandler.ExecuteAsync() ?? new List<NapravleniePodgotovkiDto>();
            DataGridItems.ItemsSource = data;
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
        if (DataGridItems.SelectedItem is NapravleniePodgotovkiDto selected)
        {
            _editingId = selected.Id;
            TextBoxShifr.Text = selected.ShifrNapr;
            TextBoxNazvanie.Text = selected.Nazvanie;
        }
        else
        {
            MessageBox.Show("Выберите запись для редактирования", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
        }
    }

    private async void DeleteButton_Click(object sender, RoutedEventArgs e)
    {
        if (DataGridItems.SelectedItem is NapravleniePodgotovkiDto selected)
        {
            var result = MessageBox.Show($"Удалить направление \"{selected.Nazvanie}\"?", "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Question);
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
        if (string.IsNullOrWhiteSpace(TextBoxShifr.Text))
        {
            MessageBox.Show("Введите шифр", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            return;
        }

        if (string.IsNullOrWhiteSpace(TextBoxNazvanie.Text))
        {
            MessageBox.Show("Введите название", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            return;
        }

        if (_editingId.HasValue)
        {
            var request = new UpdateNapravleniePodgotovkiRequest(
                _editingId.Value,
                TextBoxNazvanie.Text,
                TextBoxShifr.Text);
            await _updateHandler.ExecuteAsync(request);
        }
        else
        {
            var request = new CreateNapravleniePodgotovkiRequest(
                TextBoxNazvanie.Text,
                TextBoxShifr.Text);
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
        TextBoxShifr.Text = "";
        TextBoxNazvanie.Text = "";
    }
}
