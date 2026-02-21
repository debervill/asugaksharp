using System.Collections.ObjectModel;
using System.IO;

namespace asugaksharp.Features.Oplata;

/// <summary>
/// ViewModel для управления расчётами оплаты ГАК
/// </summary>
public class OplataViewModel
{
    public ObservableCollection<OplataRowDto> Rows { get; } = new();
    public GakInfoDto? CurrentGakInfo { get; private set; }
    public Guid CurrentGakId { get; private set; }

    public bool HasData => Rows.Count > 0;

    public event Action? StateChanged;

    public void LoadData(Guid gakId, GakInfoDto? gakInfo, List<OplataRowDto> rows)
    {
        CurrentGakId = gakId;
        CurrentGakInfo = gakInfo;

        Rows.Clear();
        foreach (var row in rows)
            Rows.Add(row);

        StateChanged?.Invoke();
    }

    public void LoadFromMembers(Guid gakId, GakInfoDto? gakInfo, List<OplataRowDto> members)
    {
        CurrentGakId = gakId;
        CurrentGakInfo = gakInfo;

        Rows.Clear();
        foreach (var member in members)
        {
            if (gakInfo != null)
            {
                member.KolvoBudget = gakInfo.KolvoBudget;
                member.KolvoPlatka = gakInfo.KolvoPlatka;
            }
            Rows.Add(member);
        }

        StateChanged?.Invoke();
    }

    public void Clear()
    {
        CurrentGakId = Guid.Empty;
        CurrentGakInfo = null;
        Rows.Clear();
        StateChanged?.Invoke();
    }

    public void ApplyStoimostChasa(float stoimostChasa)
    {
        foreach (var row in Rows)
        {
            row.StoimostChasa = stoimostChasa;
            row.Recalculate();
        }
        StateChanged?.Invoke();
    }

    public void RecalculateRow(OplataRowDto row)
    {
        row.Recalculate();
        StateChanged?.Invoke();
    }

    public OplataTotalsDto GetTotals()
    {
        return new OplataTotalsDto(
            Rows.Sum(r => r.SummaBezNalogov),
            Rows.Sum(r => r.NdflSumma),
            Rows.Sum(r => r.EnpSumma),
            Rows.Sum(r => r.SummaKVyplate));
    }

    public List<string> ValidateForSave()
    {
        var errors = new List<string>();

        if (Rows.Any(r => r.KolvoStudentov <= 0))
            errors.Add("Укажите количество студентов для всех членов комиссии");

        if (Rows.Any(r => r.StoimostChasa <= 0))
            errors.Add("Укажите стоимость часа для всех членов комиссии");

        return errors;
    }

    public string GetOrCreateOutputPath()
    {
        var basePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "GeneratedDocuments");

        string outputPath;
        if (CurrentGakInfo != null)
        {
            var gakFolder = $"ГАК_{CurrentGakInfo.NomerPrikaza}_{DateTime.Now:yyyy-MM-dd}";
            outputPath = Path.Combine(basePath, gakFolder);
        }
        else
        {
            outputPath = Path.Combine(basePath, DateTime.Now.ToString("yyyy-MM-dd_HH-mm"));
        }

        Directory.CreateDirectory(outputPath);
        return outputPath;
    }
}

public record OplataTotalsDto(
    float TotalNachisleno,
    float TotalNdfl,
    float TotalEnp,
    float TotalKVyplate);
