using System.IO;
using Microsoft.EntityFrameworkCore;
using asugaksharp.Infrastructure.Persistence;
using iText.Kernel.Pdf;
using iText.Forms;
using iText.Forms.Fields;

namespace asugaksharp.Features.Protocol;

public record ProtocolData(
    Guid DiplomnikId,
    string OutputFolder);

public record ProtocolResult(
    bool Success,
    string? ProtocolPath,
    string? KvalifikaciaPath,
    string? Error);

public class GenerateProtocolHandler
{
    private readonly AppDbContext _context;

    private static readonly string TemplateProtocol =
        Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Templates", "-Протокол .pdf");
    private static readonly string TemplateKvalifikacia =
        Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Templates", "-Протокол квалификация .pdf");

    public GenerateProtocolHandler(AppDbContext context) => _context = context;

    public async Task<ProtocolResult> ExecuteAsync(ProtocolData data, CancellationToken ct = default)
    {
        try
        {
            var d = await _context.Diplomnik
                .AsNoTracking()
                .Include(x => x.Person)
                .Include(x => x.ProfilPodgotovki)
                    .ThenInclude(p => p!.NapravleniePodgotovki)
                .Include(x => x.Konsultanty!).ThenInclude(k => k.Person)
                .Include(x => x.Retsenzenty!).ThenInclude(r => r.Person)
                .Include(x => x.Zasedanie!)
                    .ThenInclude(z => z.Gak!)
                    .ThenInclude(g => g.Predsedatel)
                .Include(x => x.Zasedanie!)
                    .ThenInclude(z => z.Gak!)
                    .ThenInclude(g => g.Sekretar)
                .Include(x => x.Zasedanie!)
                    .ThenInclude(z => z.Gak!)
                    .ThenInclude(g => g.Persons)
                .FirstOrDefaultAsync(x => x.Id == data.DiplomnikId, ct);

            if (d == null)
                return new ProtocolResult(false, null, null, "Дипломник не найден");

            if (!File.Exists(TemplateProtocol))
                return new ProtocolResult(false, null, null, $"Шаблон не найден: {TemplateProtocol}");

            if (!File.Exists(TemplateKvalifikacia))
                return new ProtocolResult(false, null, null, $"Шаблон не найден: {TemplateKvalifikacia}");

            Directory.CreateDirectory(data.OutputFolder);

            var safeName = SanitizeFileName(d.FioImen);
            var protocolPath = Path.Combine(data.OutputFolder, $"Протокол_{safeName}.pdf");
            var kvalPath = Path.Combine(data.OutputFolder, $"Протокол_квалификация_{safeName}.pdf");

            FillProtocol(d, protocolPath);
            FillKvalifikacia(d, kvalPath);

            return new ProtocolResult(true, protocolPath, kvalPath, null);
        }
        catch (Exception ex)
        {
            var msg = ex.InnerException != null
                ? $"{ex.Message}\n→ {ex.InnerException.Message}"
                : ex.Message;
            return new ProtocolResult(false, null, null, msg);
        }
    }

