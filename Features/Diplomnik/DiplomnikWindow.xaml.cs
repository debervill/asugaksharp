using System.Windows;
using asugaksharp.Features.Student;
using asugaksharp.Features.Zasedanie;
namespace asugaksharp.Features.Diplomnik;

public partial class DiplomnikWindow : Window
{
    private readonly GetDiplomniksHandler _getHandler;
    private readonly CreateDiplomnikHandler _createHandler;
    private readonly UpdateDiplomnikHandler _updateHandler;
    private readonly DeleteDiplomnikHandler _deleteHandler;
    private readonly GetZasedaniesHandler _getZasedaniesHandler;
    private readonly GetStudentsHandler _getStudentsHandler;

    private Guid? _editingId = null;

    public DiplomnikWindow(
        GetDiplomniksHandler getHandler,
        CreateDiplomnikHandler createHandler,
        UpdateDiplomnikHandler updateHandler,
        DeleteDiplomnikHandler deleteHandler,
        GetZasedaniesHandler getZasedaniesHandler,
        GetStudentsHandler getStudentsHandler)
    {
        InitializeComponent();

        _getHandler = getHandler;
        _createHandler = createHandler;
        _updateHandler = updateHandler;
        _deleteHandler = deleteHandler;
        _getZasedaniesHandler = getZasedaniesHandler;
        _getStudentsHandler = getStudentsHandler;

        Loaded += async (s, e) => await LoadDataAsync();
    }

    private async Task LoadDataAsync()
    {
        try
        {
            var data = await _getHandler.ExecuteAsync() ?? new List<DiplomnikDto>();
            DataGridDiplomniki.ItemsSource = data;

            var students = await _getStudentsHandler.ExecuteAsync() ?? new List<StudentDto>();
            ComboBoxStudent.ItemsSource = students;

            var zasedanies = await _getZasedaniesHandler.ExecuteAsync() ?? new List<ZasedanieDto>();
            ComboBoxZasedanie.ItemsSource = zasedanies;
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
        if (DataGridDiplomniki.SelectedItem is DiplomnikDto selected)
        {
            _editingId = selected.Id;
            ComboBoxStudent.SelectedValue = selected.StudentId;
            ComboBoxZasedanie.SelectedValue = selected.ZasedanieId;
        }
        else
        {
            MessageBox.Show("Выберите запись для редактирования", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
        }
    }

    private async void DeleteButton_Click(object sender, RoutedEventArgs e)
    {
        if (DataGridDiplomniki.SelectedItem is DiplomnikDto selected)
        {
            var result = MessageBox.Show($"Удалить дипломника \"{selected.FioImen}\"?", "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Question);
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
        if (ComboBoxStudent.SelectedValue == null)
        {
            MessageBox.Show("Выберите студента", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            return;
        }

        if (ComboBoxZasedanie.SelectedValue == null)
        {
            MessageBox.Show("Выберите заседание", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            return;
        }

        var studentId = (Guid)ComboBoxStudent.SelectedValue;
        var zasedanieId = (Guid)ComboBoxZasedanie.SelectedValue;

        if (_editingId.HasValue)
        {
            var request = new UpdateDiplomnikRequest(
                _editingId.Value,
                studentId,
                zasedanieId);
            await _updateHandler.ExecuteAsync(request);
        }
        else
        {
            var request = new CreateDiplomnikRequest(
                studentId,
                zasedanieId);
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
        ComboBoxStudent.SelectedIndex = -1;
        ComboBoxZasedanie.SelectedIndex = -1;
    }
}
