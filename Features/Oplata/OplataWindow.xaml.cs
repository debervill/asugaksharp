using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
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

    private readonly OplataViewModel _viewModel = new();

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

        DataGridOplata.ItemsSource = _viewModel.Rows;
        _viewModel.StateChanged += UpdateUI;

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
            _viewModel.Clear();
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

        var gakInfo = await _getGakInfoHandler.ExecuteAsync(gak.Id);
        var savedOplatas = await _getOplatasByGakHandler.ExecuteAsync(gak.Id);

        if (savedOplatas.Count > 0)
        {
            _viewModel.LoadData(gak.Id, gakInfo, savedOplatas);
        }
        else
        {
            var members = await _getGakExternalMembersHandler.ExecuteAsync(gak.Id);
            _viewModel.LoadFromMembers(gak.Id, gakInfo, members);
        }
    }

    private void ApplyToAllButton_Click(object sender, RoutedEventArgs e)
    {
        if (!float.TryParse(TextBoxStoimostChasa.Text, out var stoimostChasa))
        {
            MessageBox.Show("Введите корректную стоимость часа", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            return;
        }

        _viewModel.ApplyStoimostChasa(stoimostChasa);
        DataGridOplata.Items.Refresh();
    }

    private void DataGridOplata_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
    {
        if (e.Row.Item is OplataRowDto row)
        {
            Dispatcher.BeginInvoke(new Action(() =>
            {
                _viewModel.RecalculateRow(row);
            }), System.Windows.Threading.DispatcherPriority.Background);
        }
    }

    private async void SaveAllButton_Click(object sender, RoutedEventArgs e)
    {
        var errors = _viewModel.ValidateForSave();
        if (errors.Count > 0)
        {
            MessageBox.Show(string.Join("\n", errors), "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            return;
        }

        ButtonSaveAll.IsEnabled = false;
        try
        {
            await _saveOplatasByGakHandler.ExecuteAsync(_viewModel.CurrentGakId, _viewModel.Rows.ToList());
            MessageBox.Show("Расчёт сохранён", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Ошибка сохранения: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }
        finally
        {
            ButtonSaveAll.IsEnabled = _viewModel.HasData;
        }
    }

    private void CopyMenuItem_Click(object sender, RoutedEventArgs e)
    {
        ApplicationCommands.Copy.Execute(null, DataGridOplata);
    }

    private void ButtonDocuments_Click(object sender, RoutedEventArgs e)
    {
        if (sender is Button button && button.ContextMenu != null)
        {
            button.ContextMenu.PlacementTarget = button;
            button.ContextMenu.Placement = System.Windows.Controls.Primitives.PlacementMode.Bottom;
            button.ContextMenu.IsOpen = true;
        }
    }

    private async void GenerateAllDocuments_Click(object sender, RoutedEventArgs e)
    {
        await GenerateDocumentsAsync(null);
    }

    private async void GenerateDogovors_Click(object sender, RoutedEventArgs e)
    {
        await GenerateDocumentsAsync(DocumentType.Dogovor);
    }

    private async Task GenerateDocumentsAsync(DocumentType? documentType)
    {
        if (_viewModel.CurrentGakId == Guid.Empty)
        {
            MessageBox.Show("Сначала загрузите данные ГАК", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
            return;
        }

        var outputPath = _viewModel.GetOrCreateOutputPath();
        var documentTypeName = documentType switch
        {
            DocumentType.Dogovor => "договоров",
            _ => "всех документов"
        };

        ButtonDocuments.IsEnabled = false;
        Mouse.OverrideCursor = Cursors.Wait;
        try
        {
            var docType = documentType ?? DocumentType.Dogovor;
            var result = await _generateDocumentHandler.ExecuteForGakAsync(_viewModel.CurrentGakId, docType, outputPath);
            ShowGenerationResult(result.SuccessCount, result.TotalCount, result.Errors, documentTypeName, outputPath);
        }
        finally
        {
            Mouse.OverrideCursor = null;
            ButtonDocuments.IsEnabled = _viewModel.HasData;
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
                Process.Start("explorer.exe", outputPath);
        }
    }

    private void OpenDocumentsFolder_Click(object sender, RoutedEventArgs e)
    {
        var basePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "GeneratedDocuments");
        if (!Directory.Exists(basePath))
            Directory.CreateDirectory(basePath);

        Process.Start("explorer.exe", basePath);
    }

    private void UpdateUI()
    {
        if (_viewModel.CurrentGakInfo != null)
        {
            TextBoxKolvoBudget.Text = _viewModel.CurrentGakInfo.KolvoBudget.ToString();
            TextBoxKolvoPlatka.Text = _viewModel.CurrentGakInfo.KolvoPlatka.ToString();
        }
        else
        {
            TextBoxKolvoBudget.Text = "";
            TextBoxKolvoPlatka.Text = "";
        }

        var totals = _viewModel.GetTotals();
        TextBoxTotalNachisleno.Text = totals.TotalNachisleno.ToString("F2");
        TextBoxTotalNdfl.Text = totals.TotalNdfl.ToString("F2");
        TextBoxTotalEnp.Text = totals.TotalEnp.ToString("F2");
        TextBoxTotalKVyplate.Text = totals.TotalKVyplate.ToString("F2");

        ButtonSaveAll.IsEnabled = _viewModel.HasData;
        ButtonDocuments.IsEnabled = _viewModel.HasData;
    }
}
