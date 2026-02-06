using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Microsoft.Win32;
using asugaksharp.Features.Kafedra;
using asugaksharp.Features.Gak;
using asugaksharp.Features.Komissiya;
using asugaksharp.Features.Docs;

namespace asugaksharp.Features.Oplata;

public partial class OplataWindow : Window
{
    private readonly GetKafedrasHandler _getKafedrasHandler;
    private readonly GetGaksByKafedraHandler _getGaksByKafedraHandler;
    private readonly GetGakInfoHandler _getGakInfoHandler;
    private readonly GetGakExternalMembersHandler _getGakExternalMembersHandler;
    private readonly GetOplatasByGakHandler _getOplatasByGakHandler;
    private readonly SaveOplatasByGakHandler _saveOplatasByGakHandler;
    private readonly GenerateDocumentHandler _generateDocumentHandler;

    private ObservableCollection<OplataRowDto> _oplataRows = new();
    private GakInfoDto? _currentGakInfo;
    private Guid _currentGakId;
    private string _documentsOutputPath = string.Empty;

    public OplataWindow(
        GetKafedrasHandler getKafedrasHandler,
        GetGaksByKafedraHandler getGaksByKafedraHandler,
        GetGakInfoHandler getGakInfoHandler,
        GetGakExternalMembersHandler getGakExternalMembersHandler,
        GetOplatasByGakHandler getOplatasByGakHandler,
        SaveOplatasByGakHandler saveOplatasByGakHandler,
        GenerateDocumentHandler generateDocumentHandler)
    {
        InitializeComponent();

        _getKafedrasHandler = getKafedrasHandler;
        _getGaksByKafedraHandler = getGaksByKafedraHandler;
        _getGakInfoHandler = getGakInfoHandler;
        _getGakExternalMembersHandler = getGakExternalMembersHandler;
        _getOplatasByGakHandler = getOplatasByGakHandler;
        _saveOplatasByGakHandler = saveOplatasByGakHandler;
        _generateDocumentHandler = generateDocumentHandler;

        DataGridOplata.ItemsSource = _oplataRows;
        DataGridOplata.SelectionChanged += DataGridOplata_SelectionChanged;

        Loaded += async (s, e) => await LoadKafedrasAsync();
    }

    private async Task LoadKafedrasAsync()
    {
        var kafedras = await _getKafedrasHandler.ExecuteAsync();
        ComboBoxKafedra.ItemsSource = kafedras;
    }

