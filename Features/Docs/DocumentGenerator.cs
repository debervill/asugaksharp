using System.IO;
using TemplateEngine.Docx;
using asugaksharp.Infrastructure.Common.Helpers;
using Entities = asugaksharp.Core.Entities;

namespace asugaksharp.Features.Docs;

public class DocumentGenerator
{
    private readonly string _templatesPath;

    public DocumentGenerator()
    {
        _templatesPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Templates");
    }

    public DocumentGenerator(string templatesPath)
    {
        _templatesPath = templatesPath;
    }

    /// <summary>
    /// Генерирует договор ГПХ на основе данных Person и Oplata
    /// </summary>
    public string GenerateDogovor(Entities.Person person, Entities.Oplata oplata, Entities.Gak gak, string zavKafedroy, string outputPath)
    {
        var templatePath = Path.Combine(_templatesPath, "Dogovor.docx");

        if (!File.Exists(templatePath))
            throw new FileNotFoundException($"Шаблон договора не найден: {templatePath}");

        var outputFile = Path.Combine(outputPath, $"Договор_{oplata.DogovorNumber}_{person.Name}.docx");
        File.Copy(templatePath, outputFile, true);

        using var outputDocument = new TemplateProcessor(outputFile)
            .SetRemoveContentControls(true);

        var content = CreateDogovorContent(person, oplata, gak, zavKafedroy);
        outputDocument.FillContent(content);
        outputDocument.SaveChanges();

        return outputFile;
    }

    /// <summary>
    /// Генерирует акт выполненных работ
    /// </summary>
    public string GenerateAkt(Entities.Person person, Entities.Oplata oplata, Entities.Gak gak, string zavKafedroy, string outputPath)
    {
        var templatePath = Path.Combine(_templatesPath, "Akt.docx");

        if (!File.Exists(templatePath))
            throw new FileNotFoundException($"Шаблон акта не найден: {templatePath}");

        var outputFile = Path.Combine(outputPath, $"Акт_{oplata.DogovorNumber}_{person.Name}.docx");
        File.Copy(templatePath, outputFile, true);

        using var outputDocument = new TemplateProcessor(outputFile)
            .SetRemoveContentControls(true);

        var content = CreateAktContent(person, oplata, gak, zavKafedroy);
        outputDocument.FillContent(content);
        outputDocument.SaveChanges();

        return outputFile;
    }

    /// <summary>
    /// Генерирует заявление на оплату
    /// </summary>
    public string GenerateZayavlenie(Entities.Person person, Entities.Oplata oplata, string outputPath)
    {
        var templatePath = Path.Combine(_templatesPath, "Zayavlenie.docx");

        if (!File.Exists(templatePath))
            throw new FileNotFoundException($"Шаблон заявления не найден: {templatePath}");

        var outputFile = Path.Combine(outputPath, $"Заявление_{person.Name}.docx");
        File.Copy(templatePath, outputFile, true);

        using var outputDocument = new TemplateProcessor(outputFile)
            .SetRemoveContentControls(true);

        var content = CreateZayavlenieContent(person, oplata);
        outputDocument.FillContent(content);
        outputDocument.SaveChanges();

        return outputFile;
    }

    /// <summary>
    /// Генерирует все документы для оплаты
    /// </summary>
    public GeneratedDocumentsResult GenerateAllDocuments(Entities.Person person, Entities.Oplata oplata, Entities.Gak gak, string zavKafedroy, string outputPath)
    {
        if (!Directory.Exists(outputPath))
            Directory.CreateDirectory(outputPath);

        var result = new GeneratedDocumentsResult();

        try
        {
            result.DogovorPath = GenerateDogovor(person, oplata, gak, zavKafedroy, outputPath);
        }
        catch (FileNotFoundException ex)
        {
            result.Errors.Add($"Договор: {ex.Message}");
        }

        try
        {
            result.AktPath = GenerateAkt(person, oplata, gak, zavKafedroy, outputPath);
        }
        catch (FileNotFoundException ex)
        {
            result.Errors.Add($"Акт: {ex.Message}");
        }

        try
        {
            result.ZayavleniePath = GenerateZayavlenie(person, oplata, outputPath);
        }
        catch (FileNotFoundException ex)
        {
            result.Errors.Add($"Заявление: {ex.Message}");
        }

        return result;
    }

