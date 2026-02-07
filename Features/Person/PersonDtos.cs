namespace asugaksharp.Features.Person;

public record PersonDto(
    Guid Id,
    string Name,
    string Stepen,
    string Zvanie,
    string Dolgnost,
    bool IsPredsed,
    bool IsZavKaf,
    bool IsSecretar,
    bool IsRecenzent,
    bool IsVneshniy,
    Guid KafedraId,
    string? KafedraName);

public record CreatePersonRequest(
    string Name,
    string Stepen,
    string Zvanie,
    string Dolgnost,
    bool IsPredsed,
    bool IsZavKaf,
    bool IsSecretar,
    bool IsRecenzent,
    bool IsVneshniy,
    Guid KafedraId);

public record UpdatePersonRequest(
    Guid Id,
    string Name,
    string Stepen,
    string Zvanie,
    string Dolgnost,
    bool IsPredsed,
    bool IsZavKaf,
    bool IsSecretar,
    bool IsRecenzent,
    bool IsVneshniy,
    Guid KafedraId);
