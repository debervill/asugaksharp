using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using asugaksharp.Features.Gak;
using asugaksharp.Features.Kafedra;
using asugaksharp.Features.Komissiya;

namespace asugaksharp.Features.Zasedanie;

public partial class RaspisanieWindow : Window
{
    private readonly GetKafedrasHandler _getKafedrasHandler;
    private readonly GetGaksByKafedraHandler _getGaksByKafedraHandler;
    private readonly GetZasedaniesHandler _getZasedaniesHandler;
    private readonly UpdateZasedanieHandler _updateZasedanieHandler;

    private List<GakDto> _gaks = new();
    private Dictionary<DateOnly, Dictionary<Guid, List<ZasedanieDto>>> _pivot = new();
    private readonly Dictionary<DataGridColumn, Guid> _columnGakMap = new();
    private ZasedanieDto? _selectedSession;

    public RaspisanieWindow(
        GetKafedrasHandler getKafedrasHandler,
        GetGaksByKafedraHandler getGaksByKafedraHandler,
        GetZasedaniesHandler getZasedaniesHandler,
        UpdateZasedanieHandler updateZasedanieHandler)
    {
        InitializeComponent();

        _getKafedrasHandler = getKafedrasHandler;
        _getGaksByKafedraHandler = getGaksByKafedraHandler;
        _getZasedaniesHandler = getZasedaniesHandler;
        _updateZasedanieHandler = updateZasedanieHandler;

        Loaded += async (_, _) => await LoadKafedrasAsync();
    }

    private async Task LoadKafedrasAsync()
    {
        var kafedras = await _getKafedrasHandler.ExecuteAsync();
        ComboKafedra.ItemsSource = kafedras;
    }

    private async void BtnLoad_Click(object sender, RoutedEventArgs e)
    {
        await LoadScheduleAsync();
    }

    private async void BtnRefresh_Click(object sender, RoutedEventArgs e)
    {
        await LoadScheduleAsync();
    }

    private async Task LoadScheduleAsync()
    {
        if (ComboKafedra.SelectedValue is not Guid kafedraId) return;

        _gaks = await _getGaksByKafedraHandler.ExecuteAsync(kafedraId);
        if (_gaks.Count == 0)
        {
            TextStatus.Text = "Нет ГАКов для выбранной кафедры";
            DataGridSchedule.ItemsSource = null;
            DataGridSchedule.Columns.Clear();
            return;
        }

        var gakIds = _gaks.Select(g => g.Id).ToHashSet();
        var allZasedanies = await _getZasedaniesHandler.ExecuteAsync();
        var zasedanies = allZasedanies.Where(z => gakIds.Contains(z.GakId)).ToList();

        _pivot = BuildPivot(zasedanies);
        BuildColumns();
        DataGridSchedule.ItemsSource = BuildRows();

        var dayCount = _pivot.Count;
        TextStatus.Text = $"{zasedanies.Count} заседаний, {dayCount} {DayWord(dayCount)}";

        ClearDetailPanel();
    }

    private static Dictionary<DateOnly, Dictionary<Guid, List<ZasedanieDto>>> BuildPivot(
        List<ZasedanieDto> zasedanies)
    {
        var pivot = new Dictionary<DateOnly, Dictionary<Guid, List<ZasedanieDto>>>();
        foreach (var z in zasedanies)
        {
            if (!pivot.TryGetValue(z.Date, out var byGak))
            {
                byGak = new Dictionary<Guid, List<ZasedanieDto>>();
                pivot[z.Date] = byGak;
            }
            if (!byGak.TryGetValue(z.GakId, out var list))
            {
                list = new List<ZasedanieDto>();
                byGak[z.GakId] = list;
            }
            list.Add(z);
        }
        return pivot;
    }

