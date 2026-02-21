using System.Windows;
using System.Windows.Controls;
using asugaksharp.Features.Person;

namespace asugaksharp.Features.Student;

public partial class StudentWindow : Window
{
    private readonly GetStudentsHandler _getHandler;
    private readonly CreateStudentHandler _createHandler;
    private readonly UpdateStudentHandler _updateHandler;
    private readonly DeleteStudentHandler _deleteHandler;
    private readonly GetPersonsHandler _getPersonsHandler;

    private Guid? _editingId = null;

    public StudentWindow(
        GetStudentsHandler getHandler,
        CreateStudentHandler createHandler,
        UpdateStudentHandler updateHandler,
        DeleteStudentHandler deleteHandler,
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
        try
        {
            var data = await _getHandler.ExecuteAsync() ?? new List<StudentDto>();
            DataGridStudents.ItemsSource = data;

            var persons = await _getPersonsHandler.ExecuteAsync() ?? new List<PersonDto>();
            ComboBoxPerson.ItemsSource = persons;
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
        if (DataGridStudents.SelectedItem is StudentDto selected)
        {
            _editingId = selected.Id;
            TextBoxFioImen.Text = selected.FioImen;
            TextBoxFioRodit.Text = selected.FioRodit;
            ComboBoxSex.Text = selected.Sex;
            TextBoxPages.Text = selected.Pages.ToString();
            TextBoxTema.Text = selected.Tema;
            TextBoxOrigVkr.Text = selected.OrigVkr.ToString();
            TextBoxSrball.Text = selected.Srball.ToString();
            ComboBoxPerson.SelectedValue = selected.PersonId;
        }
        else
        {
            MessageBox.Show("Выберите запись для редактирования", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
        }
    }

    private async void DeleteButton_Click(object sender, RoutedEventArgs e)
    {
        if (DataGridStudents.SelectedItem is StudentDto selected)
        {
            var result = MessageBox.Show($"Удалить студента \"{selected.FioImen}\"?", "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Question);
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
        if (string.IsNullOrWhiteSpace(TextBoxFioImen.Text))
        {
            MessageBox.Show("Введите ФИО (им.)", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            return;
        }

        if (string.IsNullOrWhiteSpace(TextBoxFioRodit.Text))
        {
            MessageBox.Show("Введите ФИО (род.)", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            return;
        }

        if (ComboBoxSex.SelectedItem == null)
        {
            MessageBox.Show("Выберите пол", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            return;
        }

        if (!int.TryParse(TextBoxPages.Text, out int pages))
        {
            MessageBox.Show("Введите корректное количество страниц", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            return;
        }

        if (!float.TryParse(TextBoxOrigVkr.Text, out float origVkr))
        {
            MessageBox.Show("Введите корректную оригинальность", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            return;
        }

        if (!float.TryParse(TextBoxSrball.Text, out float srball))
        {
            MessageBox.Show("Введите корректный средний балл", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            return;
        }

        if (ComboBoxPerson.SelectedValue == null)
        {
            MessageBox.Show("Выберите руководителя", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            return;
        }

        var sex = ((ComboBoxItem)ComboBoxSex.SelectedItem).Content.ToString()!;
        var personId = (Guid)ComboBoxPerson.SelectedValue;

        if (_editingId.HasValue)
        {
            var request = new UpdateStudentRequest(
                _editingId.Value,
                TextBoxFioImen.Text,
                TextBoxFioRodit.Text,
                sex,
                pages,
                TextBoxTema.Text,
                origVkr,
                srball,
                personId);
            await _updateHandler.ExecuteAsync(request);
        }
        else
        {
            var request = new CreateStudentRequest(
                TextBoxFioImen.Text,
                TextBoxFioRodit.Text,
                sex,
                pages,
                TextBoxTema.Text,
                origVkr,
                srball,
                personId);
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
        TextBoxFioImen.Text = "";
        TextBoxFioRodit.Text = "";
        ComboBoxSex.SelectedIndex = -1;
        TextBoxPages.Text = "";
        TextBoxTema.Text = "";
        TextBoxOrigVkr.Text = "";
        TextBoxSrball.Text = "";
        ComboBoxPerson.SelectedIndex = -1;
    }
}
