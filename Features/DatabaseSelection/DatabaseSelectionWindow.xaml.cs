using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Win32;

namespace asugaksharp.Features.DatabaseSelection;

public class DatabaseEntry
{
    [JsonPropertyName("name")]
    public string Name { get; set; } = "";

    [JsonPropertyName("path")]
    public string Path { get; set; } = "";

    public string ConnectionString => $"Data Source={Path}";
}

public class DatabasesConfig
{
    [JsonPropertyName("databases")]
    public List<DatabaseEntry> Databases { get; set; } = new();

    [JsonPropertyName("lastSelected")]
    public int LastSelected { get; set; } = 0;
}

public partial class DatabaseSelectionWindow : Window
{
    private const string ConfigFile = "databases.json";
    private static readonly JsonSerializerOptions JsonOptions = new() { WriteIndented = true };

    private DatabasesConfig _config = null!;
    private int _selectedIndex = 0;

    public string SelectedConnectionString => _config.Databases[_selectedIndex].ConnectionString;
    public string SelectedName => _config.Databases[_selectedIndex].Name;
    public string SelectedPath => _config.Databases[_selectedIndex].Path;

    public DatabaseSelectionWindow()
    {
        InitializeComponent();
        _config = LoadConfig();
        _selectedIndex = Math.Clamp(_config.LastSelected, 0, _config.Databases.Count - 1);
        BuildUI();
    }

    private void BuildUI()
    {
        for (int i = 0; i < _config.Databases.Count; i++)
        {
            var entry = _config.Databases[i];
            var index = i;

            var radio = new RadioButton
            {
                Content = entry.Name,
                FontWeight = FontWeights.SemiBold,
                FontSize = 13,
                IsChecked = (i == _selectedIndex),
                GroupName = "Database",
                Margin = new Thickness(0, 0, 0, 4)
            };
            radio.Checked += (_, _) => _selectedIndex = index;

            var pathBox = new TextBox
            {
                Text = entry.Path,
                IsReadOnly = true,
                Margin = new Thickness(0, 0, 6, 0),
                VerticalContentAlignment = VerticalAlignment.Center
            };

            var browseBtn = new Button
            {
                Content = "Обзор...",
                Width = 72,
                Padding = new Thickness(0, 3, 0, 3)
            };
            browseBtn.Click += (_, _) =>
            {
                var dlg = new OpenFileDialog
                {
                    Title = $"Выберите файл базы данных — {entry.Name}",
                    Filter = "SQLite (*.db)|*.db|Все файлы (*.*)|*.*",
                    FileName = System.IO.Path.GetFileName(entry.Path),
                    InitialDirectory = ResolveInitialDirectory(entry.Path)
                };
                if (dlg.ShowDialog() == true)
                {
                    entry.Path = dlg.FileName;
                    pathBox.Text = dlg.FileName;
                }
            };

            var pathRow = new Grid { Margin = new Thickness(22, 0, 0, 14) };
            pathRow.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            pathRow.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });
            Grid.SetColumn(pathBox, 0);
            Grid.SetColumn(browseBtn, 1);
            pathRow.Children.Add(pathBox);
            pathRow.Children.Add(browseBtn);

            DatabasesPanel.Children.Add(radio);
            DatabasesPanel.Children.Add(pathRow);
        }
    }

    private void OkButton_Click(object sender, RoutedEventArgs e)
    {
        _config.LastSelected = _selectedIndex;
        SaveConfig(_config);
        DialogResult = true;
    }

    private void CancelButton_Click(object sender, RoutedEventArgs e)
    {
        DialogResult = false;
    }

    private static string ResolveInitialDirectory(string path)
    {
        try
        {
            var dir = System.IO.Path.GetDirectoryName(System.IO.Path.GetFullPath(path));
            return dir != null && Directory.Exists(dir) ? dir : AppDomain.CurrentDomain.BaseDirectory;
        }
        catch
        {
            return AppDomain.CurrentDomain.BaseDirectory;
        }
    }

    private static DatabasesConfig LoadConfig()
    {
        if (!File.Exists(ConfigFile))
            return DefaultConfig();
        try
        {
            var json = File.ReadAllText(ConfigFile);
            return JsonSerializer.Deserialize<DatabasesConfig>(json) ?? DefaultConfig();
        }
        catch
        {
            return DefaultConfig();
        }
    }

    private static void SaveConfig(DatabasesConfig config)
    {
        try
        {
            File.WriteAllText(ConfigFile, JsonSerializer.Serialize(config, JsonOptions));
        }
        catch { /* non-critical */ }
    }

    private static DatabasesConfig DefaultConfig() => new()
    {
        Databases = new()
        {
            new() { Name = "Разработка", Path = "asugak_dev.db" },
            new() { Name = "Продуктив",  Path = "asugak.db" }
        },
        LastSelected = 0
    };
}
