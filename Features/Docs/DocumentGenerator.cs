using System.IO;
using TemplateEngine.Docx;
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

    private Content CreateDogovorContent(Entities.Person person, Entities.Oplata oplata, Entities.Gak gak, string zavKafedroy)
    {
        var dataRascheta = oplata.DataRascheta;

        return new Content(
            // Номер и дата договора
            new FieldContent("НомерДоговора", oplata.DogovorNumber.ToString()),
            new FieldContent("ДатаДень", dataRascheta.Day.ToString("00")),
            new FieldContent("ДатаМесяц", GetMonthName(dataRascheta.Month)),
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
            new FieldContent("СтоимостьЧасаПрописью", NumberToWords((decimal)oplata.StoimostChasa)),
            new FieldContent("СтоимостьАкадемЧасаСНалогами", oplata.StoimostAkademChasaSNalogami.ToString("F0")),
            new FieldContent("СтоимостьАкадемЧасаСНалогамиПрописью", NumberToWords((decimal)oplata.StoimostAkademChasaSNalogami)),
            new FieldContent("ОбщаяСтоимостьУслуг", oplata.ObshayaStoimostUslugPoDogovoru.ToString("F0")),
            new FieldContent("ОбщаяСтоимостьУслугПрописью", NumberToWords((decimal)oplata.ObshayaStoimostUslugPoDogovoru)),
            new FieldContent("АкадемЧасов", oplata.AkademChasov.ToString("F2")),
            new FieldContent("АкадемЧасовПрописью", DecimalToWords((decimal)oplata.AkademChasov)),
            new FieldContent("АстрономЧасов", oplata.AstronomChasov.ToString("F2")),
            new FieldContent("АстрономЧасовПрописью", DecimalToWords((decimal)oplata.AstronomChasov)),

            // Суммы
            new FieldContent("СуммаБезНалогов", oplata.SummaBezNalogov.ToString("F0")),
            new FieldContent("СуммаБезНалоговПрописью", NumberToWords((decimal)oplata.SummaBezNalogov)),
            new FieldContent("НДФЛ", oplata.NdflSumma.ToString("F0")),
            new FieldContent("НДФЛПрописью", NumberToWords((decimal)oplata.NdflSumma)),
            new FieldContent("НДФЛПроцент", oplata.NdflProc.ToString("F0")),
            new FieldContent("ЕНП", oplata.EnpSumma.ToString("F0")),
            new FieldContent("ЕНППрописью", NumberToWords((decimal)oplata.EnpSumma)),
            new FieldContent("ЕНПпроцент", oplata.EnpProc.ToString("F0")),
            new FieldContent("СуммаКВыплате", oplata.SummaKVyplate.ToString("F0")),
            new FieldContent("СуммаКВыплатеПрописью", NumberToWords((decimal)oplata.SummaKVyplate)),
            new FieldContent("СуммаСНалогами", oplata.SummaSNalogami.ToString("F0")),
            new FieldContent("СуммаСНалогамиПрописью", NumberToWords((decimal)oplata.SummaSNalogami))
        );
    }

    private Content CreateAktContent(Entities.Person person, Entities.Oplata oplata, Entities.Gak gak, string zavKafedroy)
    {
        var dataRascheta = oplata.DataRascheta;

        return new Content(
            new FieldContent("НомерДоговора", oplata.DogovorNumber.ToString()),
            new FieldContent("ДатаАкта", dataRascheta.ToString("dd.MM.yyyy")),
            new FieldContent("ФИО", person.Name),
            new FieldContent("РольВГЭК", oplata.RolVGek),
            new FieldContent("АкадемЧасов", oplata.AkademChasov.ToString("F2")),
            new FieldContent("СуммаБезНалогов", oplata.SummaBezNalogov.ToString("F0")),
            new FieldContent("СуммаБезНалоговПрописью", NumberToWords((decimal)oplata.SummaBezNalogov)),
            new FieldContent("НомерПриказа", gak.NomerPrikaza),
            new FieldContent("ДатаПриказа", gak.DataPrikaza.ToString("dd.MM.yyyy")),
            new FieldContent("ФИОЗавКафедрой", zavKafedroy)
        );
    }

    private Content CreateZayavlenieContent(Entities.Person person, Entities.Oplata oplata)
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
            new FieldContent("СуммаКВыплатеПрописью", NumberToWords((decimal)oplata.SummaKVyplate))
        );
    }

    private static string GetMonthName(int month)
    {
        return month switch
        {
            1 => "января",
            2 => "февраля",
            3 => "марта",
            4 => "апреля",
            5 => "мая",
            6 => "июня",
            7 => "июля",
            8 => "августа",
            9 => "сентября",
            10 => "октября",
            11 => "ноября",
            12 => "декабря",
            _ => ""
        };
    }

    /// <summary>
    /// Преобразует денежную сумму в текст прописью (например: 1845,00 → "одна тысяча восемьсот сорок пять")
    /// </summary>
    private static string NumberToWords(decimal number)
    {
        var rubles = (long)Math.Floor(number);
        return NumberToWordsRussian(rubles);
    }

    private static string GetRublesWord(long rubles)
    {
        var lastTwo = rubles % 100;
        var lastOne = rubles % 10;

        if (lastTwo >= 11 && lastTwo <= 19)
            return "рублей";

        return lastOne switch
        {
            1 => "рубль",
            2 or 3 or 4 => "рубля",
            _ => "рублей"
        };
    }

    private static string GetKopecksWord(int kopecks)
    {
        var lastTwo = kopecks % 100;
        var lastOne = kopecks % 10;

        if (lastTwo >= 11 && lastTwo <= 19)
            return "копеек";

        return lastOne switch
        {
            1 => "копейка",
            2 or 3 or 4 => "копейки",
            _ => "копеек"
        };
    }

    /// <summary>
    /// Преобразует десятичное число в текст прописью (например: 11,25 → "одиннадцать целых двадцать пять сотых")
    /// </summary>
    private static string DecimalToWords(decimal number)
    {
        if (number == 0)
            return "ноль";

        var wholePart = (long)Math.Floor(number);
        var decimalPart = number - wholePart;

        // Определяем количество знаков после запятой (максимум 2)
        var fraction = (int)Math.Round(decimalPart * 100);

        if (fraction == 0)
            return NumberToWordsRussian(wholePart);

        // Если дробная часть кратна 10, используем десятые (7,50 → "семь целых пять десятых")
        int decimalPlaces;
        int fractionValue;
        if (fraction % 10 == 0)
        {
            decimalPlaces = 1;
            fractionValue = fraction / 10;
        }
        else
        {
            decimalPlaces = 2;
            fractionValue = fraction;
        }

        var wholeWord = GetWholeWord(wholePart);
        var fractionWord = GetFractionWord(fractionValue, decimalPlaces);

        return $"{NumberToWordsRussian(wholePart)} {wholeWord} {NumberToWordsRussian(fractionValue)} {fractionWord}";
    }

    private static string NumberToWordsRussian(long number)
    {
        if (number == 0)
            return "ноль";

        if (number < 0)
            return "минус " + NumberToWordsRussian(-number);

        var words = new List<string>();

        // Миллионы
        if (number >= 1000000)
        {
            var millions = number / 1000000;
            words.Add(NumberToWordsRussian(millions));
            words.Add(GetMillionWord(millions));
            number %= 1000000;
        }

        // Тысячи
        if (number >= 1000)
        {
            var thousands = number / 1000;
            words.Add(ThousandsToWords(thousands));
            words.Add(GetThousandWord(thousands));
            number %= 1000;
        }

        // Сотни
        if (number >= 100)
        {
            words.Add(HundredsToWords(number / 100));
            number %= 100;
        }

        // Десятки и единицы
        if (number > 0)
        {
            words.Add(TensAndUnitsToWords(number));
        }

        return string.Join(" ", words);
    }

    private static string ThousandsToWords(long thousands)
    {
        if (thousands >= 100)
        {
            var result = new List<string>();
            result.Add(HundredsToWords(thousands / 100));
            thousands %= 100;
            if (thousands > 0)
                result.Add(TensAndUnitsToWordsFeminine(thousands));
            return string.Join(" ", result);
        }
        return TensAndUnitsToWordsFeminine(thousands);
    }

    private static string HundredsToWords(long hundreds)
    {
        return hundreds switch
        {
            1 => "сто",
            2 => "двести",
            3 => "триста",
            4 => "четыреста",
            5 => "пятьсот",
            6 => "шестьсот",
            7 => "семьсот",
            8 => "восемьсот",
            9 => "девятьсот",
            _ => ""
        };
    }

    private static string TensAndUnitsToWords(long number)
    {
        if (number < 20)
        {
            return number switch
            {
                1 => "один",
                2 => "два",
                3 => "три",
                4 => "четыре",
                5 => "пять",
                6 => "шесть",
                7 => "семь",
                8 => "восемь",
                9 => "девять",
                10 => "десять",
                11 => "одиннадцать",
                12 => "двенадцать",
                13 => "тринадцать",
                14 => "четырнадцать",
                15 => "пятнадцать",
                16 => "шестнадцать",
                17 => "семнадцать",
                18 => "восемнадцать",
                19 => "девятнадцать",
                _ => ""
            };
        }

        var tens = (number / 10) switch
        {
            2 => "двадцать",
            3 => "тридцать",
            4 => "сорок",
            5 => "пятьдесят",
            6 => "шестьдесят",
            7 => "семьдесят",
            8 => "восемьдесят",
            9 => "девяносто",
            _ => ""
        };

        var units = number % 10;
        if (units == 0)
            return tens;

        return tens + " " + TensAndUnitsToWords(units);
    }

    private static string TensAndUnitsToWordsFeminine(long number)
    {
        if (number == 1) return "одна";
        if (number == 2) return "две";
        return TensAndUnitsToWords(number);
    }

    private static string GetThousandWord(long thousands)
    {
        var lastTwo = thousands % 100;
        var lastOne = thousands % 10;

        if (lastTwo >= 11 && lastTwo <= 19)
            return "тысяч";

        return lastOne switch
        {
            1 => "тысяча",
            2 or 3 or 4 => "тысячи",
            _ => "тысяч"
        };
    }

    private static string GetMillionWord(long millions)
    {
        var lastTwo = millions % 100;
        var lastOne = millions % 10;

        if (lastTwo >= 11 && lastTwo <= 19)
            return "миллионов";

        return lastOne switch
        {
            1 => "миллион",
            2 or 3 or 4 => "миллиона",
            _ => "миллионов"
        };
    }

    private static string GetWholeWord(long whole)
    {
        var lastTwo = whole % 100;
        var lastOne = whole % 10;

        if (lastTwo >= 11 && lastTwo <= 19)
            return "целых";

        return lastOne switch
        {
            1 => "целая",
            2 or 3 or 4 => "целых",
            _ => "целых"
        };
    }

    private static string GetFractionWord(int fraction, int decimalPlaces)
    {
        var lastTwo = fraction % 100;
        var lastOne = fraction % 10;

        if (decimalPlaces == 2)
        {
            if (lastTwo >= 11 && lastTwo <= 19)
                return "сотых";

            return lastOne switch
            {
                1 => "сотая",
                2 or 3 or 4 => "сотых",
                _ => "сотых"
            };
        }

        // Для одного знака после запятой
        if (lastTwo >= 11 && lastTwo <= 19)
            return "десятых";

        return lastOne switch
        {
            1 => "десятая",
            2 or 3 or 4 => "десятых",
            _ => "десятых"
        };
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
