namespace asugaksharp.Features.Zasedanie;

public record ZasedanieDto(
    Guid Id,
    string NapravleniePodgotovki,
    string Kvalificacia,
    DateOnly Date,
    Guid GakId,
    string? GakNomerPrikaza)
{
    public string DisplayText => $"{Date:dd.MM.yyyy}  {NapravleniePodgotovki} ({Kvalificacia})";
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
