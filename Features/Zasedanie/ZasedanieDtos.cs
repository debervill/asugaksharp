namespace asugaksharp.Features.Zasedanie;

public record ZasedanieDto(
    Guid Id,
    string NapravleniePodgotovki,
    string Kvalificacia,
    DateOnly Date,
    Guid GakId,
    string? GakNomerPrikaza)
{
    public string DisplayName => $"{NapravleniePodgotovki} ({Date:dd.MM.yyyy})";
}

public record CreateZasedanieRequest(
    string NapravleniePodgotovki,
    string Kvalificacia,
    DateOnly Date,
    Guid GakId);

public record UpdateZasedanieRequest(
    Guid Id,
    string NapravleniePodgotovki,
    string Kvalificacia,
    DateOnly Date,
    Guid GakId);
