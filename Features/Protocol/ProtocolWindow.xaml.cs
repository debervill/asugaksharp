using System.IO;
using System.Windows;
using Microsoft.Win32;
using asugaksharp.Features.Diplomnik;

namespace asugaksharp.Features.Protocol;

public partial class ProtocolWindow : Window
{
    private readonly GetDiplomniksHandler _getDiplomniksHandler;
    private readonly GenerateProtocolHandler _generateHandler;

    public ProtocolWindow(
        GetDiplomniksHandler getDiplomniksHandler,
        GenerateProtocolHandler generateHandler)
    {
        InitializeComponent();
        _getDiplomniksHandler = getDiplomniksHandler;
        _generateHandler = generateHandler;

        TextBoxFolder.Text = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Протоколы");
        Loaded += async (_, _) => await LoadDataAsync();
    }

    private async Task LoadDataAsync()
    {
        var diplomniks = await _getDiplomniksHandler.ExecuteAsync();
        DataGridDiplomniki.ItemsSource = diplomniks;
        TextStatus.Text = $"Всего дипломников: {diplomniks.Count}";
    }

    private async void BtnRefresh_Click(object sender, RoutedEventArgs e)
    {
        await LoadDataAsync();
    }

    private void BtnSelectAll_Click(object sender, RoutedEventArgs e)
    {
        DataGridDiplomniki.SelectAll();
    }

    private void BtnDeselectAll_Click(object sender, RoutedEventArgs e)
    {
        DataGridDiplomniki.UnselectAll();
    }

    private void BtnDiagnose_Click(object sender, RoutedEventArgs e)
    {
        var handler = new DiagnoseTemplatesHandler();
        var report = handler.Diagnose();
        var win = new Window
        {
            Title = "Диагностика шаблонов",
            Width = 700, Height = 500,
            Owner = this,
            WindowStartupLocation = WindowStartupLocation.CenterOwner,
            Content = new System.Windows.Controls.ScrollViewer
            {
                Content = new System.Windows.Controls.TextBox
                {
                    Text = report,
                    IsReadOnly = true,
                    FontFamily = new System.Windows.Media.FontFamily("Consolas"),
                    FontSize = 12,
                    TextWrapping = System.Windows.TextWrapping.NoWrap,
                    VerticalScrollBarVisibility = System.Windows.Controls.ScrollBarVisibility.Auto,
                    HorizontalScrollBarVisibility = System.Windows.Controls.ScrollBarVisibility.Auto
                }
            }
        };
        win.ShowDialog();
    }

    private void BtnBrowse_Click(object sender, RoutedEventArgs e)
    {
        var dialog = new OpenFolderDialog
        {
            Title = "Выберите папку для сохранения протоколов",
            InitialDirectory = string.IsNullOrWhiteSpace(TextBoxFolder.Text)
                ? Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
                : TextBoxFolder.Text
        };

        if (dialog.ShowDialog() == true)
            TextBoxFolder.Text = dialog.FolderName;
    }

    private async void BtnGenerateSelected_Click(object sender, RoutedEventArgs e)
    {
        var selected = DataGridDiplomniki.SelectedItems
            .OfType<DiplomnikDto>()
            .ToList();

        if (selected.Count == 0)
        {
            System.Windows.MessageBox.Show("Выберите хотя бы одного дипломника.", "Внимание",
                MessageBoxButton.OK, MessageBoxImage.Warning);
            return;
        }

        await GenerateAsync(selected);
    }

    private async void BtnGenerateAll_Click(object sender, RoutedEventArgs e)
    {
        var all = DataGridDiplomniki.ItemsSource?.OfType<DiplomnikDto>().ToList();
        if (all == null || all.Count == 0)
        {
            System.Windows.MessageBox.Show("Список дипломников пуст.", "Внимание",
                MessageBoxButton.OK, MessageBoxImage.Warning);
            return;
        }

        await GenerateAsync(all);
    }

    private async Task GenerateAsync(List<DiplomnikDto> diplomniks)
    {
        var folder = TextBoxFolder.Text.Trim();
        if (string.IsNullOrWhiteSpace(folder))
        {
            System.Windows.MessageBox.Show("Укажите папку для сохранения.", "Ошибка",
                MessageBoxButton.OK, MessageBoxImage.Error);
            return;
        }

        TextStatus.Text = "Генерация...";
        IsEnabled = false;

        int success = 0, failed = 0;
        var errors = new List<string>();

        foreach (var d in diplomniks)
        {
            var data = new ProtocolData(d.Id, folder);
            var result = await _generateHandler.ExecuteAsync(data);

            if (result.Success)
                success++;
            else
            {
                failed++;
                errors.Add($"{d.FioImen}: {result.Error}");
            }
        }

        IsEnabled = true;

        if (errors.Count > 0)
        {
            var msg = $"Успешно: {success}, ошибок: {failed}\n\n" +
                      string.Join("\n", errors.Take(10));
            System.Windows.MessageBox.Show(msg, "Результат генерации",
                MessageBoxButton.OK, MessageBoxImage.Warning);
        }
        else
        {
            System.Windows.MessageBox.Show(
                $"Сгенерировано {success} протокол(ов).\nПапка: {folder}",
                "Готово", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        TextStatus.Text = $"Готово: {success} успешно, {failed} с ошибками.";
    }
}
