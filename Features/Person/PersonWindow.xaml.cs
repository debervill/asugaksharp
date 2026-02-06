using System.Windows;
using asugaksharp.Features.Kafedra;

namespace asugaksharp.Features.Person;

public partial class PersonWindow : Window
{
    private readonly GetPersonsHandler _getHandler;
    private readonly CreatePersonHandler _createHandler;
    private readonly UpdatePersonHandler _updateHandler;
    private readonly DeletePersonHandler _deleteHandler;
    private readonly GetKafedrasHandler _getKafedrasHandler;
    private readonly GetPersonalDataHandler _getPersonalDataHandler;
    private readonly UpdatePersonalDataHandler _updatePersonalDataHandler;

    private Guid? _editingId = null;
    private List<PersonDto> _allPersons = new();

    public PersonWindow(
        GetPersonsHandler getHandler,
        CreatePersonHandler createHandler,
        UpdatePersonHandler updateHandler,
        DeletePersonHandler deleteHandler,
        GetKafedrasHandler getKafedrasHandler,
        GetPersonalDataHandler getPersonalDataHandler,
        UpdatePersonalDataHandler updatePersonalDataHandler)
    {
        InitializeComponent();

        _getHandler = getHandler;
        _createHandler = createHandler;
        _updateHandler = updateHandler;
        _deleteHandler = deleteHandler;
        _getKafedrasHandler = getKafedrasHandler;
        _getPersonalDataHandler = getPersonalDataHandler;
        _updatePersonalDataHandler = updatePersonalDataHandler;

        Loaded += async (s, e) => await LoadDataAsync();
    }

    private async Task LoadDataAsync()
    {
        var selectedFilterId = (ComboBoxKafedraFilter.SelectedItem as KafedraDto)?.Id;

        _allPersons = await _getHandler.ExecuteAsync();

        var kafedras = await _getKafedrasHandler.ExecuteAsync();
        ComboBoxKafedra.ItemsSource = kafedras;
        ComboBoxKafedraFilter.ItemsSource = kafedras;

        if (selectedFilterId.HasValue)
            ComboBoxKafedraFilter.SelectedItem = kafedras.FirstOrDefault(k => k.Id == selectedFilterId.Value);

        ApplyFilter();
    }

    private void AddButton_Click(object sender, RoutedEventArgs e)
    {
        _editingId = null;
        ClearForm();
    }

    private void EditButton_Click(object sender, RoutedEventArgs e)
    {
        if (DataGridItems.SelectedItem is PersonDto selected)
        {
            _editingId = selected.Id;
            TextBoxName.Text = selected.Name;
            TextBoxStepen.Text = selected.Stepen;
            TextBoxZvanie.Text = selected.Zvanie;
            TextBoxDolgnost.Text = selected.Dolgnost;
            CheckBoxPredsed.IsChecked = selected.IsPredsed;
            CheckBoxZavKaf.IsChecked = selected.IsZavKaf;
            CheckBoxSecretar.IsChecked = selected.IsSecretar;
            CheckBoxRecenzent.IsChecked = selected.IsRecenzent;
            CheckBoxVneshniy.IsChecked = selected.IsVneshniy;

            var kafedras = ComboBoxKafedra.ItemsSource as List<KafedraDto>;
            ComboBoxKafedra.SelectedItem = kafedras?.FirstOrDefault(k => k.Id == selected.KafedraId);
        }
        else
        {
            MessageBox.Show("Выберите запись для редактирования", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
        }
    }

    private async void DeleteButton_Click(object sender, RoutedEventArgs e)
    {
        if (DataGridItems.SelectedItem is PersonDto selected)
        {
            var result = MessageBox.Show($"Удалить сотрудника \"{selected.Name}\"?", "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Question);
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
            MessageBox.Show("Введите ФИО", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            return;
        }

        if (ComboBoxKafedra.SelectedItem is not KafedraDto selectedKafedra)
        {
            MessageBox.Show("Выберите кафедру", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            return;
        }

        if (_editingId.HasValue)
        {
            var request = new UpdatePersonRequest(
                _editingId.Value,
                TextBoxName.Text,
                TextBoxStepen.Text ?? "",
                TextBoxZvanie.Text ?? "",
                TextBoxDolgnost.Text ?? "",
                CheckBoxPredsed.IsChecked ?? false,
                CheckBoxZavKaf.IsChecked ?? false,
                CheckBoxSecretar.IsChecked ?? false,
                CheckBoxRecenzent.IsChecked ?? false,
                CheckBoxVneshniy.IsChecked ?? false,
                selectedKafedra.Id);
            await _updateHandler.ExecuteAsync(request);
        }
        else
        {
            var request = new CreatePersonRequest(
                TextBoxName.Text,
                TextBoxStepen.Text ?? "",
                TextBoxZvanie.Text ?? "",
                TextBoxDolgnost.Text ?? "",
                CheckBoxPredsed.IsChecked ?? false,
                CheckBoxZavKaf.IsChecked ?? false,
                CheckBoxSecretar.IsChecked ?? false,
                CheckBoxRecenzent.IsChecked ?? false,
                CheckBoxVneshniy.IsChecked ?? false,
                selectedKafedra.Id);
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
        TextBoxStepen.Text = "";
        TextBoxZvanie.Text = "";
        TextBoxDolgnost.Text = "";
        CheckBoxPredsed.IsChecked = false;
        CheckBoxZavKaf.IsChecked = false;
        CheckBoxSecretar.IsChecked = false;
        CheckBoxRecenzent.IsChecked = false;
        CheckBoxVneshniy.IsChecked = false;
        ComboBoxKafedra.SelectedItem = null;
    }

    private void ComboBoxKafedraFilter_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
    {
        ApplyFilter();
    }

    private void ApplyFilter()
    {
        if (ComboBoxKafedraFilter.SelectedItem is not KafedraDto selectedKafedra)
        {
            DataGridItems.ItemsSource = new List<PersonDto>();
            DataGridItems.SelectedItem = null;
            return;
        }

        DataGridItems.ItemsSource = _allPersons
            .Where(p => p.KafedraId == selectedKafedra.Id)
            .ToList();
        DataGridItems.SelectedItem = null;
    }

    private void PersonalDataButton_Click(object sender, RoutedEventArgs e)
    {
        if (DataGridItems.SelectedItem is not PersonDto selected)
        {
            MessageBox.Show("Выберите сотрудника", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
            return;
        }

        var window = new PersonalDataWindow(
            _getPersonalDataHandler,
            _updatePersonalDataHandler,
            selected.Id);
        window.Owner = this;
        window.ShowDialog();
    }
}
