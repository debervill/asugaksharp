namespace asugaksharp.Infrastructure.Common.Helpers;

/// <summary>
/// Форматирование дат на русском языке
/// </summary>
public static class RussianDateFormatter
{
    /// <summary>
    /// Возвращает название месяца в родительном падеже
    /// </summary>
    public static string GetMonthNameGenitive(int month)
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
}