    private async void ComboBoxKafedra_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (ComboBoxKafedra.SelectedItem is KafedraDto kafedra)
        {
            var gaks = await _getGaksByKafedraHandler.ExecuteAsync(kafedra.Id);
            ComboBoxGak.ItemsSource = gaks;
            ComboBoxGak.SelectedItem = null;
            ClearAll();
        }
    }

    private async void LoadButton_Click(object sender, RoutedEventArgs e)
    {
        if (ComboBoxKafedra.SelectedItem is not KafedraDto)
        {
            MessageBox.Show("Выберите кафедру", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
            return;
        }

        if (ComboBoxGak.SelectedItem is not GakDto gak)
        {
            MessageBox.Show("Выберите ГАК", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
            return;
        }

        await LoadDataAsync(gak.Id);
    }

    private async Task LoadDataAsync(Guid gakId)
    {
        _currentGakId = gakId;

        // Загружаем информацию о ГАК
        _currentGakInfo = await _getGakInfoHandler.ExecuteAsync(gakId);
        if (_currentGakInfo != null)
        {
            TextBoxKolvoBudget.Text = _currentGakInfo.KolvoBudget.ToString();
            TextBoxKolvoPlatka.Text = _currentGakInfo.KolvoPlatka.ToString();
        }

        _oplataRows.Clear();

        // Сначала пробуем загрузить сохранённые расчёты
        var savedOplatas = await _getOplatasByGakHandler.ExecuteAsync(gakId);

        if (savedOplatas.Count > 0)
        {
            // Есть сохранённые расчёты - загружаем их
            foreach (var oplata in savedOplatas)
            {
                _oplataRows.Add(oplata);
            }
        }
        else
        {
            // Нет сохранённых - создаём из внешних членов комиссии
            var members = await _getGakExternalMembersHandler.ExecuteAsync(gakId);
            foreach (var member in members)
            {
                // Устанавливаем количество студентов по умолчанию из ГАК
                if (_currentGakInfo != null)
                {
                    member.KolvoBudget = _currentGakInfo.KolvoBudget;
                    member.KolvoPlatka = _currentGakInfo.KolvoPlatka;
                }
                _oplataRows.Add(member);
            }
        }

        ButtonSaveAll.IsEnabled = _oplataRows.Count > 0;
        ButtonDocuments.IsEnabled = _oplataRows.Count > 0;
        _documentsOutputPath = string.Empty; // Сбрасываем путь при загрузке нового ГАК
        UpdateTotals();
    }

    private void ApplyToAllButton_Click(object sender, RoutedEventArgs e)
    {
        if (!float.TryParse(TextBoxStoimostChasa.Text, out var stoimostChasa))
        {
            MessageBox.Show("Введите корректную стоимость часа", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            return;
        }

        foreach (var row in _oplataRows)
        {
            row.StoimostChasa = stoimostChasa;
            row.Recalculate();
        }

        UpdateTotals();
        DataGridOplata.Items.Refresh();
    }

    private void DataGridOplata_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
    {
        // После редактирования ячейки пересчитываем строку
        if (e.Row.Item is OplataRowDto row)
        {
            Dispatcher.BeginInvoke(new Action(() =>
            {
                row.Recalculate();
                UpdateTotals();
            }), System.Windows.Threading.DispatcherPriority.Background);
        }
    }

    private void UpdateTotals()
    {
        var totalNachisleno = _oplataRows.Sum(r => r.SummaBezNalogov);
        var totalNdfl = _oplataRows.Sum(r => r.NdflSumma);
        var totalEnp = _oplataRows.Sum(r => r.EnpSumma);
        var totalKVyplate = _oplataRows.Sum(r => r.SummaKVyplate);

        TextBoxTotalNachisleno.Text = totalNachisleno.ToString("F2");
        TextBoxTotalNdfl.Text = totalNdfl.ToString("F2");
        TextBoxTotalEnp.Text = totalEnp.ToString("F2");
        TextBoxTotalKVyplate.Text = totalKVyplate.ToString("F2");
    }

    private async void SaveAllButton_Click(object sender, RoutedEventArgs e)
    {
        // Валидация
        if (_oplataRows.Any(r => r.KolvoStudentov <= 0))
        {
            MessageBox.Show("Укажите количество студентов для всех членов комиссии", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            return;
        }

        if (_oplataRows.Any(r => r.StoimostChasa <= 0))
        {
            MessageBox.Show("Укажите стоимость часа для всех членов комиссии", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            return;
        }

        try
        {
            await _saveOplatasByGakHandler.ExecuteAsync(_currentGakId, _oplataRows.ToList());
            MessageBox.Show("Расчёт сохранён", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Ошибка сохранения: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }

    private void CopyMenuItem_Click(object sender, RoutedEventArgs e)
    {
        ApplicationCommands.Copy.Execute(null, DataGridOplata);
    }

    private void ClearAll()
    {
        _oplataRows.Clear();
        _currentGakInfo = null;
        TextBoxKolvoBudget.Text = "";
        TextBoxKolvoPlatka.Text = "";
        TextBoxStoimostChasa.Text = "";
        TextBoxTotalNachisleno.Text = "";
        TextBoxTotalNdfl.Text = "";
        TextBoxTotalEnp.Text = "";
        TextBoxTotalKVyplate.Text = "";
        ButtonSaveAll.IsEnabled = false;
        ButtonDocuments.IsEnabled = false;
    }

    private void DataGridOplata_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        UpdateMenuSelectedPersonState();
    }

    private void UpdateMenuSelectedPersonState()
    {
        var isRowSelected = DataGridOplata.SelectedItem is OplataRowDto row && row.OplataId != null;
        MenuSelectedPerson.IsEnabled = isRowSelected;

        // Обновляем заголовок подменю с именем выбранного человека
        if (isRowSelected && DataGridOplata.SelectedItem is OplataRowDto selectedRow)
        {
            MenuSelectedPerson.Header = $"Документы для: {selectedRow.PersonName}";
        }
        else
        {
            MenuSelectedPerson.Header = "Документы для выбранного... (выберите строку)";
        }
    }

    private void ButtonDocuments_Click(object sender, RoutedEventArgs e)
    {
        if (sender is Button button && button.ContextMenu != null)
        {
            // Обновляем состояние подменю перед открытием
            UpdateMenuSelectedPersonState();

            button.ContextMenu.PlacementTarget = button;
            button.ContextMenu.Placement = System.Windows.Controls.Primitives.PlacementMode.Bottom;
            button.ContextMenu.IsOpen = true;
        }
    }

    private string GetOrCreateOutputPath()
    {
        if (string.IsNullOrEmpty(_documentsOutputPath) || !Directory.Exists(_documentsOutputPath))
        {
            // Создаём папку для документов рядом с exe
            var basePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "GeneratedDocuments");

            // Добавляем папку для текущего ГАК
            if (_currentGakInfo != null)
            {
                var gakFolder = $"ГАК_{_currentGakInfo.NomerPrikaza}_{DateTime.Now:yyyy-MM-dd}";
                _documentsOutputPath = Path.Combine(basePath, gakFolder);
            }
            else
            {
                _documentsOutputPath = Path.Combine(basePath, DateTime.Now.ToString("yyyy-MM-dd_HH-mm"));
            }

            Directory.CreateDirectory(_documentsOutputPath);
        }
        return _documentsOutputPath;
    }

    private async void GenerateAllDocuments_Click(object sender, RoutedEventArgs e)
    {
        await GenerateDocumentsForGakAsync(null);
    }

    private async void GenerateDogovors_Click(object sender, RoutedEventArgs e)
    {
        await GenerateDocumentsForGakAsync(DocumentType.Dogovor);
    }

    private async void GenerateAkts_Click(object sender, RoutedEventArgs e)
    {
        await GenerateDocumentsForGakAsync(DocumentType.Akt);
    }

    private async void GenerateZayavleniya_Click(object sender, RoutedEventArgs e)
    {
        await GenerateDocumentsForGakAsync(DocumentType.Zayavlenie);
    }

    private async Task GenerateDocumentsForGakAsync(DocumentType? documentType)
    {
        if (_currentGakId == Guid.Empty)
        {
            MessageBox.Show("Сначала загрузите данные ГАК", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
            return;
        }

        var outputPath = GetOrCreateOutputPath();
        var documentTypeName = documentType switch
        {
            DocumentType.Dogovor => "договоров",
            DocumentType.Akt => "актов",
            DocumentType.Zayavlenie => "заявлений",
            _ => "всех документов"
        };

        try
        {
            Mouse.OverrideCursor = Cursors.Wait;

            if (documentType == null)
            {
                // Генерируем все типы документов
                var results = new List<GenerateBatchResult>();
                foreach (var docType in new[] { DocumentType.Dogovor, DocumentType.Akt, DocumentType.Zayavlenie })
                {
                    var result = await _generateDocumentHandler.ExecuteForGakAsync(_currentGakId, docType, outputPath);
                    results.Add(result);
                }

                var totalSuccess = results.Sum(r => r.SuccessCount);
                var totalCount = results.Sum(r => r.TotalCount);
                var allErrors = results.SelectMany(r => r.Errors).ToList();

                ShowGenerationResult(totalSuccess, totalCount, allErrors, "всех документов", outputPath);
            }
            else
            {
                var result = await _generateDocumentHandler.ExecuteForGakAsync(_currentGakId, documentType.Value, outputPath);
                ShowGenerationResult(result.SuccessCount, result.TotalCount, result.Errors, documentTypeName, outputPath);
            }
        }
        finally
        {
            Mouse.OverrideCursor = null;
        }
    }

    private void ShowGenerationResult(int successCount, int totalCount, List<string> errors, string documentTypeName, string outputPath)
    {
        if (errors.Count > 0)
        {
            var errorMessage = $"Сгенерировано {successCount} из {totalCount} {documentTypeName}.\n\nОшибки:\n" +
                               string.Join("\n", errors.Take(10));
            if (errors.Count > 10)
                errorMessage += $"\n... и ещё {errors.Count - 10} ошибок";

            MessageBox.Show(errorMessage, "Результат генерации", MessageBoxButton.OK, MessageBoxImage.Warning);
        }
        else
        {
            var result = MessageBox.Show(
                $"Успешно сгенерировано {successCount} {documentTypeName}.\n\nОткрыть папку с документами?",
                "Готово",
                MessageBoxButton.YesNo,
                MessageBoxImage.Information);

            if (result == MessageBoxResult.Yes)
            {
                Process.Start("explorer.exe", outputPath);
            }
        }
    }

    private async void GenerateAllForSelected_Click(object sender, RoutedEventArgs e)
    {
        if (DataGridOplata.SelectedItem is not OplataRowDto selectedRow)
        {
            MessageBox.Show("Выберите запись в таблице", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
            return;
        }

        if (selectedRow.OplataId == null)
        {
            MessageBox.Show("Сначала сохраните данные (кнопка 'Сохранить всё')", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
            return;
        }

        var outputPath = GetOrCreateOutputPath();

        try
        {
            Mouse.OverrideCursor = Cursors.Wait;
            var result = await _generateDocumentHandler.ExecuteAllAsync(selectedRow.OplataId.Value, outputPath);

            if (result.Success && result.Documents != null)
            {
                var message = "Сгенерированы документы:\n";
                if (result.Documents.DogovorPath != null) message += $"- Договор\n";
                if (result.Documents.AktPath != null) message += $"- Акт\n";
                if (result.Documents.ZayavleniePath != null) message += $"- Заявление\n";

                if (result.Documents.HasErrors)
                {
                    message += $"\nОшибки:\n{string.Join("\n", result.Documents.Errors)}";
                }

                var dialogResult = MessageBox.Show(
                    message + "\n\nОткрыть папку?",
                    "Готово",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Information);

                if (dialogResult == MessageBoxResult.Yes)
                {
                    Process.Start("explorer.exe", outputPath);
                }
            }
            else
            {
                MessageBox.Show($"Ошибка: {result.Error}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        finally
        {
            Mouse.OverrideCursor = null;
        }
    }

    private async void GenerateDogovorForSelected_Click(object sender, RoutedEventArgs e)
    {
        await GenerateDocumentForSelectedAsync(DocumentType.Dogovor);
    }

    private async void GenerateAktForSelected_Click(object sender, RoutedEventArgs e)
    {
        await GenerateDocumentForSelectedAsync(DocumentType.Akt);
    }

    private async void GenerateZayavlenieForSelected_Click(object sender, RoutedEventArgs e)
    {
        await GenerateDocumentForSelectedAsync(DocumentType.Zayavlenie);
    }

    private async Task GenerateDocumentForSelectedAsync(DocumentType documentType)
    {
        if (DataGridOplata.SelectedItem is not OplataRowDto selectedRow)
        {
            MessageBox.Show("Выберите запись в таблице", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
            return;
        }

        if (selectedRow.OplataId == null)
        {
            MessageBox.Show("Сначала сохраните данные (кнопка 'Сохранить всё')", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
            return;
        }

        var outputPath = GetOrCreateOutputPath();
        var documentTypeName = documentType switch
        {
            DocumentType.Dogovor => "Договор",
            DocumentType.Akt => "Акт",
            DocumentType.Zayavlenie => "Заявление",
            _ => "Документ"
        };

        try
        {
            Mouse.OverrideCursor = Cursors.Wait;
            var result = await _generateDocumentHandler.ExecuteAsync(selectedRow.OplataId.Value, documentType, outputPath);

            if (result.Success)
            {
                var dialogResult = MessageBox.Show(
                    $"{documentTypeName} успешно сгенерирован.\n\nОткрыть файл?",
                    "Готово",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Information);

                if (dialogResult == MessageBoxResult.Yes && result.FilePath != null)
                {
                    Process.Start(new ProcessStartInfo(result.FilePath) { UseShellExecute = true });
                }
            }
            else
            {
                MessageBox.Show($"Ошибка: {result.Error}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        finally
        {
            Mouse.OverrideCursor = null;
        }
    }

    private void OpenDocumentsFolder_Click(object sender, RoutedEventArgs e)
    {
        var basePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "GeneratedDocuments");

        if (!Directory.Exists(basePath))
        {
            Directory.CreateDirectory(basePath);
        }

        Process.Start("explorer.exe", basePath);
    }
}
