namespace asugaksharp.Features.Diplomnik;

public record DiplomnikDto(
    Guid Id,
    string FioImen,
    string FioRodit,
    string Sex,
    int Pages,
    string Tema,
    float OrigVkr,
    float Srball,
    Guid PersonId,
    string? PersonName);

public record CreateDiplomnikRequest(
    string FioImen,
    string FioRodit,
    string Sex,
    int Pages,
    string Tema,
    float OrigVkr,
    float Srball,
    Guid PersonId);

public record UpdateDiplomnikRequest(
    Guid Id,
    string FioImen,
    string FioRodit,
    string Sex,
    int Pages,
    string Tema,
    float OrigVkr,
    float Srball,
    Guid PersonId);
