namespace asugaksharp.Features.Zasedanie;

public record DiplomnikForDistributionDto(
    Guid Id,
    string FioImen,
    string Tema,
    string? PersonName,
    string? ProfilName,
    Guid? KafedraId,
    string? KafedraName,
    Guid? NapravleniePodgotovkiId,
    string? NapravlenieName,
    string? VidVkr,
    int? ZasedanieOrder);

public record FilterItemDto(Guid Id, string Name);

public record NumberedDiplomnik(int Number, DiplomnikForDistributionDto Data);