    private void FillProtocol(Core.Entities.Diplomnik d, string outputPath)
    {
        var gak  = d.Zasedanie?.Gak;
        var date = d.Zasedanie?.Date;

        var predsedatel = gak?.Predsedatel?.Name ?? "";
        var sekretar    = gak?.Sekretar?.Name    ?? "";
        var members     = gak?.Persons?
            .Where(p => p.Id != gak.PredsedatelId && p.Id != gak.SekretarId)
            .Select(p => p.Name)
            .ToList() ?? new List<string>();

        var napravlenie = d.ProfilPodgotovki?.NapravleniePodgotovki?.Nazvanie ?? "";
        var profil      = d.ProfilPodgotovki?.Name ?? "";
        var (profilLine1, profilLine2) = SplitAtWidth(profil, 45);

        var konsultanty = d.Konsultanty?
            .OrderBy(k => k.SortOrder)
            .Where(k => k.Person != null)
            .Select(k => k.Person!.Name)
            .ToList() ?? new List<string>();

        var retsenzenty = d.Retsenzenty?
            .OrderBy(r => r.SortOrder)
            .Where(r => r.Person != null)
            .Select(r => r.Person!.Name)
            .ToList() ?? new List<string>();

        var temaLines = SplitToLines(d.Tema, 80, 3);

        var fields = new Dictionary<string, string?>
        {
            // Дата заседания
            ["undefined"]   = date?.Day.ToString(),
            ["undefined_2"] = date.HasValue ? RussianMonth(date.Value.Month) : null,
            ["undefined_3"] = date?.Year.ToString(),

            // Студент
            ["fill_10"]     = d.FioImen,
            ["fill_9"]      = d.VidVkr,
            ["fill_11"]     = napravlenie,
            ["fill_12"]     = profilLine1,

            // Тема ВКР (3 строки, начиная с Text2)
            ["Text1"]       = profilLine2,
            ["Text2"]       = temaLines[0],
            ["Text3"]       = temaLines[1],
            ["Text4"]       = temaLines[2],

            // Руководитель / Консультанты / Рецензенты
            ["fill_13"]     = d.Person?.Name,
            ["fill_14"]     = konsultanty.Count > 0 ? string.Join(", ", konsultanty) : null,
            ["fill_15"]     = retsenzenty.Count > 0 ? string.Join(", ", retsenzenty) : null,

            // Комиссия
            ["fill_16"]     = predsedatel,
            ["fill_17"]     = members.Count > 0 ? members[0] : null,
            ["fill_18"]     = members.Count > 1 ? members[1] : null,
            ["fill_19"]     = members.Count > 2 ? members[2] : null,
            ["fill_20"]     = members.Count > 3 ? members[3] : null,

            // Решение
            ["fill_16_2"]   = d.Otsenka,
            ["fill_17_2"]   = ShortName(predsedatel),

            // Подписи (краткое ФИО)
            ["fill_18_2"]   = ShortName(predsedatel),
            ["fill_19_2"]   = ShortName(sekretar),

            // Объём ВКР
            ["fill_21"]     = d.Pages?.ToString(),
        };

        FillPdf(TemplateProtocol, outputPath, fields);
    }

    private void FillKvalifikacia(Core.Entities.Diplomnik d, string outputPath)
    {
        var gak = d.Zasedanie?.Gak;
        var date = d.Zasedanie?.Date;

        var predsedatel = gak?.Predsedatel?.Name ?? "";
        var sekretar    = gak?.Sekretar?.Name ?? "";
        var members     = gak?.Persons?
            .Where(p => p.Id != gak.PredsedatelId && p.Id != gak.SekretarId)
            .Select(p => p.Name)
            .ToList() ?? new List<string>();

        var napravlenie  = d.ProfilPodgotovki?.NapravleniePodgotovki?.Nazvanie ?? "";
        var profil       = d.ProfilPodgotovki?.Name ?? "";
        var (profilLine1Kval, profilLine2Kval) = SplitAtWidth(profil, 45);
        var kvalificacia = d.Zasedanie?.Kvalificacia ?? "";

        var allCommission = new List<string>();
        if (!string.IsNullOrEmpty(predsedatel)) allCommission.Add(predsedatel);
        allCommission.AddRange(members);
        var commissionLines = SplitCommissionToLines(allCommission, 65, 5);

        var fields = new Dictionary<string, string?>
        {
            // Дата (Text6=день, Text7=месяц, Text8=год)
            ["Text6"] = date?.Day.ToString(),
            ["Text7"] = date.HasValue ? RussianMonth(date.Value.Month) : "",
            ["Text8"] = date?.Year.ToString(),

            // Студент
            ["Text9"]  = d.FioImen,
            ["Text10"] = napravlenie,
            ["Text11"] = profilLine1Kval,
            ["Text12"] = profilLine2Kval,

            // Вид ВКР
            ["Text13"] = d.VidVkr,

            // Комиссия: краткие ФИО через запятую, с переносом на следующую строку
            ["Text14"] = commissionLines[0],
            ["Text15"] = commissionLines[1],
            ["Text16"] = commissionLines[2],
            ["Text17"] = commissionLines[3],
            ["Text18"] = commissionLines[4],

            // Решение
            ["Text19"] = d.FioRodit,   // "выдать диплом [ФИО в род.пад.]"
            ["Text20"] = d.Otsenka,    // "с оценкой..."
            ["Text21"] = kvalificacia, // "присвоить квалификацию..."

            // Подписи (краткое ФИО)
            ["fill_2"] = ShortName(predsedatel),
            ["fill_4"] = ShortName(sekretar),
        };

        FillPdf(TemplateKvalifikacia, outputPath, fields);
    }