    private static Content CreateDogovorContent(Entities.Person person, Entities.Oplata oplata, Entities.Gak gak, string zavKafedroy)
    {
        var dataRascheta = oplata.DataRascheta;

        return new Content(
            // Номер и дата договора
            new FieldContent("НомерДоговора", oplata.DogovorNumber.ToString()),
            new FieldContent("ДатаДень", dataRascheta.Day.ToString("00")),
            new FieldContent("ДатаМесяц", RussianDateFormatter.GetMonthNameGenitive(dataRascheta.Month)),
            new FieldContent("ДатаГод", dataRascheta.Year.ToString()),
            new FieldContent("ДатаДоговора", dataRascheta.ToString("dd.MM.yyyy")),

            // Персональные данные
            new FieldContent("ФИО", person.Name),
            new FieldContent("ПаспортСерия", person.PassportSeria ?? ""),
            new FieldContent("ПаспортНомер", person.PassportNomer ?? ""),
            new FieldContent("ПаспортКемВыдан", person.PassportIssuedBy ?? ""),
            new FieldContent("АдресРегистрации", person.RegistrationAddress ?? ""),
            new FieldContent("СНИЛС", person.Snils ?? ""),
            new FieldContent("ИНН", person.Inn ?? ""),
            new FieldContent("Email", person.Email ?? ""),
            new FieldContent("Телефон", person.Phone ?? ""),

            // Должность и звание
            new FieldContent("Степень", person.Stepen),
            new FieldContent("Звание", person.Zvanie),
            new FieldContent("Должность", person.Dolgnost),

            // Роль в ГЭК
            new FieldContent("РольВГЭК", oplata.RolVGek),

            // Данные ГАК
            new FieldContent("НомерПриказа", gak.NomerPrikaza),
            new FieldContent("ДатаПриказа", gak.DataPrikaza.ToString("dd.MM.yyyy")),
            new FieldContent("Основание", gak.Osnovanie),
            new FieldContent("Кафедра", gak.Kafedra?.Name ?? ""),
            new FieldContent("ФИОЗавКафедрой", zavKafedroy),

            // Расчетные данные
            new FieldContent("КоличествоБюджет", oplata.KolvoBudget.ToString()),
            new FieldContent("КоличествоПлатка", oplata.KolvoPlatka.ToString()),
            new FieldContent("КоличествоВсего", (oplata.KolvoBudget + oplata.KolvoPlatka).ToString()),
            new FieldContent("Коэффициент", oplata.Koefficient.ToString("F2")),
            new FieldContent("СтоимостьЧаса", oplata.StoimostChasa.ToString("F0")),
            new FieldContent("СтоимостьЧасаПрописью", RussianNumberFormatter.NumberToWords((decimal)oplata.StoimostChasa)),
            new FieldContent("СтоимостьАкадемЧасаСНалогами", oplata.StoimostAkademChasaSNalogami.ToString("F0")),
            new FieldContent("СтоимостьАкадемЧасаСНалогамиПрописью", RussianNumberFormatter.NumberToWords((decimal)oplata.StoimostAkademChasaSNalogami)),
            new FieldContent("ОбщаяСтоимостьУслуг", oplata.ObshayaStoimostUslugPoDogovoru.ToString("F0")),
            new FieldContent("ОбщаяСтоимостьУслугПрописью", RussianNumberFormatter.NumberToWords((decimal)oplata.ObshayaStoimostUslugPoDogovoru)),
            new FieldContent("АкадемЧасов", oplata.AkademChasov.ToString("F2")),
            new FieldContent("АкадемЧасовПрописью", RussianNumberFormatter.DecimalToWords((decimal)oplata.AkademChasov)),
            new FieldContent("АстрономЧасов", oplata.AstronomChasov.ToString("F2")),
            new FieldContent("АстрономЧасовПрописью", RussianNumberFormatter.DecimalToWords((decimal)oplata.AstronomChasov)),

            // Суммы
            new FieldContent("СуммаБезНалогов", oplata.SummaBezNalogov.ToString("F0")),
            new FieldContent("СуммаБезНалоговПрописью", RussianNumberFormatter.NumberToWords((decimal)oplata.SummaBezNalogov)),
            new FieldContent("НДФЛ", oplata.NdflSumma.ToString("F0")),
            new FieldContent("НДФЛПрописью", RussianNumberFormatter.NumberToWords((decimal)oplata.NdflSumma)),
            new FieldContent("НДФЛПроцент", oplata.NdflProc.ToString("F0")),
            new FieldContent("ЕНП", oplata.EnpSumma.ToString("F0")),
            new FieldContent("ЕНППрописью", RussianNumberFormatter.NumberToWords((decimal)oplata.EnpSumma)),
            new FieldContent("ЕНПпроцент", oplata.EnpProc.ToString("F0")),
            new FieldContent("СуммаКВыплате", oplata.SummaKVyplate.ToString("F0")),
            new FieldContent("СуммаКВыплатеПрописью", RussianNumberFormatter.NumberToWords((decimal)oplata.SummaKVyplate)),
            new FieldContent("СуммаСНалогами", oplata.SummaSNalogami.ToString("F0")),
            new FieldContent("СуммаСНалогамиПрописью", RussianNumberFormatter.NumberToWords((decimal)oplata.SummaSNalogami))
        );
    }

