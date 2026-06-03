using System.Windows;
using System.Windows.Controls;
using asugaksharp.Core;
using asugaksharp.Features.Person;
using asugaksharp.Features.ProfilPodgotovki;
using NPetrovichLite;

namespace asugaksharp.Features.Diplomnik;

public partial class DiplomnikWindow : Window
{
    private readonly GetDiplomniksHandler _getHandler;
    private readonly CreateDiplomnikHandler _createHandler;
    private readonly UpdateDiplomnikHandler _updateHandler;
    private readonly DeleteDiplomnikHandler _deleteHandler;
    private readonly GetPersonsHandler _getPersonsHandler;
    private readonly GetProfilPodgotovkisHandler _getProfilHandler;

    private ComboBox[] _konsultantBoxes = null!;
    private Guid? _editingId;
    private bool _fioRoditAutoFilled;
    private bool _suppressFioRoditChanged;

    public DiplomnikWindow(
        GetDiplomniksHandler getHandler,
        CreateDiplomnikHandler createHandler,
        UpdateDiplomnikHandler updateHandler,
        DeleteDiplomnikHandler deleteHandler,
        GetPersonsHandler getPersonsHandler,
        GetProfilPodgotovkisHandler getProfilHandler)
    {
        InitializeComponent();

        _getHandler = getHandler;
        _createHandler = createHandler;
        _updateHandler = updateHandler;
        _deleteHandler = deleteHandler;
        _getPersonsHandler = getPersonsHandler;
        _getProfilHandler = getProfilHandler;

        _konsultantBoxes = new[] { ComboBoxK1, ComboBoxK2, ComboBoxK3, ComboBoxK4, ComboBoxK5 };

        Loaded += async (_, _) => await LoadDataAsync();
    }

    private async Task LoadDataAsync()
    {
        var diplomniks = await _getHandler.ExecuteAsync();
        DataGridDiplomniki.ItemsSource = diplomniks;

        var persons = await _getPersonsHandler.ExecuteAsync();
        ComboBoxRukovoditel.ItemsSource = persons;
        foreach (var box in _konsultantBoxes)
            box.ItemsSource = persons;

        var profils = await _getProfilHandler.ExecuteAsync();
        ComboBoxProfil.ItemsSource = profils;
    }

    private void AddButton_Click(object sender, RoutedEventArgs e)
    {
        _editingId = null;
        ClearForm();
    }

