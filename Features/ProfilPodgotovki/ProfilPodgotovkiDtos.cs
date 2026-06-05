namespace asugaksharp.Features.ProfilPodgotovki;

public record ProfilPodgotovkiDto(
    Guid Id,
    string Name,
    Guid NapravleniePodgotovkiId,
    string? NapravleniePodgotovkiName);

public record CreateProfilPodgotovkiRequest(
    string Name,
    Guid NapravleniePodgotovkiId);

public record UpdateProfilPodgotovkiRequest(
    Guid Id,
    string Name,
    Guid NapravleniePodgotovkiId);
