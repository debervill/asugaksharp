namespace asugaksharp.Features.ProfilPodgotovki;

public record ProfilPodgotovkiDto(
    Guid Id,
    string Name,
    string ShifrPodgot,
    Guid NapravleniePodgotovkiId,
    string? NapravleniePodgotovkiName);

public record CreateProfilPodgotovkiRequest(
    string Name,
    string ShifrPodgot,
    Guid NapravleniePodgotovkiId);

public record UpdateProfilPodgotovkiRequest(
    Guid Id,
    string Name,
    string ShifrPodgot,
    Guid NapravleniePodgotovkiId);