    private static Content CreateAktContent(Entities.Person person, Entities.Oplata oplata, Entities.Gak gak, string zavKafedroy)
    {
        var dataRascheta = oplata.DataRascheta;

        return new Content(
            new FieldContent("НомерДоговора", oplata.DogovorNumber.ToString()),
            new FieldContent("ДатаАкта", dataRascheta.ToString("dd.MM.yyyy")),
            new FieldContent("ФИО", person.Name),
            new FieldContent("РольВГЭК", oplata.RolVGek),
            new FieldContent("АкадемЧасов", oplata.AkademChasov.ToString("F2")),
            new FieldContent("СуммаБезНалогов", oplata.SummaBezNalogov.ToString("F0")),
            new FieldContent("СуммаБезНалоговПрописью", RussianNumberFormatter.NumberToWords((decimal)oplata.SummaBezNalogov)),
            new FieldContent("НомерПриказа", gak.NomerPrikaza),
            new FieldContent("ДатаПриказа", gak.DataPrikaza.ToString("dd.MM.yyyy")),
            new FieldContent("ФИОЗавКафедрой", zavKafedroy)
        );
    }

    private static Content CreateZayavlenieContent(Entities.Person person, Entities.Oplata oplata)
    {
        return new Content(
            new FieldContent("ФИО", person.Name),
            new FieldContent("ПаспортСерия", person.PassportSeria ?? ""),
            new FieldContent("ПаспортНомер", person.PassportNomer ?? ""),
            new FieldContent("ПаспортКемВыдан", person.PassportIssuedBy ?? ""),
            new FieldContent("АдресРегистрации", person.RegistrationAddress ?? ""),
            new FieldContent("СНИЛС", person.Snils ?? ""),
            new FieldContent("ИНН", person.Inn ?? ""),
            new FieldContent("Email", person.Email ?? ""),
            new FieldContent("Телефон", person.Phone ?? ""),
            new FieldContent("СуммаКВыплате", oplata.SummaKVyplate.ToString("F0")),
            new FieldContent("СуммаКВыплатеПрописью", RussianNumberFormatter.NumberToWords((decimal)oplata.SummaKVyplate))
        );
    }
}

public class GeneratedDocumentsResult
{
    public string? DogovorPath { get; set; }
    public string? AktPath { get; set; }
    public string? ZayavleniePath { get; set; }
    public List<string> Errors { get; set; } = new();
    public bool HasErrors => Errors.Count > 0;
    public bool IsSuccess => !HasErrors && (DogovorPath != null || AktPath != null || ZayavleniePath != null);
}