    private static void FillPdf(string templatePath, string outputPath, Dictionary<string, string?> fields)
    {
        using var reader = new PdfReader(templatePath);
        using var writer = new PdfWriter(outputPath);
        using var pdf    = new PdfDocument(reader, writer);

        var form = PdfAcroForm.GetAcroForm(pdf, false);
        if (form == null)
            throw new InvalidOperationException(
                $"Шаблон не содержит AcroForm полей: {Path.GetFileName(templatePath)}");

        // NeedAppearances=true — PDF-просмотрщик сам отрисует значения
        form.SetNeedAppearances(true);

        var allFields = form.GetAllFormFields();
        foreach (var (name, value) in fields)
        {
            if (string.IsNullOrEmpty(value)) continue;
            if (allFields.TryGetValue(name, out var field))
                field.SetValue(value);
        }
        // Без flatten — просто сохраняем заполненную форму
    }

    // Разбивает строку на несколько строк по словам
    private static string[] SplitToLines(string text, int maxChars, int lineCount)
    {
        var lines = new string[lineCount];
        if (string.IsNullOrWhiteSpace(text)) return lines;

        var words = text.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        var sb = new System.Text.StringBuilder();
        int idx = 0;

        foreach (var word in words)
        {
            if (idx >= lineCount) break;
            if (sb.Length > 0 && sb.Length + 1 + word.Length > maxChars)
            {
                lines[idx++] = sb.ToString();
                sb.Clear();
            }
            if (sb.Length > 0) sb.Append(' ');
            sb.Append(word);
        }

        if (idx < lineCount && sb.Length > 0)
            lines[idx] = sb.ToString();

        return lines;
    }

    // Раскладывает список имён по строкам: имена идут через ", ", при переполнении — новая строка
    private static string[] SplitCommissionToLines(List<string> names, int maxChars, int lineCount)
    {
        var lines = new string[lineCount];
        if (names.Count == 0) return lines;
        var sb = new System.Text.StringBuilder();
        int idx = 0;
        foreach (var name in names)
        {
            if (idx >= lineCount) break;
            var sep = sb.Length > 0 ? ", " : "";
            if (sb.Length > 0 && sb.Length + sep.Length + name.Length > maxChars)
            {
                lines[idx++] = sb.ToString();
                sb.Clear();
                sb.Append(name);
            }
            else
            {
                sb.Append(sep);
                sb.Append(name);
            }
        }
        if (idx < lineCount && sb.Length > 0)
            lines[idx] = sb.ToString();
        return lines;
    }

    // Разбивает строку: первая часть ≤ maxChars символов, остаток — всё что не влезло
    private static (string first, string rest) SplitAtWidth(string text, int maxChars)
    {
        if (string.IsNullOrWhiteSpace(text)) return ("", "");
        var words = text.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        var sb = new System.Text.StringBuilder();
        int splitIdx = words.Length;
        for (int i = 0; i < words.Length; i++)
        {
            if (sb.Length > 0 && sb.Length + 1 + words[i].Length > maxChars)
            {
                splitIdx = i;
                break;
            }
            if (sb.Length > 0) sb.Append(' ');
            sb.Append(words[i]);
        }
        var rest = splitIdx < words.Length ? string.Join(" ", words[splitIdx..]) : "";
        return (sb.ToString(), rest);
    }

    private static string RussianMonth(int month) => month switch
    {
        1  => "января",  2 => "февраля", 3  => "марта",
        4  => "апреля",  5 => "мая",     6  => "июня",
        7  => "июля",    8 => "августа", 9  => "сентября",
        10 => "октября", 11 => "ноября", 12 => "декабря",
        _  => ""
    };

    private static string ShortName(string fullName)
    {
        if (string.IsNullOrWhiteSpace(fullName)) return "";
        var parts = fullName.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        if (parts.Length == 1) return fullName;
        var result = parts[0];
        for (int i = 1; i < parts.Length; i++)
            result += $" {parts[i][0]}.";
        return result;
    }

    private static string SanitizeFileName(string name) =>
        string.Concat(name.Split(Path.GetInvalidFileNameChars())).Replace(" ", "_");

    public static List<string> GetFieldNames(string templatePath)
    {
        using var reader = new PdfReader(templatePath);
        using var pdf    = new PdfDocument(reader);
        var form = PdfAcroForm.GetAcroForm(pdf, false);
        if (form == null) return new List<string>();
        return form.GetAllFormFields().Keys.OrderBy(k => k).ToList();
    }
}
