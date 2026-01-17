using System.Windows;
using asugaksharp.Features.Person;

namespace asugaksharp.Features.Oplata;

public partial class OplataWindow : Window
{
    private readonly GetOplatasHandler _getHandler;
    private readonly CreateOplataHandler _createHandler;
    private readonly UpdateOplataHandler _updateHandler;
    private readonly DeleteOplataHandler _deleteHandler;
    private readonly GetPersonsHandler _getPersonsHandler;

    private Guid? _editingId = null;

    public OplataWindow(
        GetOplatasHandler getHandler,
        CreateOplataHandler createHandler,
        UpdateOplataHandler updateHandler,
        DeleteOplataHandler deleteHandler,
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
        if (DataGridItems.SelectedItem is OplataDto selected)
        {
            _editingId = selected.Id;
            TextBoxStavka.Text = selected.Stavka.ToString();
            TextBoxNdfl.Text = selected.Ndfl.ToString();
            TextBoxEnp.Text = selected.Enp.ToString();
            TextBoxMoneySource.Text = selected.MoneySource.ToString();
            TextBoxDogovorNumber.Text = selected.DogovorNumber.ToString();

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
        if (DataGridItems.SelectedItem is OplataDto selected)
        {
            var result = MessageBox.Show($"Удалить запись об оплате для \"{selected.PersonName}\"?", "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Question);
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
        if (ComboBoxPerson.SelectedItem is not PersonDto selectedPerson)
        {
            MessageBox.Show("Выберите сотрудника", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            return;
        }

        if (!float.TryParse(TextBoxStavka.Text, out var stavka))
        {
            MessageBox.Show("Введите корректное значение ставки", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            return;
        }

        if (!float.TryParse(TextBoxNdfl.Text, out var ndfl))
        {
            MessageBox.Show("Введите корректное значение НДФЛ", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            return;
        }

        if (!float.TryParse(TextBoxEnp.Text, out var enp))
        {
            MessageBox.Show("Введите корректное значение ЕНП", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            return;
        }

        if (!int.TryParse(TextBoxMoneySource.Text, out var moneySource))
        {
            MessageBox.Show("Введите корректный источник финансирования", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            return;
        }

        if (!int.TryParse(TextBoxDogovorNumber.Text, out var dogovorNumber))
        {
            MessageBox.Show("Введите корректный номер договора", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            return;
        }

        if (_editingId.HasValue)
        {
            var request = new UpdateOplataRequest(
                _editingId.Value,
                stavka,
                ndfl,
                enp,
                moneySource,
                dogovorNumber,
                selectedPerson.Id);
            await _updateHandler.ExecuteAsync(request);
        }
        else
        {
            var request = new CreateOplataRequest(
                stavka,
                ndfl,
                enp,
                moneySource,
                dogovorNumber,
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
        TextBoxStavka.Text = "";
        TextBoxNdfl.Text = "";
        TextBoxEnp.Text = "";
        TextBoxMoneySource.Text = "";
        TextBoxDogovorNumber.Text = "";
        ComboBoxPerson.SelectedItem = null;
    }
}
