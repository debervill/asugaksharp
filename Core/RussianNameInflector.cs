using NPetrovichLite;

namespace asugaksharp.Core;

public static class RussianNameInflector
{
    private static readonly Petrovich _p = new();

    /// <summary>
    /// Склоняет ФИО из именительного в дательный падеж.
    /// Формат входа и выхода: "Фамилия Имя Отчество" (отчество необязательно).
    /// </summary>
    public static string ToDative(string fioNominative, Gender gender)
    {
        if (string.IsNullOrWhiteSpace(fioNominative))
            return fioNominative;

        var parts = fioNominative.Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries);

        var fio = new Petrovich.FIO
        {
            lastName  = parts.Length > 0 ? parts[0] : null,
            firstName = parts.Length > 1 ? parts[1] : null,
            midName   = parts.Length > 2 ? parts[2] : null,
        };

        try
        {
            var result = _p.Inflect(fio, Case.Dative, gender);
            return string.Join(" ",
                new[] { result.lastName, result.firstName, result.midName }
                .Where(s => !string.IsNullOrEmpty(s)));
        }
        catch
        {
            return fioNominative;
        }
    }
}
