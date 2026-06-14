using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace asugaksharp.Features.Zasedanie;

public partial class RaspredelenieDiplomnikovWindow : Window
{
    private readonly GetZasedaniesHandler _getZasedaniesHandler;
    private readonly GetDiplomniksForDistributionHandler _getDistributionHandler;
    private readonly AssignDiplomnikHandler _assignHandler;

    private List<ZasedanieDto> _allZasedanies = new();
    private List<DiplomnikForDistributionDto> _allUnassigned = new();
    private List<DiplomnikForDistributionDto> _allAssigned = new();
    private Guid? _selectedZasedanieId;
    private bool _isOrderDirty;

    private static readonly FilterItemDto AllItem = new(Guid.Empty, "— Все —");

    public RaspredelenieDiplomnikovWindow(
        GetZasedaniesHandler getZasedaniesHandler,
        GetDiplomniksForDistributionHandler getDistributionHandler,
        AssignDiplomnikHandler assignHandler)
    {
        InitializeComponent();
        _getZasedaniesHandler = getZasedaniesHandler;
        _getDistributionHandler = getDistributionHandler;
        _assignHandler = assignHandler;

        InitVidVkrFilter();
        Loaded += async (_, _) => await LoadZasedaniesAsync();
    }

    private void InitVidVkrFilter()
    {
        ComboBoxFilterVidVkr.Items.Add("— Все —");
        ComboBoxFilterVidVkr.Items.Add("бакалаврская работа");
        ComboBoxFilterVidVkr.Items.Add("магистерская диссертация");
        ComboBoxFilterVidVkr.Items.Add("дипломный проект");
        ComboBoxFilterVidVkr.SelectedIndex = 0;
    }

    private async Task LoadZasedaniesAsync()
    {
        _allZasedanies = await _getZasedaniesHandler.ExecuteAsync();

        var kafedry = _allZasedanies
            .Where(z => z.KafedraId.HasValue)
            .Select(z => new FilterItemDto(z.KafedraId!.Value, z.KafedraName ?? ""))
            .DistinctBy(k => k.Id)
            .OrderBy(k => k.Name)
            .ToList();

        ComboBoxKafedra.ItemsSource = new[] { AllItem }.Concat(kafedry).ToList();
        ComboBoxKafedra.SelectedIndex = 0;
    }

    private void ComboBoxKafedra_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var kafedraId = ComboBoxKafedra.SelectedValue as Guid?;
        if (kafedraId == Guid.Empty) kafedraId = null;

        var filtered = kafedraId == null
            ? _allZasedanies
            : _allZasedanies.Where(z => z.KafedraId == kafedraId).ToList();

        ComboBoxZasedanie.SelectionChanged -= ComboBoxZasedanie_SelectionChanged;
        ComboBoxZasedanie.ItemsSource = filtered;
        ComboBoxZasedanie.SelectedIndex = filtered.Count > 0 ? 0 : -1;
        ComboBoxZasedanie.SelectionChanged += ComboBoxZasedanie_SelectionChanged;

