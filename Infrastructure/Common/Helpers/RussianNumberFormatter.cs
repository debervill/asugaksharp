namespace asugaksharp.Infrastructure.Common.Helpers;

/// <summary>
/// Преобразование чисел в текст на русском языке (прописью)
/// </summary>
public static class RussianNumberFormatter
{
    /// <summary>
    /// Преобразует целое число в текст прописью (например: 1845 → "одна тысяча восемьсот сорок пять")
    /// </summary>
    public static string NumberToWords(decimal number)
    {
        var wholeNumber = (long)Math.Floor(number);
        return ToWordsInternal(wholeNumber);
    }

    /// <summary>
    /// Преобразует десятичное число в текст прописью (например: 11,25 → "одиннадцать целых двадцать пять сотых")
    /// </summary>
    public static string DecimalToWords(decimal number)
    {
        if (number == 0)
            return "ноль";

        var wholePart = (long)Math.Floor(number);
        var decimalPart = number - wholePart;

        var fraction = (int)Math.Round(decimalPart * 100);

        if (fraction == 0)
            return ToWordsInternal(wholePart);

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

        return $"{ToWordsInternal(wholePart)} {wholeWord} {ToWordsInternal(fractionValue)} {fractionWord}";
    }

    /// <summary>
    /// Возвращает склонённое слово "рубль" для числа
    /// </summary>
    public static string GetRublesWord(long rubles)
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

    /// <summary>
    /// Возвращает склонённое слово "копейка" для числа
    /// </summary>
    public static string GetKopecksWord(int kopecks)
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

    private static string ToWordsInternal(long number)
    {
        if (number == 0)
            return "ноль";

        if (number < 0)
            return "минус " + ToWordsInternal(-number);

        var words = new List<string>();

        // Миллионы
        if (number >= 1000000)
        {
            var millions = number / 1000000;
            words.Add(ToWordsInternal(millions));
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
