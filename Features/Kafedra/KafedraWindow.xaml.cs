using System.Windows;

namespace asugaksharp.Features.Kafedra;

public partial class KafedraWindow : Window
{
    private readonly GetKafedrasHandler _getHandler;
    private readonly CreateKafedraHandler _createHandler;
    private readonly UpdateKafedraHandler _updateHandler;
    private readonly DeleteKafedraHandler _deleteHandler;

    private Guid? _editingId = null;

    public KafedraWindow(
        GetKafedrasHandler getHandler,
        CreateKafedraHandler createHandler,
        UpdateKafedraHandler updateHandler,
        DeleteKafedraHandler deleteHandler)
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
            var data = await _getHandler.ExecuteAsync() ?? new List<KafedraDto>();
            DataGridKafedras.ItemsSource = data;
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
        if (DataGridKafedras.SelectedItem is KafedraDto selected)
        {
            _editingId = selected.Id;
            TextBoxName.Text = selected.Name;
            TextBoxShortName.Text = selected.ShortName;
            TextBoxDescription.Text = selected.Description ?? "";
        }
        else
        {
            MessageBox.Show("Выберите запись для редактирования", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
        }
    }

    private async void DeleteButton_Click(object sender, RoutedEventArgs e)
    {
        if (DataGridKafedras.SelectedItem is KafedraDto selected)
        {
            var result = MessageBox.Show($"Удалить кафедру \"{selected.Name}\"?", "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Question);
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

        if (string.IsNullOrWhiteSpace(TextBoxShortName.Text))
        {
            MessageBox.Show("Введите сокращение", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            return;
        }

        if (_editingId.HasValue)
        {
            var request = new UpdateKafedraRequest(
                _editingId.Value,
                TextBoxName.Text,
                TextBoxShortName.Text,
                string.IsNullOrWhiteSpace(TextBoxDescription.Text) ? null : TextBoxDescription.Text);
            await _updateHandler.ExecuteAsync(request);
        }
        else
        {
            var request = new CreateKafedraRequest(
                TextBoxName.Text,
                TextBoxShortName.Text,
                string.IsNullOrWhiteSpace(TextBoxDescription.Text) ? null : TextBoxDescription.Text);
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
        TextBoxShortName.Text = "";
        TextBoxDescription.Text = "";
    }
}