        if (filtered.Count > 0)
            _ = LoadDiplomniksAsync((Guid)ComboBoxZasedanie.SelectedValue!);
        else
            ClearLists();
    }

    private async void ComboBoxZasedanie_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (ComboBoxZasedanie.SelectedValue is Guid id)
            await LoadDiplomniksAsync(id);
    }

    private async Task LoadDiplomniksAsync(Guid zasedanieId)
    {
        _selectedZasedanieId = zasedanieId;
        var (unassigned, assigned) = await _getDistributionHandler.ExecuteAsync(zasedanieId);
        _allUnassigned = unassigned;
        _allAssigned = assigned;
        _isOrderDirty = false;

        RebuildNapravlenieFilter();
        ApplyFilters();
    }

    private void ClearLists()
    {
        _selectedZasedanieId = null;
        _allUnassigned = new();
        _allAssigned = new();
        _isOrderDirty = false;
        ListUnassigned.ItemsSource = null;
        ListAssigned.ItemsSource = null;
        TextUnassignedHeader.Text = "Не распределены";
        TextAssignedHeader.Text = "В заседании";
        TextStatus.Text = "";
    }

    private void RebuildNapravlenieFilter()
    {
        var napravleniya = _allUnassigned.Concat(_allAssigned)
            .Where(d => d.NapravleniePodgotovkiId.HasValue)
            .Select(d => new FilterItemDto(d.NapravleniePodgotovkiId!.Value, d.NapravlenieName ?? ""))
            .DistinctBy(x => x.Id)
            .OrderBy(x => x.Name)
            .ToList();

        ComboBoxFilterNapravlenie.SelectionChanged -= Filter_Changed;
        ComboBoxFilterNapravlenie.ItemsSource = new[] { AllItem }.Concat(napravleniya).ToList();
        ComboBoxFilterNapravlenie.SelectedIndex = 0;
        ComboBoxFilterNapravlenie.SelectionChanged += Filter_Changed;
    }

    private void Filter_Changed(object sender, SelectionChangedEventArgs e) => ApplyFilters();

    private void ApplyFilters()
    {
        var napravlenieId = ComboBoxFilterNapravlenie.SelectedValue as Guid?;
        if (napravlenieId == Guid.Empty) napravlenieId = null;

        var vidVkr = ComboBoxFilterVidVkr.SelectedIndex > 0
            ? ComboBoxFilterVidVkr.SelectedItem as string
            : null;

        var filteredUnassigned = Filter(_allUnassigned, napravlenieId, vidVkr);

        // Нумерованный список с позицией в _allAssigned (глобальный порядковый номер)
        var filteredAssigned = _allAssigned
            .Select((d, i) => new NumberedDiplomnik(i + 1, d))
            .Where(x => MatchesFilter(x.Data, napravlenieId, vidVkr))
            .ToList();

        ListUnassigned.ItemsSource = filteredUnassigned;
        ListAssigned.ItemsSource = filteredAssigned;

        TextUnassignedHeader.Text = $"Не распределены ({filteredUnassigned.Count})";
        TextAssignedHeader.Text = $"В заседании ({_allAssigned.Count})";

        var filterNote = napravlenieId != null || vidVkr != null
            ? $"   (показано: {filteredUnassigned.Count} / {filteredAssigned.Count})"
            : "";
        TextStatus.Text = $"Всего не распределено: {_allUnassigned.Count}   В заседании: {_allAssigned.Count}{filterNote}"
                        + (_isOrderDirty ? "   [несохранённые изменения порядка]" : "");
    }

    private static List<DiplomnikForDistributionDto> Filter(
        List<DiplomnikForDistributionDto> source,
        Guid? napravlenieId, string? vidVkr)
        => source.Where(d => MatchesFilter(d, napravlenieId, vidVkr)).ToList();

    private static bool MatchesFilter(DiplomnikForDistributionDto d, Guid? napravlenieId, string? vidVkr)
        => (napravlenieId == null || d.NapravleniePodgotovkiId == napravlenieId)
        && (vidVkr == null || d.VidVkr == vidVkr);

    // ───── Перемещение вверх/вниз ─────

    private void MoveUp_Click(object sender, RoutedEventArgs e) => MoveSelected(-1);
    private void MoveDown_Click(object sender, RoutedEventArgs e) => MoveSelected(1);

    private void MoveSelected(int direction)
    {
        if (ListAssigned.SelectedItem is not NumberedDiplomnik selected) return;

        var idx = _allAssigned.FindIndex(d => d.Id == selected.Data.Id);
        var newIdx = idx + direction;
        if (newIdx < 0 || newIdx >= _allAssigned.Count) return;

        (_allAssigned[idx], _allAssigned[newIdx]) = (_allAssigned[newIdx], _allAssigned[idx]);
        _isOrderDirty = true;

        ApplyFilters();

        // Восстановить выделение на перемещённом элементе
        ListAssigned.SelectedItem = ((List<NumberedDiplomnik>)ListAssigned.ItemsSource)
            ?.FirstOrDefault(x => x.Data.Id == selected.Data.Id);
        ListAssigned.ScrollIntoView(ListAssigned.SelectedItem);
    }

    // ───── Сохранить порядок ─────

    private async void BtnSaveOrder_Click(object sender, RoutedEventArgs e)
    {
        if (_selectedZasedanieId is null) return;
        await SaveOrderToDatabaseAsync();
        ApplyFilters();
    }

    private async Task SaveOrderToDatabaseAsync()
    {
        if (_selectedZasedanieId is null) return;
        var orderedIds = _allAssigned.Select(d => d.Id).ToList();
        await _assignHandler.SaveOrderAsync(_selectedZasedanieId.Value, orderedIds);
        _isOrderDirty = false;
    }

    // ───── Назначить / снять ─────

    private async void AssignButton_Click(object sender, RoutedEventArgs e)
    {
        if (_selectedZasedanieId is null)
        {
            MessageBox.Show("Выберите заседание.", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
            return;
        }

        var selected = ListUnassigned.SelectedItems.Cast<DiplomnikForDistributionDto>().ToList();
        if (selected.Count == 0) return;

        if (_isOrderDirty) await SaveOrderToDatabaseAsync();

        foreach (var d in selected)
            await _assignHandler.AssignAsync(d.Id, _selectedZasedanieId.Value);

        await LoadDiplomniksAsync(_selectedZasedanieId.Value);
    }

    private async void UnassignButton_Click(object sender, RoutedEventArgs e)
    {
        if (_selectedZasedanieId is null) return;

        var selected = ListAssigned.SelectedItems.Cast<NumberedDiplomnik>().ToList();
        if (selected.Count == 0) return;

        if (_isOrderDirty) await SaveOrderToDatabaseAsync();

        foreach (var item in selected)
            await _assignHandler.UnassignAsync(item.Data.Id);

        await LoadDiplomniksAsync(_selectedZasedanieId.Value);
    }

    private async void ListUnassigned_DoubleClick(object sender, MouseButtonEventArgs e)
    {
        if (ListUnassigned.SelectedItem is DiplomnikForDistributionDto d && _selectedZasedanieId.HasValue)
        {
            if (_isOrderDirty) await SaveOrderToDatabaseAsync();
            await _assignHandler.AssignAsync(d.Id, _selectedZasedanieId.Value);
            await LoadDiplomniksAsync(_selectedZasedanieId.Value);
        }
    }

    private async void ListAssigned_DoubleClick(object sender, MouseButtonEventArgs e)
    {
        if (ListAssigned.SelectedItem is NumberedDiplomnik item && _selectedZasedanieId.HasValue)
        {
            if (_isOrderDirty) await SaveOrderToDatabaseAsync();
            await _assignHandler.UnassignAsync(item.Data.Id);
            await LoadDiplomniksAsync(_selectedZasedanieId.Value);
        }
    }
}
