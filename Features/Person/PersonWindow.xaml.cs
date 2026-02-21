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

    private readonly PersonFormViewModel _form = new();
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
        try
        {
            var selectedFilterId = (ComboBoxKafedraFilter.SelectedItem as KafedraDto)?.Id;

            _allPersons = await _getHandler.ExecuteAsync() ?? new List<PersonDto>();

            var kafedras = await _getKafedrasHandler.ExecuteAsync() ?? new List<KafedraDto>();
            ComboBoxKafedra.ItemsSource = kafedras;
            ComboBoxKafedraFilter.ItemsSource = kafedras;

            if (selectedFilterId.HasValue && kafedras.Count > 0)
                ComboBoxKafedraFilter.SelectedItem = kafedras.FirstOrDefault(k => k.Id == selectedFilterId.Value);

            ApplyFilter();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Ошибка загрузки данных: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }

    private void AddButton_Click(object sender, RoutedEventArgs e)
    {
        _form.Clear();
        SyncFormToUI();
    }

    private void EditButton_Click(object sender, RoutedEventArgs e)
    {
        if (DataGridItems.SelectedItem is PersonDto selected)
        {
            _form.LoadForEdit(selected);
            SyncFormToUI();
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
                _form.Clear();
                SyncFormToUI();
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
        SyncUIToForm();

        var error = _form.Validate();
        if (error != null)
        {
            MessageBox.Show(error, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            return;
        }

        if (_form.IsEditing)
            await _updateHandler.ExecuteAsync(_form.ToUpdateRequest());
        else
            await _createHandler.ExecuteAsync(_form.ToCreateRequest());

        await LoadDataAsync();
        _form.Clear();
        SyncFormToUI();
    }

    private void CancelButton_Click(object sender, RoutedEventArgs e)
    {
        _form.Clear();
        SyncFormToUI();
    }

    private void ComboBoxKafedraFilter_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
    {
        ApplyFilter();
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

    private void ApplyFilter()
    {
        if (ComboBoxKafedraFilter.SelectedItem is KafedraDto selectedKafedra && _allPersons != null)
            DataGridItems.ItemsSource = _allPersons.Where(p => p.KafedraId == selectedKafedra.Id).ToList();
        else
            DataGridItems.ItemsSource = new List<PersonDto>();

        DataGridItems.SelectedItem = null;
    }

    private void SyncFormToUI()
    {
        TextBoxName.Text = _form.Name;
        TextBoxStepen.Text = _form.Stepen;
        TextBoxZvanie.Text = _form.Zvanie;
        TextBoxDolgnost.Text = _form.Dolgnost;
        CheckBoxPredsed.IsChecked = _form.IsPredsed;
        CheckBoxZavKaf.IsChecked = _form.IsZavKaf;
        CheckBoxSecretar.IsChecked = _form.IsSecretar;
        CheckBoxRecenzent.IsChecked = _form.IsRecenzent;
        CheckBoxVneshniy.IsChecked = _form.IsVneshniy;

        var kafedras = ComboBoxKafedra.ItemsSource as List<KafedraDto>;
        ComboBoxKafedra.SelectedItem = kafedras?.FirstOrDefault(k => k.Id == _form.KafedraId);
    }

    private void SyncUIToForm()
    {
        _form.Name = TextBoxName.Text;
        _form.Stepen = TextBoxStepen.Text ?? "";
        _form.Zvanie = TextBoxZvanie.Text ?? "";
        _form.Dolgnost = TextBoxDolgnost.Text ?? "";
        _form.IsPredsed = CheckBoxPredsed.IsChecked ?? false;
        _form.IsZavKaf = CheckBoxZavKaf.IsChecked ?? false;
        _form.IsSecretar = CheckBoxSecretar.IsChecked ?? false;
        _form.IsRecenzent = CheckBoxRecenzent.IsChecked ?? false;
        _form.IsVneshniy = CheckBoxVneshniy.IsChecked ?? false;
        _form.KafedraId = (ComboBoxKafedra.SelectedItem as KafedraDto)?.Id;
    }
}
