using System.Windows;

namespace asugaksharp.Features.ProfilPodgotovki;

public partial class ProfilPodgotovkiWindow : Window
{
    private readonly GetProfilPodgotovkisHandler _getHandler;
    private readonly CreateProfilPodgotovkiHandler _createHandler;
    private readonly UpdateProfilPodgotovkiHandler _updateHandler;
    private readonly DeleteProfilPodgotovkiHandler _deleteHandler;
    private readonly NapravleniePodgotovki.GetNapravleniePodgotovkisHandler _getNapravleniePodgotovkisHandler;

    private Guid? _editingId = null;

    public ProfilPodgotovkiWindow(
        GetProfilPodgotovkisHandler getHandler,
        CreateProfilPodgotovkiHandler createHandler,
        UpdateProfilPodgotovkiHandler updateHandler,
        DeleteProfilPodgotovkiHandler deleteHandler,
        NapravleniePodgotovki.GetNapravleniePodgotovkisHandler getNapravleniePodgotovkisHandler)
    {
        InitializeComponent();

        _getHandler = getHandler;
        _createHandler = createHandler;
        _updateHandler = updateHandler;
        _deleteHandler = deleteHandler;
        _getNapravleniePodgotovkisHandler = getNapravleniePodgotovkisHandler;

        Loaded += async (s, e) => await LoadDataAsync();
    }

    private async Task LoadDataAsync()
    {
        var data = await _getHandler.ExecuteAsync();
        DataGridProfilPodgotovkis.ItemsSource = data;

        var napravleniePodgotovkis = await _getNapravleniePodgotovkisHandler.ExecuteAsync();
        ComboBoxNapravleniePodgotovki.ItemsSource = napravleniePodgotovkis;
    }

    private void AddButton_Click(object sender, RoutedEventArgs e)
    {
        _editingId = null;
        ClearForm();
    }

    private void EditButton_Click(object sender, RoutedEventArgs e)
    {
        if (DataGridProfilPodgotovkis.SelectedItem is ProfilPodgotovkiDto selected)
        {
            _editingId = selected.Id;
            TextBoxName.Text = selected.Name;
            TextBoxShifrPodgot.Text = selected.ShifrPodgot;
            ComboBoxNapravleniePodgotovki.SelectedValue = selected.NapravleniePodgotovkiId;
        }
        else
        {
            MessageBox.Show("Выберите запись для редактирования", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
        }
    }

    private async void DeleteButton_Click(object sender, RoutedEventArgs e)
    {
        if (DataGridProfilPodgotovkis.SelectedItem is ProfilPodgotovkiDto selected)
        {
            var result = MessageBox.Show($"Удалить профиль подготовки \"{selected.Name}\"?", "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Question);
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

        if (string.IsNullOrWhiteSpace(TextBoxShifrPodgot.Text))
        {
            MessageBox.Show("Введите шифр подготовки", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            return;
        }

        if (ComboBoxNapravleniePodgotovki.SelectedValue == null)
        {
            MessageBox.Show("Выберите направление подготовки", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            return;
        }

        var napravleniePodgotovkiId = (Guid)ComboBoxNapravleniePodgotovki.SelectedValue;

        if (_editingId.HasValue)
        {
            var request = new UpdateProfilPodgotovkiRequest(
                _editingId.Value,
                TextBoxName.Text,
                TextBoxShifrPodgot.Text,
                napravleniePodgotovkiId);
            await _updateHandler.ExecuteAsync(request);
        }
        else
        {
            var request = new CreateProfilPodgotovkiRequest(
                TextBoxName.Text,
                TextBoxShifrPodgot.Text,
                napravleniePodgotovkiId);
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
        TextBoxShifrPodgot.Text = "";
        ComboBoxNapravleniePodgotovki.SelectedIndex = -1;
    }
}
