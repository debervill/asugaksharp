using System.Windows;

namespace asugaksharp.Features.Person;

public partial class PersonalDataWindow : Window
{
    private readonly GetPersonalDataHandler _getHandler;
    private readonly UpdatePersonalDataHandler _updateHandler;
    private readonly Guid _personId;

    public PersonalDataWindow(
        GetPersonalDataHandler getHandler,
        UpdatePersonalDataHandler updateHandler,
        Guid personId)
    {
        InitializeComponent();

        _getHandler = getHandler;
        _updateHandler = updateHandler;
        _personId = personId;

        Loaded += async (s, e) => await LoadDataAsync();
    }

    private async Task LoadDataAsync()
    {
        var data = await _getHandler.ExecuteAsync(_personId);

        if (data == null)
        {
            MessageBox.Show("Сотрудник не найден", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            Close();
            return;
        }

        TextBlockName.Text = data.Name;
        TextBoxPassportSeria.Text = data.PassportSeria ?? "";
        TextBoxPassportNomer.Text = data.PassportNomer ?? "";
        TextBoxPassportIssuedBy.Text = data.PassportIssuedBy ?? "";
        TextBoxRegistrationAddress.Text = data.RegistrationAddress ?? "";
        TextBoxSnils.Text = data.Snils ?? "";
        TextBoxInn.Text = data.Inn ?? "";
        TextBoxEmail.Text = data.Email ?? "";
        TextBoxPhone.Text = data.Phone ?? "";
    }

    private async void SaveButton_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            var request = new UpdatePersonalDataRequest(
                _personId,
                string.IsNullOrWhiteSpace(TextBoxPassportSeria.Text) ? null : TextBoxPassportSeria.Text.Trim(),
                string.IsNullOrWhiteSpace(TextBoxPassportNomer.Text) ? null : TextBoxPassportNomer.Text.Trim(),
                string.IsNullOrWhiteSpace(TextBoxPassportIssuedBy.Text) ? null : TextBoxPassportIssuedBy.Text.Trim(),
                string.IsNullOrWhiteSpace(TextBoxRegistrationAddress.Text) ? null : TextBoxRegistrationAddress.Text.Trim(),
                string.IsNullOrWhiteSpace(TextBoxSnils.Text) ? null : TextBoxSnils.Text.Trim(),
                string.IsNullOrWhiteSpace(TextBoxInn.Text) ? null : TextBoxInn.Text.Trim(),
                string.IsNullOrWhiteSpace(TextBoxEmail.Text) ? null : TextBoxEmail.Text.Trim(),
                string.IsNullOrWhiteSpace(TextBoxPhone.Text) ? null : TextBoxPhone.Text.Trim());

            await _updateHandler.ExecuteAsync(request);

            MessageBox.Show("Данные сохранены", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
            DialogResult = true;
            Close();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Ошибка сохранения: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }

    private void CancelButton_Click(object sender, RoutedEventArgs e)
    {
        DialogResult = false;
        Close();
    }
}
