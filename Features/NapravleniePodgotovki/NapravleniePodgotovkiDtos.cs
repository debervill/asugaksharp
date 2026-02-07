namespace asugaksharp.Features.NapravleniePodgotovki;

public record NapravleniePodgotovkiDto(
    Guid Id,
    string Nazvanie,
    string ShifrNapr);

public record CreateNapravleniePodgotovkiRequest(
    string Nazvanie,
    string ShifrNapr);

public record UpdateNapravleniePodgotovkiRequest(
    Guid Id,
    string Nazvanie,
    string ShifrNapr);
