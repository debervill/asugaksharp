namespace asugaksharp.Features.Diplomnik;

public record KonsultantInfo(Guid PersonId, string PersonName);
public record RetsenzentInfo(Guid PersonId, string PersonName);

public record DiplomnikDto(
    Guid Id,
    string FioImen,
    string FioRodit,
    string Sex,
    int? Pages,
    string Tema,
    float? OrigVkr,
    float? Srball,
    string? Otsenka,
    string? VidVkr,
    Guid PersonId,
    string? PersonName,
    Guid? ProfilPodgotovkiId,
    string? ProfilPodgotovkiName,
    List<KonsultantInfo> Konsultanty,
    List<RetsenzentInfo> Retsenzenty)
{
    public string KonsultantyStr => Konsultanty.Count == 0
        ? string.Empty
        : string.Join(", ", Konsultanty.Select(k => k.PersonName));

    public string RetsenzentyStr => Retsenzenty.Count == 0
        ? string.Empty
        : string.Join(", ", Retsenzenty.Select(r => r.PersonName));
}

public record CreateDiplomnikRequest(
    string FioImen,
    string FioRodit,
    string Sex,
    int? Pages,
    string Tema,
    float? OrigVkr,
    float? Srball,
    string? Otsenka,
    string? VidVkr,
    Guid PersonId,
    Guid? ProfilPodgotovkiId,
    List<Guid> KonsultantIds,
    List<Guid> RetsenzentIds);

public record UpdateDiplomnikRequest(
    Guid Id,
    string FioImen,
    string FioRodit,
    string Sex,
    int? Pages,
    string Tema,
    float? OrigVkr,
    float? Srball,
    string? Otsenka,
    string? VidVkr,
    Guid PersonId,
    Guid? ProfilPodgotovkiId,
    List<Guid> KonsultantIds,
    List<Guid> RetsenzentIds);
