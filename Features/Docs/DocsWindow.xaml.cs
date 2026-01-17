using System.Windows;
using asugaksharp.Features.Person;

namespace asugaksharp.Features.Docs;

public partial class DocsWindow : Window
{
    private readonly GetDocsHandler _getHandler;
    private readonly CreateDocsHandler _createHandler;
    private readonly UpdateDocsHandler _updateHandler;
    private readonly DeleteDocsHandler _deleteHandler;
    private readonly GetPersonsHandler _getPersonsHandler;

    private Guid? _editingId = null;

    public DocsWindow(
        GetDocsHandler getHandler,
        CreateDocsHandler createHandler,
        UpdateDocsHandler updateHandler,
        DeleteDocsHandler deleteHandler,
        GetPersonsHandler getPersonsHandler)
    {
        InitializeComponent();

        _getHandler = getHandler;
        _createHandler = createHandler;
        _updateHandler = updateHandler;
        _deleteHandler = deleteHandler;
        _getPersonsHandler = getPersonsHandler;

        Loaded += async (s, e) => await LoadDataAsync();
    }

    private async Task LoadDataAsync()
    {
        var data = await _getHandler.ExecuteAsync();
        DataGridItems.ItemsSource = data;

        var persons = await _getPersonsHandler.ExecuteAsync();
        ComboBoxPerson.ItemsSource = persons;
    }

    private void AddButton_Click(object sender, RoutedEventArgs e)
    {
        _editingId = null;
        ClearForm();
    }

    private void EditButton_Click(object sender, RoutedEventArgs e)
    {
        if (DataGridItems.SelectedItem is DocsDto selected)
        {
            _editingId = selected.Id;
            TextBoxName.Text = selected.Name;
            TextBoxData.Text = selected.Data;
            CheckBoxIsUploaded.IsChecked = selected.IsUploaded;

            var persons = ComboBoxPerson.ItemsSource as List<PersonDto>;
            ComboBoxPerson.SelectedItem = persons?.FirstOrDefault(p => p.Id == selected.PersonId);
        }
        else
        {
            MessageBox.Show("Выберите запись для редактирования", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
        }
    }

    private async void DeleteButton_Click(object sender, RoutedEventArgs e)
    {
        if (DataGridItems.SelectedItem is DocsDto selected)
        {
            var result = MessageBox.Show($"Удалить документ \"{selected.Name}\"?", "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Question);
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
            MessageBox.Show("Введите название документа", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            return;
        }

        if (ComboBoxPerson.SelectedItem is not PersonDto selectedPerson)
        {
            MessageBox.Show("Выберите сотрудника", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            return;
        }

        if (_editingId.HasValue)
        {
            var request = new UpdateDocsRequest(
                _editingId.Value,
                TextBoxName.Text,
                CheckBoxIsUploaded.IsChecked ?? false,
                TextBoxData.Text ?? "",
                selectedPerson.Id);
            await _updateHandler.ExecuteAsync(request);
        }
        else
        {
            var request = new CreateDocsRequest(
                TextBoxName.Text,
                CheckBoxIsUploaded.IsChecked ?? false,
                TextBoxData.Text ?? "",
                selectedPerson.Id);
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
        TextBoxData.Text = "";
        CheckBoxIsUploaded.IsChecked = false;
        ComboBoxPerson.SelectedItem = null;
    }
}
