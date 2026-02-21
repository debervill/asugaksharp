namespace asugaksharp.Features.Diplomnik;

public record DiplomnikDto(
    Guid Id,
    Guid StudentId,
    string FioImen,
    string FioRodit,
    string Sex,
    int Pages,
    string Tema,
    float OrigVkr,
    float Srball,
    Guid PersonId,
    string? PersonName,
    Guid ZasedanieId,
    string? ZasedanieName);

public record CreateDiplomnikRequest(
    Guid StudentId,
    Guid ZasedanieId);

public record UpdateDiplomnikRequest(
    Guid Id,
    Guid StudentId,
    Guid ZasedanieId);