    private void BuildColumns()
    {
        DataGridSchedule.Columns.Clear();
        _columnGakMap.Clear();

        var dateCol = new DataGridTextColumn
        {
            Header = "Дата",
            Binding = new Binding("DateDisplay"),
            Width = 110,
            IsReadOnly = true
        };
        dateCol.ElementStyle = new Style(typeof(TextBlock))
        {
            Setters =
            {
                new Setter(TextBlock.FontWeightProperty, FontWeights.SemiBold),
                new Setter(TextBlock.VerticalAlignmentProperty, VerticalAlignment.Center),
                new Setter(TextBlock.HorizontalAlignmentProperty, HorizontalAlignment.Center),
                new Setter(TextBlock.TextAlignmentProperty, TextAlignment.Center),
            }
        };
        DataGridSchedule.Columns.Add(dateCol);

        for (int i = 0; i < _gaks.Count; i++)
        {
            var gak = _gaks[i];
            var col = new DataGridTextColumn
            {
                Header = $"ГАК №{gak.NomerPrikaza}",
                Binding = new Binding($"Cells[{i}]"),
                Width = new DataGridLength(1, DataGridLengthUnitType.Star),
                IsReadOnly = true
            };
            col.ElementStyle = new Style(typeof(TextBlock))
            {
                Setters =
                {
                    new Setter(TextBlock.TextWrappingProperty, TextWrapping.Wrap),
                    new Setter(TextBlock.PaddingProperty, new Thickness(4, 3, 4, 3)),
                    new Setter(TextBlock.VerticalAlignmentProperty, VerticalAlignment.Center),
                }
            };
            DataGridSchedule.Columns.Add(col);
            _columnGakMap[col] = gak.Id;
        }
    }

    private List<ScheduleRow> BuildRows()
    {
        var rows = new List<ScheduleRow>();
        var culture = new CultureInfo("ru-RU");

        foreach (var date in _pivot.Keys.OrderBy(d => d))
        {
            var cells = new string[_gaks.Count];
            for (int i = 0; i < _gaks.Count; i++)
            {
                var gakId = _gaks[i].Id;
                if (_pivot[date].TryGetValue(gakId, out var sessions))
                    cells[i] = string.Join("\n", sessions.Select(s => $"{s.NapravleniePodgotovki} ({s.Kvalificacia})"));
                else
                    cells[i] = "";
            }

            rows.Add(new ScheduleRow
            {
                Date = date,
                DateDisplay = date.ToString("dd.MM\nddd", culture),
                Cells = cells
            });
        }

        return rows;
    }

    private void DataGridSchedule_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
    {
        ClearDetailPanel();

        if (DataGridSchedule.SelectedCells.Count == 0) return;
        var cell = DataGridSchedule.SelectedCells[0];
        if (cell.Item is not ScheduleRow row) return;
        if (!_columnGakMap.TryGetValue(cell.Column, out var gakId)) return;

        if (!_pivot.TryGetValue(row.Date, out var byGak) ||
            !byGak.TryGetValue(gakId, out var sessions) ||
            sessions.Count == 0) return;

        ListSessions.ItemsSource = sessions
            .Select(s => new SessionItem(s, $"{s.NapravleniePodgotovki} ({s.Kvalificacia})"))
            .ToList();

        if (sessions.Count == 1)
            ListSessions.SelectedIndex = 0;
    }

    private void ListSessions_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (ListSessions.SelectedItem is not SessionItem item)
        {
            _selectedSession = null;
            DatePickerNew.IsEnabled = false;
            BtnSave.IsEnabled = false;
            return;
        }

        _selectedSession = item.Session;
        DatePickerNew.SelectedDate = _selectedSession.Date.ToDateTime(TimeOnly.MinValue);
        DatePickerNew.IsEnabled = true;
        BtnSave.IsEnabled = true;
    }

    private async void BtnSave_Click(object sender, RoutedEventArgs e)
    {
        if (_selectedSession == null) return;
        if (!DatePickerNew.SelectedDate.HasValue) return;

        var newDate = DateOnly.FromDateTime(DatePickerNew.SelectedDate.Value);
        if (newDate == _selectedSession.Date)
        {
            MessageBox.Show("Дата не изменена.", "Внимание", MessageBoxButton.OK, MessageBoxImage.Information);
            return;
        }

        var request = new UpdateZasedanieRequest(
            _selectedSession.Id,
            _selectedSession.NapravleniePodgotovki,
            _selectedSession.Kvalificacia,
            newDate,
            _selectedSession.GakId);

        await _updateZasedanieHandler.ExecuteAsync(request);
        await LoadScheduleAsync();
    }

    private void BtnCancel_Click(object sender, RoutedEventArgs e)
    {
        ClearDetailPanel();
    }

    private void ClearDetailPanel()
    {
        _selectedSession = null;
        ListSessions.ItemsSource = null;
        DatePickerNew.SelectedDate = null;
        DatePickerNew.IsEnabled = false;
        BtnSave.IsEnabled = false;
    }

    private static string DayWord(int n) => n switch
    {
        1 => "день",
        2 or 3 or 4 => "дня",
        _ => "дней"
    };

    private sealed record SessionItem(ZasedanieDto Session, string Label);

    public sealed class ScheduleRow
    {
        public DateOnly Date { get; init; }
        public string DateDisplay { get; init; } = "";
        public string[] Cells { get; init; } = Array.Empty<string>();
    }
}