    private void EditButton_Click(object sender, RoutedEventArgs e)
    {
        if (DataGridDiplomniki.SelectedItem is not DiplomnikDto selected)
        {
            MessageBox.Show("Выберите запись для редактирования", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
            return;
        }

        _editingId = selected.Id;
        TextBoxFioImen.Text = selected.FioImen;
        TextBoxFioRodit.Text = selected.FioRodit;

        ComboBoxSex.SelectedIndex = selected.Sex == "М" ? 0 : selected.Sex == "Ж" ? 1 : -1;
        TextBoxPages.Text = selected.Pages.ToString();
        TextBoxTema.Text = selected.Tema;
        TextBoxOrigVkr.Text = selected.OrigVkr.ToString();
        TextBoxSrball.Text = selected.Srball.ToString();

        ComboBoxRukovoditel.SelectedValue = selected.PersonId;
        ComboBoxProfil.SelectedValue = selected.ProfilPodgotovkiId;

        for (int i = 0; i < _konsultantBoxes.Length; i++)
        {
            _konsultantBoxes[i].SelectedValue = i < selected.Konsultanty.Count
                ? selected.Konsultanty[i].PersonId
                : null;
        }
    }

    private async void DeleteButton_Click(object sender, RoutedEventArgs e)
    {
        if (DataGridDiplomniki.SelectedItem is not DiplomnikDto selected)
        {
            MessageBox.Show("Выберите запись для удаления", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
            return;
        }

        var result = MessageBox.Show(
            $"Удалить дипломника «{selected.FioImen}»?",
            "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Question);

        if (result == MessageBoxResult.Yes)
        {
            await _deleteHandler.ExecuteAsync(selected.Id);
            await LoadDataAsync();
            ClearForm();
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
            MessageBox.Show("Введите ФИО в именительном падеже", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            return;
        }

        if (string.IsNullOrWhiteSpace(TextBoxFioRodit.Text))
        {
            MessageBox.Show("Введите ФИО в родительном падеже", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
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

        if (ComboBoxRukovoditel.SelectedValue is not Guid rukovoditelId)
        {
            MessageBox.Show("Выберите руководителя", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            return;
        }

        var sex = ((ComboBoxItem)ComboBoxSex.SelectedItem).Content.ToString()!;
        var profilId = ComboBoxProfil.SelectedValue as Guid?;

        var konsultantIds = _konsultantBoxes
            .Select(b => b.SelectedValue as Guid?)
            .Where(id => id.HasValue)
            .Select(id => id!.Value)
            .Distinct()
            .Take(5)
            .ToList();

        if (_editingId.HasValue)
        {
            var request = new UpdateDiplomnikRequest(
                _editingId.Value,
                TextBoxFioImen.Text.Trim(),
                TextBoxFioRodit.Text.Trim(),
                sex, pages,
                TextBoxTema.Text.Trim(),
                origVkr, srball,
                rukovoditelId, profilId,
                konsultantIds);
            await _updateHandler.ExecuteAsync(request);
        }
        else
        {
            var request = new CreateDiplomnikRequest(
                TextBoxFioImen.Text.Trim(),
                TextBoxFioRodit.Text.Trim(),
                sex, pages,
                TextBoxTema.Text.Trim(),
                origVkr, srball,
                rukovoditelId, profilId,
                konsultantIds);
            await _createHandler.ExecuteAsync(request);
        }

        await LoadDataAsync();
        ClearForm();
    }

    private void CancelButton_Click(object sender, RoutedEventArgs e) => ClearForm();

    private void TextBoxFioImen_LostFocus(object sender, RoutedEventArgs e)
    {
        if (string.IsNullOrWhiteSpace(TextBoxFioImen.Text)) return;
        if (!string.IsNullOrWhiteSpace(TextBoxFioRodit.Text)) return;

        SetFioRodit(Inflect());
    }

    private void TextBoxFioRodit_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
    {
        if (!_suppressFioRoditChanged)
            _fioRoditAutoFilled = false;
    }

    private void ComboBoxSex_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
    {
        if (_fioRoditAutoFilled && !string.IsNullOrWhiteSpace(TextBoxFioImen.Text))
            SetFioRodit(Inflect());
    }

    private void BtnInflect_Click(object sender, RoutedEventArgs e)
    {
        if (string.IsNullOrWhiteSpace(TextBoxFioImen.Text)) return;
        SetFioRodit(Inflect());
    }

    private void SetFioRodit(string value)
    {
        _suppressFioRoditChanged = true;
        TextBoxFioRodit.Text = value;
        _suppressFioRoditChanged = false;
        _fioRoditAutoFilled = true;
    }

    private string Inflect()
    {
        var gender = ComboBoxSex.SelectedIndex == 1 ? Gender.Female : Gender.Male;
        return RussianNameInflector.ToDative(TextBoxFioImen.Text, gender);
    }

    private void ClearForm()
    {
        _editingId = null;
        _fioRoditAutoFilled = false;
        TextBoxFioImen.Text = "";
        TextBoxFioRodit.Text = "";
        ComboBoxSex.SelectedIndex = -1;
        TextBoxPages.Text = "";
        TextBoxTema.Text = "";
        TextBoxOrigVkr.Text = "";
        TextBoxSrball.Text = "";
        ComboBoxRukovoditel.SelectedIndex = -1;
        ComboBoxProfil.SelectedIndex = -1;
        foreach (var box in _konsultantBoxes)
            box.SelectedIndex = -1;
    }
}
