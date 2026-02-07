namespace asugaksharp.Features.Gak;

public record GakDto(
    Guid Id,
    string NomerPrikaza,
    int KolvoBudget,
    int KolvoPlatka,
    Guid PeriodZasedaniaId,
    string? PeriodZasedaniaName,
    Guid KafedraId,
    string? KafedraName);

public record CreateGakRequest(
    string NomerPrikaza,
    int KolvoBudget,
    int KolvoPlatka,
    Guid PeriodZasedaniaId,
    Guid KafedraId);

public record UpdateGakRequest(
    Guid Id,
    string NomerPrikaza,
    int KolvoBudget,
    int KolvoPlatka,
    Guid PeriodZasedaniaId,
    Guid KafedraId);
