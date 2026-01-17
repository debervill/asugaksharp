namespace asugaksharp.Features.PeriodZasedania;

public record PeriodZasedaniaDto(
    Guid Id,
    string Name,
    DateOnly DateStart,
    DateOnly DateEnd,
    string Primechanie,
    Guid KafedraId,
    string? KafedraName);

public record CreatePeriodZasedaniaRequest(
    string Name,
    DateOnly DateStart,
    DateOnly DateEnd,
    string Primechanie,
    Guid KafedraId);

public record UpdatePeriodZasedaniaRequest(
    Guid Id,
    string Name,
    DateOnly DateStart,
    DateOnly DateEnd,
    string Primechanie,
    Guid KafedraId);
